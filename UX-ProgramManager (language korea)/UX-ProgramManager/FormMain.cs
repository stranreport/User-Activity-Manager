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
    public partial class FormMain : Form
    {
        //enum modetype { MODEBM = 0, MODEPC = 1 };
        bool modeSelect; //0 = false = bookmark mode, 1 = true = proccess mode
        bool isPrev;     //이전에 실행된 프로그램이 있는지 체크
        bool isNext;     //이전에 실행된 프로그램이 있는지 체크
        bool isMainViewSelected;
        bool isRecViewSelected;
        bool isChaseOn;
        
        int selectedRow;
        String idNow;
        String idNext;
        String selectedID;

        //모듈 로드
        moduleData mDat = new moduleData();
        moduleRun mRun = new moduleRun();
        
        public FormMain()
        {
            InitializeComponent();
            mDat.firstRunSetUp();//초기 기동 설정

            changeMode(0);//기본은 북마크
            
            setMainViewBm();
            setRecViewBm();
            mDat.setIdListView_Bm(listViewMain);//메인뷰 정보 설정

            isPrev = false;//이전 실행 없음
            isMainViewSelected = false;//선택 안됨
            isRecViewSelected = false;//선택 안됨
            isChaseOn = false;//추적기능 사용 안함
            selectedRow = 0;//선택 행 0행
            changeEnabledButton(modeSelect);//버튼 활성화
        }
        
        //프로그램 상태 변환
        public void changeMode(int key)
        {
            if(key==0)
            {
                if (isChaseOn == true)
                {
                    isChaseOn = false;
                    mDat.processEventOff();
                }
                modeSelect = false;//bmMode
            }
            else
            {
                modeSelect = true;//pcMode
            }
        }

        //메인뷰 기초설정 등록 Bm
        private void setMainViewBm()
        {
            listViewMain.BeginUpdate();
            listViewMain.Clear();
            listViewMain.View = View.Details;//디테일 뷰
            listViewMain.Columns.Add("ID");
            listViewMain.Columns.Add("이름");
            listViewMain.Columns.Add("경로");
            listViewMain.Columns.Add("종류");
            listViewMain.Columns[0].Width = 50;
            listViewMain.Columns[1].Width = 150;
            listViewMain.Columns[2].Width = 70;
            listViewMain.Columns[3].Width = 80;
            for (int i = 0; i < 4; i++)
            {
                listViewMain.Columns[i].TextAlign = HorizontalAlignment.Left;
            }
            listViewMain.EndUpdate();
        }

        //추천뷰 기초설정 등록 Bm
        private void setRecViewBm()
        {
            listViewRec.BeginUpdate();
            listViewRec.Clear();
            listViewRec.View = View.Details;//디테일 뷰
            listViewRec.Columns.Add("ID");
            listViewRec.Columns.Add("이름");
            listViewRec.Columns.Add("경로");
            listViewRec.Columns.Add("종류");
            listViewRec.Columns[0].Width = 50;
            listViewRec.Columns[1].Width = 150;
            listViewRec.Columns[2].Width = 70;
            listViewRec.Columns[3].Width = 80;
            for (int i = 0; i < 4; i++)
            {
                listViewRec.Columns[i].TextAlign = HorizontalAlignment.Left;
            }
            listViewRec.EndUpdate();
        }

        //메인뷰 기초설정 등록 Pc
        private void setMainViewPc()
        {
            listViewMain.BeginUpdate();
            listViewMain.Clear();
            listViewMain.View = View.Details;//디테일 뷰
            listViewMain.Columns.Add("ID");
            listViewMain.Columns.Add("이름");
            listViewMain.Columns.Add("그룹 갯수");
            listViewMain.Columns[0].Width = 200;
            listViewMain.Columns[1].Width = 250;
            listViewMain.Columns[2].Width = 70;
            for (int i = 0; i < 3; i++)
            {
                listViewMain.Columns[i].TextAlign = HorizontalAlignment.Left;              
            }
            listViewMain.EndUpdate();
        }

        //새로고침 버튼 이벤트
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (modeSelect == false)
            {
                setMainViewBm();//항목초기화
                mDat.setIdListView_Bm(listViewMain);//셋업
            }
            else if (modeSelect == true)
            {
                setMainViewPc();
                mDat.makeRelList_Pc(listViewMain);//셋업
            }
        }

        //선택한 리스트 실행 관련 기능
        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (modeSelect == false)
            {
                string selectedId;
                if (isMainViewSelected == true)
                {
                    Console.WriteLine(listViewMain.FocusedItem.SubItems[2].Text);
                    Console.WriteLine(listViewMain.FocusedItem.SubItems[3].Text);

                    mRun.runBase(listViewMain.FocusedItem.SubItems[2].Text,
                        listViewMain.FocusedItem.SubItems[3].Text);


                    selectedId = listViewMain.FocusedItem.SubItems[0].Text;
                    setRecViewBm();//추천뷰 설정 함수                    
                    mDat.setRelListView_Bm(listViewRec, selectedId);

                    //시간값 증가
                    int nowTime = System.DateTime.Now.Hour;//시간 획득
                    mDat.calculateTimeData(listViewMain.FocusedItem.SubItems[0].Text, nowTime); //시간값 증가


                    if (isPrev == false)
                    {
                        isPrev = true;
                        idNow = listViewMain.FocusedItem.SubItems[0].Text;//now id 설정
                                                                          //추천리스트뷰 갱신
                        Console.WriteLine(idNow);
                    }
                    else if (isPrev == true)
                    {
                        idNext = listViewMain.FocusedItem.SubItems[0].Text;//next id 설정
                        if (!idNow.Equals(idNext))
                        {
                            mDat.incrementRelationData_Bm(idNow, idNext);//증감처리
                            idNow = idNext; //now 값 변화
                                            //추천리스트뷰 갱신
                        }
                    }
                }

                else if (isRecViewSelected == true)
                {
                    mRun.runBase(listViewRec.FocusedItem.SubItems[2].Text,
                        listViewRec.FocusedItem.SubItems[3].Text);


                    if (!idNow.Equals(idNext))
                    {
                        idNext = listViewRec.FocusedItem.SubItems[0].Text;//next id 설정
                        mDat.incrementRelationData_Bm(idNow, idNext);//증감처리
                        idNow = idNext; //now 값 변화
                                        //추천리스트뷰 갱신
                    }

                    //시간값 증가
                    int nowTime = System.DateTime.Now.Hour;//시간 획득
                    mDat.calculateTimeData(listViewRec.FocusedItem.SubItems[0].Text, nowTime); //시간값 증가


                    selectedId = listViewRec.FocusedItem.SubItems[0].Text;
                    setRecViewBm();//추천뷰 설정 함수                    
                    mDat.setRelListView_Bm(listViewRec, selectedId);
                }
                else
                {
                    Console.WriteLine("선택안됨");
                }

                //now next id 비교해서 카운터 증가 - 같으면 증가X - 함수 안에서 처리함
                //실행시킴

                //즐겨찾기 갱신
                //id를 모듈에 보냄

                //추천뷰 설정 함수
                //setRecView();
                //mDat.set_Rel_listView(listViewRec, listViewMain.FocusedItem.SubItems[0].Text);


                //Console.WriteLine(listViewMain.FocusedItem.SubItems[0].Text);
                //해당하는 연관관계의 이름을 읽어서 배열화
                //각각의 수치를 읽어서 배열화 - 두 배열은 동기
                //두 배열을 추천 모듈에 보내서 정렬
                //다시 배열 받아서 갱신
                

                //Pc 모드에서의 실행
            }
            else if (modeSelect == true)
            {
                if (isMainViewSelected == true)
                {
                    int numOfList = 0;
                    string pathToRun = "";
                    Console.WriteLine(listViewMain.FocusedItem.SubItems[0].Text);
                    Console.WriteLine(listViewMain.FocusedItem.SubItems[1].Text);

                    string[] temp = listViewMain.FocusedItem.SubItems[0].Text.Split(new char[] { '-' });
                    Int32.TryParse(listViewMain.FocusedItem.SubItems[2].Text, out numOfList);
                    for (int i = 0; i < numOfList; i++)
                    {
                        System.Threading.Thread.Sleep(1000);//1초간격준다
                        pathToRun = mDat.getPathForRun_Pc(temp[i]);
                        mRun.runGroup(pathToRun);
                    }

                }
                else
                {
                    Console.WriteLine("선택안됨");
                }
            }
        }

        //포커스 체인지
        private void changed_focus_main(object sender, MouseEventArgs e)
        {
            isMainViewSelected = true;
            isRecViewSelected = false;
            selectedRow = listViewMain.SelectedIndices[0];
        }

        private void changed_focus_rec(object sender, MouseEventArgs e)
        {
            isRecViewSelected = true;
            isMainViewSelected = false;
            selectedRow = listViewRec.SelectedIndices[0];
        }

        //새로고침 기능
        private void refreshLists()
        {
            if (modeSelect == false)
            {
                setMainViewBm();//항목초기화
                mDat.setIdListView_Bm(listViewMain);//셋업
            }
            else if (modeSelect == true)
            {
                setMainViewPc();
                mDat.makeRelList_Pc(listViewMain);//셋업
            }
        }

        //disable button
        private void changeEnabledButton(bool d_mode)
        {
            if (d_mode == false)//BM
            {
                buttonEditGroupDat.Enabled = false;
                buttonViewIgnoreListPC.Enabled = false;
                buttonChaseOn.Enabled = false;
                buttonChaseOff.Enabled = false;

                buttonRegiBM.Enabled = true;
                buttonDeleteId.Enabled = true;
                buttonTimeTable.Enabled = true;

                listViewRec.Enabled = true;

            }
            else if (d_mode == true)//PC
            {
                buttonEditGroupDat.Enabled = true;
                buttonViewIgnoreListPC.Enabled = true;
                buttonChaseOn.Enabled = true;
                buttonChaseOff.Enabled = true;

                buttonRegiBM.Enabled = false;
                buttonDeleteId.Enabled = false;
                buttonTimeTable.Enabled = false;

                listViewRec.Enabled = false;
            }
        }




        //BookMark Mode

        //북마크 모드 실행
        private void buttonOptProg_Click(object sender, EventArgs e)
        {
            changeMode(0);
            changeEnabledButton(modeSelect);
            refreshLists();
        }

        //북마크를 등록한다
        private void buttonRegiBM_Click(object sender, EventArgs e)
        {
            FormRegi newDial = new FormRegi();
            newDial.ShowDialog(this);
        }

        //시간표 출력 모드
        private void buttonTimeTable_Click(object sender, EventArgs e)
        {
            FormTimeTable newDial = new FormTimeTable();
            newDial.ShowDialog(this);
        }






        //Process Mode

        //프로세스 모드 실행
        private void buttonOptProc_Click(object sender, EventArgs e)
        {
            changeMode(1);
            changeEnabledButton(modeSelect);
            refreshLists();
        }

        //종료
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //관련 정보를 보여준다(새창 띄움?), id만 보내고 새 인터페이스에서 보이기
        private void buttonViewDat_Click(object sender, EventArgs e)
        {
            //새 인터페이스 만들어서 id를 매개변수로 보냄
            //새 폼에서 데이터 읽어서 화면에 띄움
            if (isChaseOn == true)
            {
                System.Windows.Forms.MessageBox.Show("먼저 프로세스 추적을 종료해야 합니다.");
            }
            else
            {
                if ((isMainViewSelected) == true)
                {
                    FormViewGroup newDial = new FormViewGroup(listViewMain.FocusedItem.SubItems[0].Text);//id 패러미터로 넘김
                    newDial.ShowDialog(this);
                }
            }
            refreshLists();//목록 갱신
        }
        
        //프로세스 모드 관련 버튼, 무시할 프로세스 목록을 만듬
        private void buttonViewPC_Click(object sender, EventArgs e)
        {
            FormIgnore newDial = new FormIgnore();
            newDial.ShowDialog(this);
        }

        //프로세스 탐지 이벤트 ON-OFF
        private void buttonChaseOn_Click(object sender, EventArgs e)
        {
            isChaseOn = true;
            mDat.processEventOn();
        }

        private void buttonChaseOff_Click(object sender, EventArgs e)
        {
            isChaseOn = false;
            mDat.processEventOff();
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            if (isChaseOn == false)
            {
                mDat.processEventOn();
                button1.Text = "실행중";
            }
            else if (isChaseOn == true)
            {
                mDat.processEventOff();
                button1.Text = "실행종료";
            }
        }
        */

        //관계성 통계 모드
        private void buttonViewRel_Click(object sender, EventArgs e)
        {
            FormViewRelationData newDial = new FormViewRelationData();
            newDial.ShowDialog(this);
        }

        //북마크 삭제
        private void buttonDeleteId_Click(object sender, EventArgs e)
        {
            if (isMainViewSelected == true)
            {
                string toDeleteId = listViewMain.FocusedItem.SubItems[0].Text;
                string toAddPath = listViewMain.FocusedItem.SubItems[2].Text;

                mDat.deleteIdData_Bm(toDeleteId);//id 정보 파일 삭제
                mDat.deleteRelationData_Bm(toDeleteId);//id 관계 파일, 폴더 삭제
                mDat.deleteTimeData_Bm(toDeleteId);//시간 관계값 기록 파일 삭제
                listViewMain.FocusedItem.Remove();//선택항 제거
                refreshLists();//새로고침
            }
        }
    }
}
