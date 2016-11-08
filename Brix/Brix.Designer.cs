namespace Brix
{
    partial class Brix
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ball = new System.Windows.Forms.PictureBox();
            this.pad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pad)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Transparent;
            this.ball.Image = global::Brix.Properties.Resources.big1;
            this.ball.Location = new System.Drawing.Point(241, 386);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(20, 20);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // pad
            // 
            this.pad.Image = global::Brix.Properties.Resources.pad;
            this.pad.Location = new System.Drawing.Point(205, 412);
            this.pad.Name = "pad";
            this.pad.Size = new System.Drawing.Size(90, 15);
            this.pad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pad.TabIndex = 1;
            this.pad.TabStop = false;
            // 
            // Brix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(573, 439);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.pad);
            this.Name = "Brix";
            this.ShowIcon = false;
            this.Text = "Brix";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Brix_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Brix_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pad;
        private System.Windows.Forms.PictureBox ball;
    }
}

