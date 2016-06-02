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
    public partial class FormRegi : Form
    {
        String id_count;
        String selectedType;

        //모듈 로드
        moduleData mDat = new moduleData();


        public FormRegi()
        {
            InitializeComponent();
            textBoxWeb.Text = "http://";
        }

        private void FormRegi_Load(object sender, EventArgs e)
        {

        }

        /*
        파일 오픈 다이얼로그 이벤트
        */
        private void buttonBrowProg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.DefaultExt = "exe";
            openFileDlg.ShowDialog();
            if (openFileDlg.FileName.Length > 0)
            {
                foreach (string filename in openFileDlg.FileNames)
                {
                    this.textBoxProg.Text = filename;
                }
            }
        }

        /*
        폴더 오픈 다이얼로그 이벤트
        */
        private void buttonBrowFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "등록할 경로를 찾으세요";
            folderBrowserDialog.ShowNewFolderButton = true;//새폴더 기능 온
            if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.textBoxFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void radioButtonProg_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxProg.Enabled = true;
            this.textBoxFolder.Enabled = false;
            this.textBoxWeb.Enabled = false;
            selectedType = "파일";
        }

        private void radioButtonFolder_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxProg.Enabled = false;
            this.textBoxFolder.Enabled = true;
            this.textBoxWeb.Enabled = false;
            selectedType = "폴더";
        }

        private void radioButtonWeb_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxProg.Enabled = false;
            this.textBoxFolder.Enabled = false;
            this.textBoxWeb.Enabled = true;
            selectedType = "웹사이트";
        }

        //데이터 모듈 불러와서 실행시킴
        //기록정보
        /*
        외부노출 이름
        ID
        경로, 파일이름 - 프로그램
        경로 - 폴더
        주소 - 사이트
        */
        private void buttonOk_Click(object sender, EventArgs e)
        {
            //id 최근번호 얻음
            if (!textBoxInfo.Text.Equals(""))
            {
                id_count = mDat.getIdCount_Bm();
                int tmpnum;
                Int32.TryParse(id_count, out tmpnum);
                id_count = string.Format("{0:D3}", tmpnum);

                //id 데이터 기록
                switch (selectedType)
                {
                    case "파일":
                        {
                            mDat.makeIdFile_Bm(id_count, textBoxInfo.Text, textBoxProg.Text, selectedType);
                            break;
                        }
                    case "폴더":
                        {
                            mDat.makeIdFile_Bm(id_count, textBoxInfo.Text, textBoxFolder.Text, selectedType);
                            break;
                        }
                    case "웹사이트":
                        {
                            mDat.makeIdFile_Bm(id_count, textBoxInfo.Text, textBoxWeb.Text, selectedType);
                            break;
                        }
                    default:
                        break;
                }
                //id 릴레이션 폴더 생성
                mDat.makeRelFolder_Bm(id_count);

                //id 카운터 증가
                mDat.plusIdCount_Bm(id_count);

                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("이름을 입력해주세요");
            }
        }

        //취소하고 나감
        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();//창 닫음
        }
    }




}
