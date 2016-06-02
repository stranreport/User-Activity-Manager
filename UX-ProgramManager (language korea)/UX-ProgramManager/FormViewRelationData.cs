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
    public partial class FormViewRelationData : Form
    {
        //모듈
        moduleData mDat = new moduleData();

        public FormViewRelationData()
        {
            InitializeComponent();
            listViewData.View = View.Details;
            setListView();
        }

        private void comboBoxInitialize()
        {
            comboBoxID_NAME.Items.Clear();
        }
        
        private void setListView()
        {
            listViewData.BeginUpdate();
            listViewData.Clear();
            listViewData.Columns.Add("ID");
            listViewData.Columns.Add("이름");
            listViewData.Columns.Add("관계 크기");
            listViewData.Columns.Add("경로");
            listViewData.Columns.Add("종류");
            listViewData.Columns[0].Width = 50;
            listViewData.Columns[1].Width = 150;
            listViewData.Columns[2].Width = 70;
            listViewData.Columns[3].Width = 80;
            listViewData.EndUpdate();
        }


        private void radioButtonBm_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxInitialize();
            mDat.setupIdComboBox_Bm(comboBoxID_NAME);
        }

        private void radioButtonPc_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxInitialize();
            mDat.setupIdComboBox_Pc(comboBoxID_NAME);

        }

        private void comboBoxID_NAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] splitId = comboBoxID_NAME.SelectedItem.ToString().Split(new char[] { '-' });
            setListView();

            if (radioButtonBm.Checked)
            {
                mDat.setupRelDataListView_Bm(listViewData, splitId[0]);
            }
            else if (radioButtonPc.Checked)
            {
                mDat.setupRelDataListView_Pc(listViewData, splitId[0]);
            }
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
