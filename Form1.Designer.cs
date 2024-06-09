namespace MyWallpaperManager
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button4 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // listBox1
      // 
      this.listBox1.BackColor = System.Drawing.Color.Bisque;
      this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox1.Font = new System.Drawing.Font("JetBrains Mono Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 16;
      this.listBox1.Location = new System.Drawing.Point(29, 59);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(201, 192);
      this.listBox1.TabIndex = 0;
      this.listBox1.Click += new System.EventHandler(this.ListBoxSelect);
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("JetBrains Mono Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(25, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(340, 29);
      this.label1.TabIndex = 1;
      this.label1.Text = "My Wallpaper Manager v1.0.0\r\n";
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(246, 59);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(377, 392);
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.LightCyan;
      this.button1.Font = new System.Drawing.Font("JetBrains Mono Light", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(29, 272);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(94, 34);
      this.button1.TabIndex = 3;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.AddButtonClick);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.Bisque;
      this.button2.Font = new System.Drawing.Font("JetBrains Mono Light", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(129, 272);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(101, 34);
      this.button2.TabIndex = 4;
      this.button2.Text = "Remove";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.RemoveButtonClick);
      // 
      // button3
      // 
      this.button3.BackColor = System.Drawing.Color.Lavender;
      this.button3.Font = new System.Drawing.Font("JetBrains Mono Light", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button3.Location = new System.Drawing.Point(29, 312);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(201, 36);
      this.button3.TabIndex = 5;
      this.button3.Text = "Set wallpaper";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new System.EventHandler(this.SetWallpaperClick);
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.Color.Bisque;
      this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox1.Font = new System.Drawing.Font("JetBrains Mono Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.Location = new System.Drawing.Point(29, 365);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(201, 40);
      this.textBox1.TabIndex = 6;
      // 
      // button4
      // 
      this.button4.BackColor = System.Drawing.Color.Honeydew;
      this.button4.Font = new System.Drawing.Font("JetBrains Mono Light", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button4.Location = new System.Drawing.Point(29, 411);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(201, 40);
      this.button4.TabIndex = 7;
      this.button4.Text = "Download";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new System.EventHandler(this.DownloadButtonClick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(651, 501);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.listBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "Form1";
      this.Text = "My Wallpaper Manager v1.0.0";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button4;
  }
}

