namespace UX_ProgramManager
{
    partial class FormViewGroup
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
            this.buttonEnd = new System.Windows.Forms.Button();
            this.listViewGroup = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKill = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(760, 442);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(75, 23);
            this.buttonEnd.TabIndex = 0;
            this.buttonEnd.Text = "닫기";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // listViewGroup
            // 
            this.listViewGroup.FullRowSelect = true;
            this.listViewGroup.Location = new System.Drawing.Point(14, 63);
            this.listViewGroup.Name = "listViewGroup";
            this.listViewGroup.Size = new System.Drawing.Size(823, 373);
            this.listViewGroup.TabIndex = 1;
            this.listViewGroup.UseCompatibleStateImageBehavior = false;
            this.listViewGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.change_focus_view);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "선택한 그룹의 소속 프로세스";
            // 
            // buttonKill
            // 
            this.buttonKill.Location = new System.Drawing.Point(584, 442);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(170, 23);
            this.buttonKill.TabIndex = 3;
            this.buttonKill.Text = "제거하고 무시목록에 추가";
            this.buttonKill.UseVisualStyleBackColor = true;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "○그룹에 소속된 프로세스를 제거 할 수 있습니다";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(504, 442);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 5;
            this.buttonRun.Text = "개별 실행";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // FormViewGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(848, 477);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonKill);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewGroup);
            this.Controls.Add(this.buttonEnd);
            this.Name = "FormViewGroup";
            this.Text = "FormViewGroup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.ListView listViewGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRun;
    }
}