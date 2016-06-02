namespace UX_ProgramManager
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewMain = new System.Windows.Forms.ListView();
            this.listViewRec = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRegiBM = new System.Windows.Forms.Button();
            this.buttonOptProg = new System.Windows.Forms.Button();
            this.buttonDeleteId = new System.Windows.Forms.Button();
            this.buttonOptProc = new System.Windows.Forms.Button();
            this.buttonChaseOn = new System.Windows.Forms.Button();
            this.buttonChaseOff = new System.Windows.Forms.Button();
            this.buttonViewIgnoreListPC = new System.Windows.Forms.Button();
            this.buttonEditGroupDat = new System.Windows.Forms.Button();
            this.buttonTimeTable = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonViewRel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMain
            // 
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(14, 78);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(560, 315);
            this.listViewMain.TabIndex = 0;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.changed_focus_main);
            // 
            // listViewRec
            // 
            this.listViewRec.FullRowSelect = true;
            this.listViewRec.HideSelection = false;
            this.listViewRec.Location = new System.Drawing.Point(12, 423);
            this.listViewRec.Name = "listViewRec";
            this.listViewRec.Size = new System.Drawing.Size(560, 144);
            this.listViewRec.TabIndex = 1;
            this.listViewRec.UseCompatibleStateImageBehavior = false;
            this.listViewRec.MouseClick += new System.Windows.Forms.MouseEventHandler(this.changed_focus_rec);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonRegiBM, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOptProg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDeleteId, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonOptProc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonChaseOn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonChaseOff, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonViewIgnoreListPC, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonEditGroupDat, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonTimeTable, 0, 3);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(610, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.38462F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.61538F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 315);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonRegiBM
            // 
            this.buttonRegiBM.Location = new System.Drawing.Point(6, 44);
            this.buttonRegiBM.Name = "buttonRegiBM";
            this.buttonRegiBM.Size = new System.Drawing.Size(108, 45);
            this.buttonRegiBM.TabIndex = 4;
            this.buttonRegiBM.Text = "북마크 등록";
            this.buttonRegiBM.UseVisualStyleBackColor = true;
            this.buttonRegiBM.Click += new System.EventHandler(this.buttonRegiBM_Click);
            // 
            // buttonOptProg
            // 
            this.buttonOptProg.Location = new System.Drawing.Point(6, 6);
            this.buttonOptProg.Name = "buttonOptProg";
            this.buttonOptProg.Size = new System.Drawing.Size(108, 29);
            this.buttonOptProg.TabIndex = 2;
            this.buttonOptProg.Text = "북마크 모드";
            this.buttonOptProg.UseVisualStyleBackColor = true;
            this.buttonOptProg.Click += new System.EventHandler(this.buttonOptProg_Click);
            // 
            // buttonDeleteId
            // 
            this.buttonDeleteId.Location = new System.Drawing.Point(6, 98);
            this.buttonDeleteId.Name = "buttonDeleteId";
            this.buttonDeleteId.Size = new System.Drawing.Size(108, 59);
            this.buttonDeleteId.TabIndex = 8;
            this.buttonDeleteId.Text = "북마크 삭제";
            this.buttonDeleteId.UseVisualStyleBackColor = true;
            this.buttonDeleteId.Click += new System.EventHandler(this.buttonDeleteId_Click);
            // 
            // buttonOptProc
            // 
            this.buttonOptProc.Location = new System.Drawing.Point(123, 6);
            this.buttonOptProc.Name = "buttonOptProc";
            this.buttonOptProc.Size = new System.Drawing.Size(109, 29);
            this.buttonOptProc.TabIndex = 3;
            this.buttonOptProc.Text = "프로세스 모드";
            this.buttonOptProc.UseVisualStyleBackColor = true;
            this.buttonOptProc.Click += new System.EventHandler(this.buttonOptProc_Click);
            // 
            // buttonChaseOn
            // 
            this.buttonChaseOn.Font = new System.Drawing.Font("굴림", 8F);
            this.buttonChaseOn.Location = new System.Drawing.Point(123, 44);
            this.buttonChaseOn.Name = "buttonChaseOn";
            this.buttonChaseOn.Size = new System.Drawing.Size(109, 45);
            this.buttonChaseOn.TabIndex = 6;
            this.buttonChaseOn.Text = "프로세스 추적 켜기";
            this.buttonChaseOn.UseVisualStyleBackColor = true;
            this.buttonChaseOn.Click += new System.EventHandler(this.buttonChaseOn_Click);
            // 
            // buttonChaseOff
            // 
            this.buttonChaseOff.Font = new System.Drawing.Font("굴림", 8F);
            this.buttonChaseOff.Location = new System.Drawing.Point(123, 98);
            this.buttonChaseOff.Name = "buttonChaseOff";
            this.buttonChaseOff.Size = new System.Drawing.Size(109, 59);
            this.buttonChaseOff.TabIndex = 7;
            this.buttonChaseOff.Text = "프로세스 추적 끄기";
            this.buttonChaseOff.UseVisualStyleBackColor = true;
            this.buttonChaseOff.Click += new System.EventHandler(this.buttonChaseOff_Click);
            // 
            // buttonViewIgnoreListPC
            // 
            this.buttonViewIgnoreListPC.Location = new System.Drawing.Point(123, 241);
            this.buttonViewIgnoreListPC.Name = "buttonViewIgnoreListPC";
            this.buttonViewIgnoreListPC.Size = new System.Drawing.Size(109, 68);
            this.buttonViewIgnoreListPC.TabIndex = 5;
            this.buttonViewIgnoreListPC.Text = "무시 목록 설정";
            this.buttonViewIgnoreListPC.UseVisualStyleBackColor = true;
            this.buttonViewIgnoreListPC.Click += new System.EventHandler(this.buttonViewPC_Click);
            // 
            // buttonEditGroupDat
            // 
            this.buttonEditGroupDat.Location = new System.Drawing.Point(123, 166);
            this.buttonEditGroupDat.Name = "buttonEditGroupDat";
            this.buttonEditGroupDat.Size = new System.Drawing.Size(109, 65);
            this.buttonEditGroupDat.TabIndex = 0;
            this.buttonEditGroupDat.Text = "  선택 그룹 정보     편집";
            this.buttonEditGroupDat.UseVisualStyleBackColor = true;
            this.buttonEditGroupDat.Click += new System.EventHandler(this.buttonViewDat_Click);
            // 
            // buttonTimeTable
            // 
            this.buttonTimeTable.Location = new System.Drawing.Point(6, 166);
            this.buttonTimeTable.Name = "buttonTimeTable";
            this.buttonTimeTable.Size = new System.Drawing.Size(108, 65);
            this.buttonTimeTable.TabIndex = 9;
            this.buttonTimeTable.Text = "실행 시간표 보기";
            this.buttonTimeTable.UseVisualStyleBackColor = true;
            this.buttonTimeTable.Click += new System.EventHandler(this.buttonTimeTable_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(613, 498);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(113, 69);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "실행";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(11, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "●추천 목록 리스트";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "●등록 리스트";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F);
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "○행동을 등록하고 관리할 수 있습니다";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(611, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "옵션";
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(770, 544);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(75, 23);
            this.buttonEnd.TabIndex = 7;
            this.buttonEnd.Text = "종료";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(441, 49);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(131, 23);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "새로고침";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonViewRel
            // 
            this.buttonViewRel.Location = new System.Drawing.Point(610, 399);
            this.buttonViewRel.Name = "buttonViewRel";
            this.buttonViewRel.Size = new System.Drawing.Size(232, 23);
            this.buttonViewRel.TabIndex = 10;
            this.buttonViewRel.Text = "관계성 기록 보기";
            this.buttonViewRel.UseVisualStyleBackColor = true;
            this.buttonViewRel.Click += new System.EventHandler(this.buttonViewRel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(860, 579);
            this.Controls.Add(this.buttonViewRel);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listViewRec);
            this.Controls.Add(this.listViewMain);
            this.Name = "FormMain";
            this.Text = "Main";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.ListView listViewRec;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonEditGroupDat;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonOptProg;
        private System.Windows.Forms.Button buttonOptProc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRegiBM;
        private System.Windows.Forms.Button buttonViewIgnoreListPC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonChaseOn;
        private System.Windows.Forms.Button buttonChaseOff;
        private System.Windows.Forms.Button buttonDeleteId;
        private System.Windows.Forms.Button buttonTimeTable;
        private System.Windows.Forms.Button buttonViewRel;
    }
}

