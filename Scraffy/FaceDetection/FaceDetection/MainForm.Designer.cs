namespace FaceDetection
{
    partial class MainForm
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
            this.captureBox = new Emgu.CV.UI.ImageBox();
            this.captureButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.captureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // captureBox
            // 
            this.captureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.captureBox.Location = new System.Drawing.Point(12, 92);
            this.captureBox.Name = "captureBox";
            this.captureBox.Size = new System.Drawing.Size(776, 487);
            this.captureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.captureBox.TabIndex = 2;
            this.captureBox.TabStop = false;
            // 
            // captureButton
            // 
            this.captureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.captureButton.Location = new System.Drawing.Point(682, 31);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(83, 35);
            this.captureButton.TabIndex = 3;
            this.captureButton.Text = "Start";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 591);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.captureBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReleaseData);
            ((System.ComponentModel.ISupportInitialize)(this.captureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox captureBox;
        private System.Windows.Forms.Button captureButton;
    }
}