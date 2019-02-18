namespace TheRealUno
{
    partial class FrmActionCard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.COLOR_YELLOW = new System.Windows.Forms.Button();
            this.COLOR_RED = new System.Windows.Forms.Button();
            this.COLOR_GREEN = new System.Windows.Forms.Button();
            this.COLOR_BLUE = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.COLOR_YELLOW);
            this.groupBox1.Controls.Add(this.COLOR_RED);
            this.groupBox1.Controls.Add(this.COLOR_GREEN);
            this.groupBox1.Controls.Add(this.COLOR_BLUE);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLEASE CHOOSE A COLOR";
            // 
            // COLOR_YELLOW
            // 
            this.COLOR_YELLOW.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.COLOR_YELLOW.ForeColor = System.Drawing.Color.Yellow;
            this.COLOR_YELLOW.Location = new System.Drawing.Point(146, 87);
            this.COLOR_YELLOW.Name = "COLOR_YELLOW";
            this.COLOR_YELLOW.Size = new System.Drawing.Size(75, 23);
            this.COLOR_YELLOW.TabIndex = 5;
            this.COLOR_YELLOW.Text = "YELLOW";
            this.COLOR_YELLOW.UseVisualStyleBackColor = true;
            this.COLOR_YELLOW.Click += new System.EventHandler(this.COLOR_YELLOW_Click);
            // 
            // COLOR_RED
            // 
            this.COLOR_RED.BackColor = System.Drawing.SystemColors.Control;
            this.COLOR_RED.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.COLOR_RED.ForeColor = System.Drawing.Color.Red;
            this.COLOR_RED.Location = new System.Drawing.Point(6, 33);
            this.COLOR_RED.Name = "COLOR_RED";
            this.COLOR_RED.Size = new System.Drawing.Size(75, 23);
            this.COLOR_RED.TabIndex = 3;
            this.COLOR_RED.Text = "RED";
            this.COLOR_RED.UseVisualStyleBackColor = false;
            this.COLOR_RED.Click += new System.EventHandler(this.COLOR_RED_Click);
            // 
            // COLOR_GREEN
            // 
            this.COLOR_GREEN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.COLOR_GREEN.ForeColor = System.Drawing.Color.Green;
            this.COLOR_GREEN.Location = new System.Drawing.Point(146, 33);
            this.COLOR_GREEN.Name = "COLOR_GREEN";
            this.COLOR_GREEN.Size = new System.Drawing.Size(75, 23);
            this.COLOR_GREEN.TabIndex = 2;
            this.COLOR_GREEN.Text = "GREEN";
            this.COLOR_GREEN.UseVisualStyleBackColor = true;
            this.COLOR_GREEN.Click += new System.EventHandler(this.COLOR_GREEN_Click);
            // 
            // COLOR_BLUE
            // 
            this.COLOR_BLUE.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.COLOR_BLUE.ForeColor = System.Drawing.Color.Blue;
            this.COLOR_BLUE.Location = new System.Drawing.Point(6, 87);
            this.COLOR_BLUE.Name = "COLOR_BLUE";
            this.COLOR_BLUE.Size = new System.Drawing.Size(75, 23);
            this.COLOR_BLUE.TabIndex = 1;
            this.COLOR_BLUE.Text = "BLUE";
            this.COLOR_BLUE.UseVisualStyleBackColor = true;
            this.COLOR_BLUE.Click += new System.EventHandler(this.COLOR_BLUE_Click_1);
            // 
            // FrmActionCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(271, 158);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmActionCard";
            this.Text = "WILD CARD - NEW COLOR";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button COLOR_RED;
        private System.Windows.Forms.Button COLOR_GREEN;
        private System.Windows.Forms.Button COLOR_BLUE;
        private System.Windows.Forms.Button COLOR_YELLOW;
    }
}