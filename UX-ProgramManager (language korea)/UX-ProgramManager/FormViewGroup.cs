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
    public partial class FormViewGroup : Form
    {
        string idChunk;
        string[] cuttedId;
        int selectedRow;
        bool isViewSelected = false;

        //모듈
        moduleData mDat = new moduleData();
        moduleRun mRun = new moduleRun();

        public FormViewGroup()
        {
            InitializeComponent();
        }

        public FormViewGroup(string idList)
        {
            InitializeComponent();
            Console.WriteLine(idList);
            idChunk = idList;
            makeIdList();//id 리스트 생성
            //Console.WriteLine(cuttedId[0]);
            setupGroupView();//그룹뷰 틀 생성
            loadListData();//리스트 정보 불러오기
        }

        private void makeIdList()
        {
            cuttedId = idChunk.Split(new char[] { '-' });//구분자로 분리해서 id 얻음
        }

        //메인뷰 기초설정 등록 Bm
        private void setupGroupView()
        {
            listViewGroup.BeginUpdate();
            listViewGroup.Clear();
            listViewGroup.View = View.Details;//디테일 뷰
            listViewGroup.Columns.Add("ID");
            listViewGroup.Columns.Add("이름");
            listViewGroup.Columns.Add("경로");
            listViewGroup.Columns.Add("종류");
            listViewGroup.Columns[0].Width = 50;
            listViewGroup.Columns[1].Width = 150;
            listViewGroup.Columns[2].Width = 70;
            listViewGroup.Columns[3].Width = 80;
            listViewGroup.EndUpdate();
        }

        private void loadListData()
        {
            listViewGroup.BeginUpdate();//일시정지

            int iter = 0;
            int numOfItem = cuttedId.Length-1;//배열 갯수, 마지막에 null 배열이 하나 존재
            Console.WriteLine(numOfItem);
            for (int i=0; i< numOfItem; i++)
            {
                mDat.setGroupListView_Pc(listViewGroup, cuttedId[i]);//정보 읽어서 추가
            }
            
            listViewGroup.EndUpdate();//정지해제
        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            string toDeleteId = listViewGroup.FocusedItem.SubItems[0].Text;
            string toAddPath = listViewGroup.FocusedItem.SubItems[2].Text;

            mDat.deleteIdData_Pc(toDeleteId);//id 정보 파일 삭제
            mDat.deleteRelationData_Pc(toDeleteId);//id 관계 파일 삭제
            mDat.addToIgnoreList(System.IO.Path.GetFileName(toAddPath));//탐지 무시 목록에 추가
            listViewGroup.FocusedItem.Remove();//선택항 제거
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (isViewSelected == true)
            {
                Console.WriteLine(listViewGroup.FocusedItem.SubItems[2].Text);
                Console.WriteLine(listViewGroup.FocusedItem.SubItems[3].Text);

                mRun.runBase(listViewGroup.FocusedItem.SubItems[2].Text,
                    listViewGroup.FocusedItem.SubItems[3].Text);                                              
            }
        }

        private void change_focus_view(object sender, MouseEventArgs e)
        {
            isViewSelected = true;
            selectedRow = listViewGroup.SelectedIndices[0];
        }
    }
}
