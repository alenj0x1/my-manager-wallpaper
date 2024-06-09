using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Http;

namespace MyWallpaperManager
{
  public partial class Form1 : Form
  {
    private readonly List<WallpaperModel> wallpapers = new List<WallpaperModel>();

    public class WallpaperModel
    {
      public string ImagePath { get; set; }
      public bool IsDownloaded { get; set; }
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    const int SPI_SETDESKWALLPAPER = 20; // Value set wallpaper
    const int SPIF_UPDATEINIFILE = 0x01; // Save parameters in config user file;
    const int SPIF_SENDCHANGE = 0x02; // Notify apps change

    private void SetWallpaper(string wallpaper)
    {
      SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaper, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
    }

    public Form1()
    {
      InitializeComponent();

      this.FormClosed += ClosedForm;

      // Visualize correctly wallpaper
      pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

      string[] wallpapersLines = File.ReadAllLines("wallpapers.txt");
      List<WallpaperModel> listWallpapers = GetWallpapers(wallpapersLines);

      // Save wallpapers in app
      foreach (WallpaperModel wallpaper in listWallpapers)
      {
        wallpapers.Add(wallpaper);
        listBox1.Items.Add(Path.GetFileName(wallpaper.ImagePath));
      }

      // Create a folder for storage wallpapers
      if (!Directory.Exists(@".\images")) Directory.CreateDirectory(@".\images");
    }

    // Add button
    private void AddButtonClick(object sender, EventArgs e)
    {
      // Select file window
      OpenFileDialog openFileDialog = new OpenFileDialog()
      {
        Filter = " Image files: (*.jpg; *.jpeg; *.png;) | *.jpg; *.jpeg; *.png;"
      };

      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        string selectedFile = openFileDialog.FileName;

        WallpaperModel newWallpaper = new WallpaperModel()
        {
          ImagePath = selectedFile,
          IsDownloaded = false
        };

        wallpapers.Add(newWallpaper);
        listBox1.Items.Add(Path.GetFileName(newWallpaper.ImagePath));
      }
    }

    // Remove button
    private void RemoveButtonClick(object sender, EventArgs e)
    {
      if (listBox1.SelectedIndex < 0) return;

      if (wallpapers.ElementAt(listBox1.SelectedIndex).IsDownloaded)
      {
        try
        {
          pictureBox1.Image.Dispose(); // ! important, first dispose
          pictureBox1.Image = null; // after null

          // Delete wallpaper in directory
          File.Delete(wallpapers.ElementAt(listBox1.SelectedIndex).ImagePath);
        }
        catch (Exception)
        {
          MessageBox.Show("There was an error trying to download the file.");
        }
      }

      // Remove wallpaper view
      pictureBox1.Image = null;

      wallpapers.RemoveAt(listBox1.SelectedIndex);
      listBox1.Items.RemoveAt(listBox1.SelectedIndex);
    }

    // Select wallpaper
    private void ListBoxSelect(object sender, EventArgs e)
    {
      if (listBox1.SelectedIndex < 0) return;

      pictureBox1.Image = new Bitmap(wallpapers.ElementAt(listBox1.SelectedIndex).ImagePath);
    }

    // Set wallpaper
    private void SetWallpaperClick(object sender, EventArgs e)
    {
      if (listBox1.SelectedIndex < 0) return;

      SetWallpaper(wallpapers[listBox1.SelectedIndex].ImagePath);
    }

    // Download wallpaper
    private async void DownloadButtonClick(object sender, EventArgs e)
    {
      // Get files count
      int imagesInPicturesFolder = Directory.GetFiles(@".\images")
                                                .Where(x => 
                                                        x.Contains(".jpeg") || 
                                                        x.Contains(".jpg") || 
                                                        x.Contains(".png") || 
                                                        x.Contains(".webp"))
                                                .Count();
                                  
      
      string pathToDownloadImage = Path.Combine(Environment.CurrentDirectory, "images", $"downloaded_image_{imagesInPicturesFolder + 1}.jpg");

      if (textBox1.Text.Contains(".webp"))
      {
        MessageBox.Show("Webp formats are not supported");
      }

      if (textBox1.Text.Length > 0)
      {
        bool downloadImage = await DownloadWallpaperAsync(textBox1.Text, pathToDownloadImage);

        // Check downloaded image
        if (!downloadImage)
        {
          MessageBox.Show("The image could not be downloaded, please check the URL.");
          return;
        }
      }
      else
      {
        MessageBox.Show("Enter a valid URL.");
        return;
      }

      WallpaperModel newWallpaper = new WallpaperModel()
      {
        ImagePath = pathToDownloadImage,
        IsDownloaded = true
      };

      wallpapers.Add(newWallpaper);
      listBox1.Items.Add(Path.GetFileName(pathToDownloadImage));

      DialogResult alert = MessageBox.Show("Image downloaded successfully.");
    }

    // Get wallpaper
    private WallpaperModel GetWallpaper(string wallpaper)
    {
      string[] dataWallpaper = wallpaper.Split('|');

      if (dataWallpaper.Length == 2)
      {
        WallpaperModel newWallpaper = new WallpaperModel
        {
          ImagePath = dataWallpaper[0],
          IsDownloaded = dataWallpaper[1] == "true"
        };

        return newWallpaper;
      }

      return null;
    }

    // Get wallpapers
    private List<WallpaperModel> GetWallpapers(string[] wallpapers)
    {
      List<WallpaperModel> listWallpapers = new List<WallpaperModel>();

      foreach (string wallpaper in wallpapers)
      {
        WallpaperModel newWallpaper = GetWallpaper(wallpaper);

        if (newWallpaper is null) break;

        listWallpapers.Add(newWallpaper);
      }

      return listWallpapers;
    }

    // Download wallpaper
    private async Task<bool> DownloadWallpaperAsync(string url, string savePath)
    {
      using (HttpClient client = new HttpClient())
      {
        try
        {
          // Using http client
          HttpResponseMessage response = await client.GetAsync(url);
          response.EnsureSuccessStatusCode();

          byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

          File.WriteAllBytes(savePath, imageBytes);

          return true;
        }
        catch (InvalidOperationException)
        {
          return false;
        }
        catch (ArgumentException)
        {
          return false;
        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    // Form closed
    private void ClosedForm(object sender, FormClosedEventArgs e)
    {
      using (StreamWriter writer = new StreamWriter("wallpapers.txt"))
      {
        foreach (WallpaperModel wallpaper in wallpapers)
        {
          StringBuilder line = new StringBuilder();

          line.Append(wallpaper.ImagePath);
          line.Append("|");
          line.Append(wallpaper.IsDownloaded.ToString());

          writer.WriteLine(line);
        }
      }
    }
  }
}
