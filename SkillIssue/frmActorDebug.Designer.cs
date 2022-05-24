namespace SkillIssue
{
    partial class frmActorDebug
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
            this.btAddActor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudSpawnCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudActorSize_Y = new System.Windows.Forms.NumericUpDown();
            this.nudActorSize_X = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudActorPosition_Y = new System.Windows.Forms.NumericUpDown();
            this.nudActorPosition_X = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nudZITesterMoveTarget = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbActorZIndex = new System.Windows.Forms.ComboBox();
            this.nudActorSpeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbActorType = new System.Windows.Forms.ComboBox();
            this.nudRemoveID = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btRemoveActor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorSize_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorSize_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorPosition_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorPosition_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZITesterMoveTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemoveID)).BeginInit();
            this.SuspendLayout();
            // 
            // btAddActor
            // 
            this.btAddActor.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAddActor.Location = new System.Drawing.Point(221, 370);
            this.btAddActor.Name = "btAddActor";
            this.btAddActor.Size = new System.Drawing.Size(87, 20);
            this.btAddActor.TabIndex = 1;
            this.btAddActor.Text = "Add actor";
            this.btAddActor.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.nudSpawnCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.nudActorSize_Y);
            this.groupBox1.Controls.Add(this.btAddActor);
            this.groupBox1.Controls.Add(this.nudActorSize_X);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nudActorPosition_Y);
            this.groupBox1.Controls.Add(this.nudActorPosition_X);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.nudZITesterMoveTarget);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbActorZIndex);
            this.groupBox1.Controls.Add(this.nudActorSpeed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbActorType);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 397);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Actors";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(248, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Y";
            // 
            // nudSpawnCount
            // 
            this.nudSpawnCount.Location = new System.Drawing.Point(114, 371);
            this.nudSpawnCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSpawnCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpawnCount.Name = "nudSpawnCount";
            this.nudSpawnCount.Size = new System.Drawing.Size(101, 20);
            this.nudSpawnCount.TabIndex = 4;
            this.nudSpawnCount.ThousandsSeparator = true;
            this.nudSpawnCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Count";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(182, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "X";
            // 
            // nudActorSize_Y
            // 
            this.nudActorSize_Y.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudActorSize_Y.Location = new System.Drawing.Point(264, 71);
            this.nudActorSize_Y.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudActorSize_Y.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudActorSize_Y.Name = "nudActorSize_Y";
            this.nudActorSize_Y.Size = new System.Drawing.Size(42, 20);
            this.nudActorSize_Y.TabIndex = 20;
            this.nudActorSize_Y.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // nudActorSize_X
            // 
            this.nudActorSize_X.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudActorSize_X.Location = new System.Drawing.Point(197, 71);
            this.nudActorSize_X.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudActorSize_X.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudActorSize_X.Name = "nudActorSize_X";
            this.nudActorSize_X.Size = new System.Drawing.Size(42, 20);
            this.nudActorSize_X.TabIndex = 19;
            this.nudActorSize_X.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(248, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "X";
            // 
            // nudActorPosition_Y
            // 
            this.nudActorPosition_Y.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudActorPosition_Y.Location = new System.Drawing.Point(264, 45);
            this.nudActorPosition_Y.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudActorPosition_Y.Name = "nudActorPosition_Y";
            this.nudActorPosition_Y.Size = new System.Drawing.Size(42, 20);
            this.nudActorPosition_Y.TabIndex = 16;
            this.nudActorPosition_Y.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // nudActorPosition_X
            // 
            this.nudActorPosition_X.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudActorPosition_X.Location = new System.Drawing.Point(197, 45);
            this.nudActorPosition_X.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.nudActorPosition_X.Name = "nudActorPosition_X";
            this.nudActorPosition_X.Size = new System.Drawing.Size(42, 20);
            this.nudActorPosition_X.TabIndex = 5;
            this.nudActorPosition_X.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(9, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 1);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // nudZITesterMoveTarget
            // 
            this.nudZITesterMoveTarget.Location = new System.Drawing.Point(185, 157);
            this.nudZITesterMoveTarget.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudZITesterMoveTarget.Name = "nudZITesterMoveTarget";
            this.nudZITesterMoveTarget.Size = new System.Drawing.Size(121, 20);
            this.nudZITesterMoveTarget.TabIndex = 14;
            this.nudZITesterMoveTarget.ValueChanged += new System.EventHandler(this.ValidateInput);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "ZIndexTester: Move target";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Z-Index";
            // 
            // cbActorZIndex
            // 
            this.cbActorZIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActorZIndex.FormattingEnabled = true;
            this.cbActorZIndex.Location = new System.Drawing.Point(185, 123);
            this.cbActorZIndex.Name = "cbActorZIndex";
            this.cbActorZIndex.Size = new System.Drawing.Size(121, 21);
            this.cbActorZIndex.TabIndex = 10;
            this.cbActorZIndex.SelectedIndexChanged += new System.EventHandler(this.ValidateInput);
            // 
            // nudActorSpeed
            // 
            this.nudActorSpeed.DecimalPlaces = 10;
            this.nudActorSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.nudActorSpeed.Location = new System.Drawing.Point(185, 97);
            this.nudActorSpeed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudActorSpeed.Name = "nudActorSpeed";
            this.nudActorSpeed.Size = new System.Drawing.Size(121, 20);
            this.nudActorSpeed.TabIndex = 9;
            this.nudActorSpeed.ValueChanged += new System.EventHandler(this.ValidateInput);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Speed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type";
            // 
            // cbActorType
            // 
            this.cbActorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActorType.FormattingEnabled = true;
            this.cbActorType.Location = new System.Drawing.Point(185, 17);
            this.cbActorType.Name = "cbActorType";
            this.cbActorType.Size = new System.Drawing.Size(121, 21);
            this.cbActorType.TabIndex = 2;
            this.cbActorType.SelectedIndexChanged += new System.EventHandler(this.ValidateInput);
            // 
            // nudRemoveID
            // 
            this.nudRemoveID.Location = new System.Drawing.Point(126, 415);
            this.nudRemoveID.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudRemoveID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRemoveID.Name = "nudRemoveID";
            this.nudRemoveID.Size = new System.Drawing.Size(101, 20);
            this.nudRemoveID.TabIndex = 25;
            this.nudRemoveID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 418);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Remove actor by ID";
            // 
            // btRemoveActor
            // 
            this.btRemoveActor.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btRemoveActor.Location = new System.Drawing.Point(233, 414);
            this.btRemoveActor.Name = "btRemoveActor";
            this.btRemoveActor.Size = new System.Drawing.Size(87, 20);
            this.btRemoveActor.TabIndex = 23;
            this.btRemoveActor.Text = "Remove actor";
            this.btRemoveActor.UseVisualStyleBackColor = true;
            // 
            // frmActorDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 450);
            this.Controls.Add(this.nudRemoveID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btRemoveActor);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActorDebug";
            this.ShowIcon = false;
            this.Text = "Actor De/spawner";
            this.Load += new System.EventHandler(this.frmActorDebug_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorSize_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorSize_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorPosition_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorPosition_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZITesterMoveTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActorSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemoveID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btAddActor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbActorType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudActorSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbActorZIndex;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown nudZITesterMoveTarget;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSpawnCount;
        private System.Windows.Forms.NumericUpDown nudActorPosition_X;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudActorPosition_Y;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudActorSize_Y;
        private System.Windows.Forms.NumericUpDown nudActorSize_X;
        private System.Windows.Forms.NumericUpDown nudRemoveID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btRemoveActor;
    }
}