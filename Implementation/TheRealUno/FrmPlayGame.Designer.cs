namespace TheRealUno {
  partial class FrmPlayGame {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.lblCpu = new System.Windows.Forms.Label();
      this.lblPlayer = new System.Windows.Forms.Label();
      this.pbDiscard = new System.Windows.Forms.PictureBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.pbDeck = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbDiscard)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
      this.SuspendLayout();
      // 
      // lblCpu
      // 
      this.lblCpu.AutoSize = true;
      this.lblCpu.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCpu.ForeColor = System.Drawing.Color.White;
      this.lblCpu.Location = new System.Drawing.Point(34, 78);
      this.lblCpu.Name = "lblCpu";
      this.lblCpu.Size = new System.Drawing.Size(52, 30);
      this.lblCpu.TabIndex = 11;
      this.lblCpu.Text = "CPU";
      // 
      // lblPlayer
      // 
      this.lblPlayer.AutoSize = true;
      this.lblPlayer.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPlayer.ForeColor = System.Drawing.Color.White;
      this.lblPlayer.Location = new System.Drawing.Point(10, 499);
      this.lblPlayer.Name = "lblPlayer";
      this.lblPlayer.Size = new System.Drawing.Size(76, 30);
      this.lblPlayer.TabIndex = 12;
      this.lblPlayer.Text = "Player";
      // 
      // pbDiscard
      // 
      this.pbDiscard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pbDiscard.Location = new System.Drawing.Point(381, 225);
      this.pbDiscard.Name = "pbDiscard";
      this.pbDiscard.Size = new System.Drawing.Size(107, 135);
      this.pbDiscard.TabIndex = 13;
      this.pbDiscard.TabStop = false;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImage = global::TheRealUno.Properties.Resources.card_back;
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Location = new System.Drawing.Point(207, 225);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(107, 135);
      this.pictureBox1.TabIndex = 14;
      this.pictureBox1.TabStop = false;
      // 
      // pictureBox2
      // 
      this.pictureBox2.BackgroundImage = global::TheRealUno.Properties.Resources.card_back;
      this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox2.Location = new System.Drawing.Point(210, 222);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(107, 135);
      this.pictureBox2.TabIndex = 15;
      this.pictureBox2.TabStop = false;
      // 
      // pictureBox3
      // 
      this.pictureBox3.BackgroundImage = global::TheRealUno.Properties.Resources.card_back;
      this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox3.Location = new System.Drawing.Point(213, 219);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(107, 135);
      this.pictureBox3.TabIndex = 16;
      this.pictureBox3.TabStop = false;
      // 
      // pbDeck
      // 
      this.pbDeck.BackgroundImage = global::TheRealUno.Properties.Resources.card_back;
      this.pbDeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pbDeck.Location = new System.Drawing.Point(216, 216);
      this.pbDeck.Name = "pbDeck";
      this.pbDeck.Size = new System.Drawing.Size(107, 135);
      this.pbDeck.TabIndex = 17;
      this.pbDeck.TabStop = false;
      this.pbDeck.Click += new System.EventHandler(this.pbDeck_Click);
      // 
      // FrmPlayGame
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DarkGray;
      this.ClientSize = new System.Drawing.Size(940, 603);
      this.Controls.Add(this.pbDeck);
      this.Controls.Add(this.pictureBox3);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.pbDiscard);
      this.Controls.Add(this.lblPlayer);
      this.Controls.Add(this.lblCpu);
      this.Name = "FrmPlayGame";
      this.Text = "Play UNO!";
      this.Load += new System.EventHandler(this.FrmPlayGame_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pbDiscard)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblCpu;
    private System.Windows.Forms.Label lblPlayer;
    private System.Windows.Forms.PictureBox pbDiscard;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.PictureBox pbDeck;
  }
}