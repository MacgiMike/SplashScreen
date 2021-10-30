
namespace SplashScreen
{
    partial class SplashScreenWindow
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
            this.lblTextBlock1 = new System.Windows.Forms.Label();
            this.lblTextBlock2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTextBlock1
            // 
            this.lblTextBlock1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextBlock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTextBlock1.Location = new System.Drawing.Point(12, 193);
            this.lblTextBlock1.Name = "lblTextBlock1";
            this.lblTextBlock1.Size = new System.Drawing.Size(776, 72);
            this.lblTextBlock1.TabIndex = 0;
            this.lblTextBlock1.Text = "Text block 1";
            this.lblTextBlock1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTextBlock2
            // 
            this.lblTextBlock2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextBlock2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTextBlock2.Location = new System.Drawing.Point(12, 359);
            this.lblTextBlock2.Name = "lblTextBlock2";
            this.lblTextBlock2.Size = new System.Drawing.Size(776, 72);
            this.lblTextBlock2.TabIndex = 1;
            this.lblTextBlock2.Text = "Text block 2";
            this.lblTextBlock2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashScreenWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTextBlock2);
            this.Controls.Add(this.lblTextBlock1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreenWindow";
            this.Text = "SplashScreenWindow";
            this.Load += new System.EventHandler(this.SplashScreenWindow_Load);
            this.DoubleClick += new System.EventHandler(this.Splash_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTextBlock1;
        private System.Windows.Forms.Label lblTextBlock2;
    }
}