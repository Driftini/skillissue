
namespace SkillIssue
{
    partial class frmGame
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
            this.tmGameLoop = new System.Windows.Forms.Timer(this.components);
            this.tmResetFPSstep = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmGameLoop
            // 
            this.tmGameLoop.Enabled = true;
            this.tmGameLoop.Interval = 16;
            this.tmGameLoop.Tick += new System.EventHandler(this.tmGameLoop_Tick);
            // 
            // tmResetFPSstep
            // 
            this.tmResetFPSstep.Enabled = true;
            this.tmResetFPSstep.Interval = 1000;
            this.tmResetFPSstep.Tick += new System.EventHandler(this.tmResetFPSstep_Tick);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 161);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGame";
            this.Text = "Skill Issue";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmGame_MouseDown);
            this.MouseEnter += new System.EventHandler(this.frmGame_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.frmGame_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmGame_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmGameLoop;
        private System.Windows.Forms.Timer tmResetFPSstep;
    }
}

