using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UX_ProgramManager.manageData;

namespace UX_ProgramManager
{
    public partial class FormTimeTable : Form
    {     
        //모듈
        moduleData mDat = new moduleData();
        moduleRun mRun = new moduleRun();
        bool focusOn = false;

        public FormTimeTable()
        {
            InitializeComponent();            
            setupTimeView();

        }

        //모든뷰 기초설정 등록 Bm
        private void setupTimeView()
        {            
            listViewTimeTable.BeginUpdate();
            listViewTimeTable.Clear();
            listViewTimeTable.View = View.Details;
            listViewTimeTable.Columns.Add("ID");
            listViewTimeTable.Columns.Add("이름");
            listViewTimeTable.Columns.Add("경로");
            listViewTimeTable.Columns.Add("종류");
            listViewTimeTable.Columns[0].Width = 50;
            listViewTimeTable.Columns[1].Width = 150;
            listViewTimeTable.Columns[2].Width = 70;
            listViewTimeTable.Columns[3].Width = 80;
            listViewTimeTable.EndUpdate();            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            focusOn = false;
            setupTimeView();
            mDat.setupTimeTableList(listViewTimeTable, "1");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            focusOn = false;
            setupTimeView();
            mDat.setupTimeTableList(listViewTimeTable, "2");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            focusOn = false;
            setupTimeView();
            mDat.setupTimeTableList(listViewTimeTable, "3");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            focusOn = false;
            setupTimeView();
            mDat.setupTimeTableList(listViewTimeTable, "4");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            focusOn = false;
            setupTimeView();
            mDat.setupTimeTableList(listViewTimeTable, "5");
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            focusOn = false;
            setupTimeView();
            mDat.setupTimeTableList(listViewTimeTable, "6");
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            focusOn = false;
            setupTimeView();
            mDat.setupTimeTableList(listViewTimeTable, "7");
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            focusOn = false;
            setupTimeView();
            mDat.setupTimeTableList(listViewTimeTable, "8");
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if(focusOn == true)
            {
                string t_path = listViewTimeTable.FocusedItem.SubItems[2].Text;
                string t_type = listViewTimeTable.FocusedItem.SubItems[3].Text;
                mRun.runBase(t_path, t_type);//실행
            }
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void focus_on_list(object sender, MouseEventArgs e)
        {
            focusOn = true;
        }
    }
}
