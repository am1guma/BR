namespace BRaVO
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.b1 = new System.Windows.Forms.ToolStripButton();
            this.b2 = new System.Windows.Forms.ToolStripButton();
            this.b3 = new System.Windows.Forms.ToolStripButton();
            this.b4 = new System.Windows.Forms.ToolStripButton();
            this.b5 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1276, 773);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.b1,
            this.b2,
            this.b3,
            this.b4,
            this.b5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(162, 773);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // b1
            // 
            this.b1.Image = ((System.Drawing.Image)(resources.GetObject("b1.Image")));
            this.b1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(159, 59);
            this.b1.Text = "Spatiu&Obstacol";
            this.b1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b1.ToolTipText = "Spatiul de lucru si obstacole";
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // b2
            // 
            this.b2.Image = ((System.Drawing.Image)(resources.GetObject("b2.Image")));
            this.b2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(159, 59);
            this.b2.Text = "Start&Stop";
            this.b2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b2.ToolTipText = "Punct de start si de stop";
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // b3
            // 
            this.b3.Image = ((System.Drawing.Image)(resources.GetObject("b3.Image")));
            this.b3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(159, 59);
            this.b3.Text = "DescompunereTriunghiulara";
            this.b3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b3.ToolTipText = "Drumul optim";
            this.b3.Click += new System.EventHandler(this.b3_Click);
            // 
            // b4
            // 
            this.b4.Image = ((System.Drawing.Image)(resources.GetObject("b4.Image")));
            this.b4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(159, 59);
            this.b4.Text = "DescopunereTrapezoidala";
            this.b4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b4.Click += new System.EventHandler(this.b4_Click);
            // 
            // b5
            // 
            this.b5.Image = ((System.Drawing.Image)(resources.GetObject("b5.Image")));
            this.b5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(159, 59);
            this.b5.Text = "Reseteaza";
            this.b5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b5.Click += new System.EventHandler(this.b5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Metoda descompunerii poligonale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton b1;
        private System.Windows.Forms.ToolStripButton b2;
        private System.Windows.Forms.ToolStripButton b3;
        private System.Windows.Forms.ToolStripButton b4;
        private System.Windows.Forms.ToolStripButton b5;
    }
}

