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
    public partial class FormIgnore : Form
    {


        //모듈 로드
        moduleData mDat = new moduleData();

        public FormIgnore()
        {
            InitializeComponent();
            loadList();
        }
        private void loadList()
        {
            mDat.loadIgnoreList(ref textBoxIgnore);
        }

        private void saveList()
        {
            mDat.saveIgnoreList(textBoxIgnore);
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            Console.WriteLine(textBoxIgnore.Text);
            saveList();

            this.Close();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
