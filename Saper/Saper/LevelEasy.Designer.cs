
namespace Saper
{
    partial class LevelEasy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEasy));
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgPic = new System.Windows.Forms.ImageList(this.components);
            this.howManyFlags = new System.Windows.Forms.Label();
            this.ileempty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(242, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 40);
            this.label1.TabIndex = 64;
            this.label1.Text = "00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(50, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 240);
            this.panel1.TabIndex = 65;
            // 
            // imgPic
            // 
            this.imgPic.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPic.ImageStream")));
            this.imgPic.TransparentColor = System.Drawing.Color.Transparent;
            this.imgPic.Images.SetKeyName(0, "uncoveredTile.png");
            this.imgPic.Images.SetKeyName(1, "1.png");
            this.imgPic.Images.SetKeyName(2, "2.png");
            this.imgPic.Images.SetKeyName(3, "3.png");
            this.imgPic.Images.SetKeyName(4, "4.png");
            this.imgPic.Images.SetKeyName(5, "5.png");
            this.imgPic.Images.SetKeyName(6, "6.png");
            this.imgPic.Images.SetKeyName(7, "7.png");
            this.imgPic.Images.SetKeyName(8, "8.png");
            this.imgPic.Images.SetKeyName(9, "coveredTile.png");
            this.imgPic.Images.SetKeyName(10, "flag.png");
            this.imgPic.Images.SetKeyName(11, "mine.png");
            this.imgPic.Images.SetKeyName(12, "redMine.png");
            this.imgPic.Images.SetKeyName(13, "wrongFlag.png");
            // 
            // howManyFlags
            // 
            this.howManyFlags.AutoSize = true;
            this.howManyFlags.Location = new System.Drawing.Point(31, 35);
            this.howManyFlags.Name = "howManyFlags";
            this.howManyFlags.Size = new System.Drawing.Size(35, 13);
            this.howManyFlags.TabIndex = 66;
            this.howManyFlags.Text = "label2";
            // 
            // ileempty
            // 
            this.ileempty.AutoSize = true;
            this.ileempty.Location = new System.Drawing.Point(139, 36);
            this.ileempty.Name = "ileempty";
            this.ileempty.Size = new System.Drawing.Size(35, 13);
            this.ileempty.TabIndex = 67;
            this.ileempty.Text = "label2";
            // 
            // LevelEasy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(344, 492);
            this.Controls.Add(this.ileempty);
            this.Controls.Add(this.howManyFlags);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "LevelEasy";
            this.Text = "LevelEasy";
            this.Load += new System.EventHandler(this.LevelEasy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imgPic;
        private System.Windows.Forms.Label howManyFlags;
        private System.Windows.Forms.Label ileempty;
    }
}