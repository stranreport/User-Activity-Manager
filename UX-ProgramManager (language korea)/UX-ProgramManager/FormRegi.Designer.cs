namespace UX_ProgramManager
{
    partial class FormRegi
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProg = new System.Windows.Forms.TextBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.textBoxWeb = new System.Windows.Forms.TextBox();
            this.buttonBrowProg = new System.Windows.Forms.Button();
            this.buttonBrowFolder = new System.Windows.Forms.Button();
            this.radioButtonProg = new System.Windows.Forms.RadioButton();
            this.radioButtonFolder = new System.Windows.Forms.RadioButton();
            this.radioButtonWeb = new System.Windows.Forms.RadioButton();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(478, 238);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "생성";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(559, 238);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 1;
            this.buttonCancle.Text = "취소";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "○응용 프로그램, 폴더, 웹사이트를 등록 할 수 있습니다";
            // 
            // textBoxProg
            // 
            this.textBoxProg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProg.Enabled = false;
            this.textBoxProg.Location = new System.Drawing.Point(12, 91);
            this.textBoxProg.Name = "textBoxProg";
            this.textBoxProg.Size = new System.Drawing.Size(263, 21);
            this.textBoxProg.TabIndex = 3;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFolder.Enabled = false;
            this.textBoxFolder.Location = new System.Drawing.Point(12, 164);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(263, 21);
            this.textBoxFolder.TabIndex = 4;
            // 
            // textBoxWeb
            // 
            this.textBoxWeb.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxWeb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxWeb.Enabled = false;
            this.textBoxWeb.Location = new System.Drawing.Point(12, 238);
            this.textBoxWeb.Name = "textBoxWeb";
            this.textBoxWeb.Size = new System.Drawing.Size(344, 21);
            this.textBoxWeb.TabIndex = 5;
            // 
            // buttonBrowProg
            // 
            this.buttonBrowProg.Location = new System.Drawing.Point(281, 91);
            this.buttonBrowProg.Name = "buttonBrowProg";
            this.buttonBrowProg.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowProg.TabIndex = 9;
            this.buttonBrowProg.Text = "찾기";
            this.buttonBrowProg.UseVisualStyleBackColor = true;
            this.buttonBrowProg.Click += new System.EventHandler(this.buttonBrowProg_Click);
            // 
            // buttonBrowFolder
            // 
            this.buttonBrowFolder.Location = new System.Drawing.Point(281, 164);
            this.buttonBrowFolder.Name = "buttonBrowFolder";
            this.buttonBrowFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowFolder.TabIndex = 10;
            this.buttonBrowFolder.Text = "찾기";
            this.buttonBrowFolder.UseVisualStyleBackColor = true;
            this.buttonBrowFolder.Click += new System.EventHandler(this.buttonBrowFolder_Click);
            // 
            // radioButtonProg
            // 
            this.radioButtonProg.AutoSize = true;
            this.radioButtonProg.Location = new System.Drawing.Point(12, 69);
            this.radioButtonProg.Name = "radioButtonProg";
            this.radioButtonProg.Size = new System.Drawing.Size(75, 16);
            this.radioButtonProg.TabIndex = 11;
            this.radioButtonProg.TabStop = true;
            this.radioButtonProg.Text = "파일 등록";
            this.radioButtonProg.UseVisualStyleBackColor = true;
            this.radioButtonProg.CheckedChanged += new System.EventHandler(this.radioButtonProg_CheckedChanged);
            // 
            // radioButtonFolder
            // 
            this.radioButtonFolder.AutoSize = true;
            this.radioButtonFolder.Location = new System.Drawing.Point(12, 142);
            this.radioButtonFolder.Name = "radioButtonFolder";
            this.radioButtonFolder.Size = new System.Drawing.Size(75, 16);
            this.radioButtonFolder.TabIndex = 12;
            this.radioButtonFolder.TabStop = true;
            this.radioButtonFolder.Text = "폴더 등록";
            this.radioButtonFolder.UseVisualStyleBackColor = true;
            this.radioButtonFolder.CheckedChanged += new System.EventHandler(this.radioButtonFolder_CheckedChanged);
            // 
            // radioButtonWeb
            // 
            this.radioButtonWeb.AutoSize = true;
            this.radioButtonWeb.Location = new System.Drawing.Point(12, 216);
            this.radioButtonWeb.Name = "radioButtonWeb";
            this.radioButtonWeb.Size = new System.Drawing.Size(257, 16);
            this.radioButtonWeb.TabIndex = 13;
            this.radioButtonWeb.TabStop = true;
            this.radioButtonWeb.Text = "사이트 등록 (페이지 프로토콜을 적어야 함)";
            this.radioButtonWeb.UseVisualStyleBackColor = true;
            this.radioButtonWeb.CheckedChanged += new System.EventHandler(this.radioButtonWeb_CheckedChanged);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(439, 93);
            this.textBoxInfo.MaxLength = 40;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(195, 21);
            this.textBoxInfo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "등록 이름";
            // 
            // FormRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(646, 290);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.radioButtonWeb);
            this.Controls.Add(this.radioButtonFolder);
            this.Controls.Add(this.radioButtonProg);
            this.Controls.Add(this.buttonBrowFolder);
            this.Controls.Add(this.buttonBrowProg);
            this.Controls.Add(this.textBoxWeb);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.textBoxProg);
            this.Controls.Add(this.label1);
            this.Name = "FormRegi";
            this.Text = "FormRegistration";
            this.Load += new System.EventHandler(this.FormRegi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProg;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.TextBox textBoxWeb;
        private System.Windows.Forms.Button buttonBrowProg;
        private System.Windows.Forms.Button buttonBrowFolder;
        private System.Windows.Forms.RadioButton radioButtonProg;
        private System.Windows.Forms.RadioButton radioButtonFolder;
        private System.Windows.Forms.RadioButton radioButtonWeb;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Label label2;
    }
}