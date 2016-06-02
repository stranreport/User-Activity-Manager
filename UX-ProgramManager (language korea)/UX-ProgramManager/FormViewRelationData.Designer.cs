namespace UX_ProgramManager
{
    partial class FormViewRelationData
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
            this.comboBoxID_NAME = new System.Windows.Forms.ComboBox();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.radioButtonBm = new System.Windows.Forms.RadioButton();
            this.radioButtonPc = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxMODE = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewData = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.groupBoxMODE.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxID_NAME
            // 
            this.comboBoxID_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxID_NAME.FormattingEnabled = true;
            this.comboBoxID_NAME.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxID_NAME.Location = new System.Drawing.Point(6, 30);
            this.comboBoxID_NAME.Name = "comboBoxID_NAME";
            this.comboBoxID_NAME.Size = new System.Drawing.Size(340, 20);
            this.comboBoxID_NAME.TabIndex = 0;
            this.comboBoxID_NAME.SelectedIndexChanged += new System.EventHandler(this.comboBoxID_NAME_SelectedIndexChanged);
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(524, 510);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 1;
            this.buttonCancle.Text = "닫기";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // radioButtonBm
            // 
            this.radioButtonBm.AutoSize = true;
            this.radioButtonBm.Font = new System.Drawing.Font("굴림", 10F);
            this.radioButtonBm.Location = new System.Drawing.Point(0, 22);
            this.radioButtonBm.Name = "radioButtonBm";
            this.radioButtonBm.Size = new System.Drawing.Size(95, 18);
            this.radioButtonBm.TabIndex = 2;
            this.radioButtonBm.TabStop = true;
            this.radioButtonBm.Text = "MODE BM";
            this.radioButtonBm.UseVisualStyleBackColor = true;
            this.radioButtonBm.CheckedChanged += new System.EventHandler(this.radioButtonBm_CheckedChanged);
            // 
            // radioButtonPc
            // 
            this.radioButtonPc.AutoSize = true;
            this.radioButtonPc.Font = new System.Drawing.Font("굴림", 10F);
            this.radioButtonPc.Location = new System.Drawing.Point(0, 46);
            this.radioButtonPc.Name = "radioButtonPc";
            this.radioButtonPc.Size = new System.Drawing.Size(93, 18);
            this.radioButtonPc.TabIndex = 3;
            this.radioButtonPc.TabStop = true;
            this.radioButtonPc.Text = "MODE PC";
            this.radioButtonPc.UseVisualStyleBackColor = true;
            this.radioButtonPc.CheckedChanged += new System.EventHandler(this.radioButtonPc_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "연관값 통계 뷰";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBoxMODE);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 128);
            this.panel1.TabIndex = 5;
            // 
            // groupBoxMODE
            // 
            this.groupBoxMODE.Controls.Add(this.radioButtonBm);
            this.groupBoxMODE.Controls.Add(this.radioButtonPc);
            this.groupBoxMODE.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBoxMODE.Font = new System.Drawing.Font("굴림", 10F);
            this.groupBoxMODE.Location = new System.Drawing.Point(106, 54);
            this.groupBoxMODE.Name = "groupBoxMODE";
            this.groupBoxMODE.Size = new System.Drawing.Size(97, 71);
            this.groupBoxMODE.TabIndex = 8;
            this.groupBoxMODE.TabStop = false;
            this.groupBoxMODE.Text = "모드 선택";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxID_NAME);
            this.panel2.Location = new System.Drawing.Point(12, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 60);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID - 이름";
            // 
            // listViewData
            // 
            this.listViewData.FullRowSelect = true;
            this.listViewData.Location = new System.Drawing.Point(12, 212);
            this.listViewData.Name = "listViewData";
            this.listViewData.Size = new System.Drawing.Size(587, 292);
            this.listViewData.TabIndex = 7;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            // 
            // FormViewRelationData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(611, 545);
            this.Controls.Add(this.listViewData);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancle);
            this.Name = "FormViewRelationData";
            this.Text = "FormViewRelationData";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxMODE.ResumeLayout(false);
            this.groupBoxMODE.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxID_NAME;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.RadioButton radioButtonBm;
        private System.Windows.Forms.RadioButton radioButtonPc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.GroupBox groupBoxMODE;
    }
}