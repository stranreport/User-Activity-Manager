using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UX_ProgramManager.manageData
{
    class moduleData
    {
        string str_id;          //id 번호
        string str_type;        //북마크 타입
        string str_path;        //경로정보
        string str_name;        //등록이름
        string str_exct;        //확장자 정보
        string str_website;     //인터넷 경로 정보
        string idNow;           //실행중인 파일 id
        string idNext;          //다음 실행할 파일 id
        string str_value;       //연관 크기
        string str_time;       //시간 크기

        string str_name_Pc;        //등록이름
        string str_path_Pc;        //경로정보
        string str_value_Pc;       //연관 크기
        string str_type_Pc;        //북마크 타입
        string str_run_path_Pc;    //경로정보
        
        string pathSystemBm = @"C:\UAM\opt_prog\system.txt"; //실행정보 시스템 카운트 파일(bm)
        string pathSystemPc = @"C:\UAM\opt_proc\system.txt"; //실행정보 시스템 카운트 파일(pc)
        string pathPgId = @"C:\UAM\opt_prog\dat_id\"; //실행정보 폴더(bm)
        string pathPgRel = @"C:\UAM\opt_prog\dat_relation\"; //연관정보 폴더(bm)
        string pathPcId = @"C:\UAM\opt_proc\dat_id\"; //실행정보 폴더(pc)
        string pathPcRel = @"C:\UAM\opt_proc\dat_relation\"; //연관정보 폴더(pc)
        string pathIgnorePc = @"C:\UAM\opt_proc\ignoreList.txt"; //무시정보 폴더(pc)
        string pathPgTime = @"C:\UAM\opt_prog\dat_time\"; //시간정보 폴더(bm)

        int folderCount = 0;    //폴더안의 파일 숫자

        bool isActivatedChaseProcess = false;

        //만들어서 추천 모듈한테 줘야 하는것
        string[] arrayIdBm;    //가진 파일 이름 나열
        int[] arrayValueBm;      //파일 내부의 크기값 나열

        string[] arrayIdPc;    //가진 파일 이름 나열
        int[] arrayValuePc;      //파일 내부의 크기값 나열


        //리스트
        List<string> processList = new List<string>();//xxx.txt 들로 구성
        List<string> ignoreList = new List<string>();

        //스레드
        Thread _thread;//조작용
        ManualResetEvent _pauseEvent = new ManualResetEvent(false);//초기상태는 신호 정지

        //이벤트 워쳐
        ManagementEventWatcher watcherCre;
        ManagementEventWatcher watcherDel;
        //모듈
        moduleRecommend mRec = new moduleRecommend();

        //초기 기동 설정
        public void firstRunSetUp()
        {
            string searchPath = @"C:\UAM";

            if (!System.IO.Directory.Exists(searchPath))
            {
                Console.WriteLine("초기기동 시작");

                System.IO.Directory.CreateDirectory(pathPgId);
                System.IO.Directory.CreateDirectory(pathPgRel);
                System.IO.Directory.CreateDirectory(pathPcId);
                System.IO.Directory.CreateDirectory(pathPcRel);
                System.IO.Directory.CreateDirectory(pathPgTime);
                for(int i=1; i<9; i++)
                {
                    System.IO.Directory.CreateDirectory(pathPgTime+"\\"+ "time" +i.ToString());
                }


                FileStream fs = new FileStream(pathSystemBm, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("0");
                sw.Close();

                fs = new FileStream(pathSystemPc, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine("0");
                sw.Close();

                fs = new FileStream(pathIgnorePc, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine("vshost.exe");
                sw.WriteLine("svchost.exe");
                sw.WriteLine("dllhost.exe");
                sw.WriteLine("explorer.exe");
                sw.WriteLine("audiodg.exe");
                sw.WriteLine("flashutil64_21_0_0_242_activex.exe");
                sw.Close();
                                        
                /*
                System.IO.Directory.CreateDirectory(pathPgId);
                System.IO.Directory.CreateDirectory(pathPgRel);
                System.IO.Directory.CreateDirectory(pathPcId);
                System.IO.Directory.CreateDirectory(pathPcRel);
                System.IO.Directory.CreateDirectory(pathPgTime);
                
                System.IO.File.Create(pathSystemBm);
                System.IO.File.Create(pathSystemPc);
                System.IO.File.Create(pathIgnorePc);
                */

            }
        }
                
        //기록용 배열 생성
        //함수 연계 사용
        //폴더 내의 파일 갯수 알아오기(파라미터로 받음, 클래스 내부에도 남음)
        //그 갯수의 길이를 지닌 배열 만들기(해당 함수에서 처리, 클래스 내부에 남음)
        //파일 이름 목록을 배열에 할당하기(여기서는 처리하지 않음)
        public void makeArray_Bm(int numOfFiles)
        {
            arrayIdBm = new string[numOfFiles];
            arrayValueBm = new int[numOfFiles];
        }

        //기록용 배열 생성
        //함수 연계 사용
        //폴더 내의 파일 갯수 알아오기(파라미터로 받음, 클래스 내부에도 남음)
        //그 갯수의 길이를 지닌 배열 만들기(해당 함수에서 처리, 클래스 내부에 남음)
        //파일 이름 목록을 배열에 할당하기(여기서는 처리하지 않음)
        public void makeArray_Pc(int numOfFiles)
        {
            arrayIdPc = new string[numOfFiles];
            arrayValuePc = new int[numOfFiles];
        }

        //id 파일 생성 후 설정 함수
        public void makeIdFile_Bm(string d_id, string d_info, string d_path, string d_type)
        {
            string searchPath = pathPgId + "id" + d_id + ".txt";

            if (!System.IO.File.Exists(searchPath))
            {
                System.IO.File.WriteAllText(searchPath, d_info, Encoding.Default);//값 갱신
                System.IO.File.AppendAllText(searchPath, "\r\n" + d_path, Encoding.Default);//값 갱신
                System.IO.File.AppendAllText(searchPath, "\r\n" + d_type, Encoding.Default);//값 갱신
            }
            else
            {
                return;//이미 존재함
            }
        }
       
        //id 파일 생성 후 설정 함수
        public void makeIdFile_Pc(string d_id, string d_name, string d_path)
        {
            //id 최근번호 얻어서 규격화
            string id_count;
            int tmpnum;
            Int32.TryParse(d_id, out tmpnum);
            id_count = string.Format("{0:D3}", tmpnum);

            string searchPath = pathPcId + "id" + id_count + ".txt";

            if (!System.IO.File.Exists(searchPath))
            {
                System.IO.File.WriteAllText(searchPath, d_name, Encoding.Default);//값 갱신
                System.IO.File.AppendAllText(searchPath, "\r\n" + d_path, Encoding.Default);//값 갱신
                System.IO.File.AppendAllText(searchPath, "\r\n" + "파일", Encoding.Default);//값 갱신
            }
            else
            {
                return;//이미 존재함
            }
        }
        
        //릴레이션 폴더 생성 함수 BM
        public void makeRelFolder_Bm(string d_id)
        {
            //id 최근번호 얻어서 규격화
            string id_count;
            int tmpnum;
            Int32.TryParse(d_id, out tmpnum);
            id_count = string.Format("{0:D3}", tmpnum);

            string searchPath = pathPgRel + "id" + id_count;

            if (!System.IO.Directory.Exists(searchPath))
            {
                System.IO.Directory.CreateDirectory(searchPath); // 폴더 생성 (덮어 씌움)
            }
            else
            {
                return;//이미 존재함
            }
        }

        //릴레이션 폴더 생성 함수 PC
        public void makeRelFolder_Pc(string d_id)
        {
            //id 최근번호 얻어서 규격화
            string id_count;
            int tmpnum;
            Int32.TryParse(d_id, out tmpnum);
            id_count = string.Format("{0:D3}", tmpnum);

            string searchPath = pathPcRel + "id" + id_count;

            if (!System.IO.Directory.Exists(searchPath))
            {
                System.IO.Directory.CreateDirectory(searchPath); // 폴더 생성 (덮어 씌움)
            }
            else
            {
                return;//이미 존재함
            }
        }

        //폴더 내의 파일 숫자 출력 함수(id 폴더 출력용)
        public int countIdFolder()
        {
            string searchPath = pathPgId;

            if (System.IO.Directory.Exists(searchPath))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(searchPath);
                int count = di.GetFiles().Length;
                return count;
            }
            return -1; //에러반환
        }

        //폴더 내의 파일 숫자 출력 함수(연관 폴더 출력용)
        public int countRelFolder_Bm(string folderName)
        {
            string searchPath = pathPgRel + folderName;

            if (System.IO.Directory.Exists(searchPath))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(searchPath);
                int count = di.GetFiles().Length;
                return count;
            }
            return -1; //에러반환
        }

        //폴더 내의 파일 숫자 출력 함수(연관 폴더 출력용)
        public int countRelFolder_Pc(string folderName)
        {
            string searchPath = pathPcRel + folderName;

            if (System.IO.Directory.Exists(searchPath))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(searchPath);
                int count = di.GetFiles().Length;
                return count; 
            }
            return -1; //에러반환
        }

        //폴더 내의 파일 숫자 출력 함수(시간 폴더 출력용)
        public int countTimeFolder_Bm(string d_folderPath)
        {
            string searchPath = d_folderPath;

            if (System.IO.Directory.Exists(searchPath))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(searchPath);
                int count = di.GetFiles().Length;
                return count;
            }
            return -1; //에러반환
        }

        //파일 내용 습득 함수(실행을 위한 정보 읽음)
        public void getDataOfId_Bm(string idNum)
        {
            string searchPath = pathPgId + idNum;
            int acker = 0;
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); // 파일 오픈(읽기전용)
                while((tmpLine = file.ReadLine()) != null)//한줄씩 읽어옴
                {
                    acker++;
                    switch (acker)
                    {
                        case 1:
                            {
                                str_name = tmpLine;
                                break;
                            }
                        case 2:
                            {
                                str_path = tmpLine;
                                break;
                            }
                        case 3:
                            {
                                str_type = tmpLine;
                                break;
                            }
                        default:
                            break;
                    }
                }
                file.Close();
            }
            else
            {
                return;//없는 파일, 리턴함
            }
        }

        //파일 내용 습득 함수(실행을 위한 정보 읽음)
        public void getDataOfId_Pc(string idName)
        {
            string searchPath = pathPcId + idName;
            int acker = 0;
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); // 파일 오픈(읽기전용)
                while ((tmpLine = file.ReadLine()) != null)//한줄씩 읽어옴
                {
                    acker++;
                    switch (acker)
                    {
                        case 1:
                            {
                                str_name_Pc = tmpLine;
                                break;
                            }
                        case 2:
                            {
                                str_path_Pc = tmpLine;
                                break;
                            }
                        case 3:
                            {
                                str_type_Pc = tmpLine;
                                break;
                            }
                        default:
                            break;
                    }
                }
                file.Close();
            }
            else
            {
                return;//없는 파일, 리턴함
            }
        }

        //파일 내용 습득 함수(실행을 위한 정보 읽음)
        public string getPathForRun_Pc(string idNum)
        {
            string searchPath = pathPcId + idNum + ".txt";
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); // 파일 오픈(읽기전용)
                tmpLine = file.ReadLine();
                tmpLine = file.ReadLine();
                str_run_path_Pc = tmpLine;
                    
                file.Close();
                return tmpLine;//경로값 반환
            }
            else
            {
                return "";//없는 파일, 리턴함
            }
        }
                
        //파일 내용 습득 함수(추천을 위한 정보 읽음)
        public void getRelData_Bm(string idRun, string idRel)
        {
            string searchPath = pathPgRel + idRun + "\\" + idRel;
            int acker = 0;
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); // 파일 오픈(읽기전용)
                while ((tmpLine = file.ReadLine()) != null)//한줄씩 읽어옴
                {
                    str_value = tmpLine;
                }
                file.Close();
            }
            else
            {
                str_value = "none";//없는 파일, none 메시지 리턴함
            }
        }

        //파일 내용 습득 함수(추천을 위한 정보 읽음)
        public void getRelData_Pc(string idRun, string idRel)
        { 
            string searchPath = pathPcRel + idRun + "\\" + idRel;
            int acker = 0;
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); // 파일 오픈(읽기전용)
                while ((tmpLine = file.ReadLine()) != null)//한줄씩 읽어옴
                {
                    str_value_Pc = tmpLine;
                }
                file.Close();
            }
            else
            {
                str_value_Pc = "none";//없는 파일, none 메시지 리턴함
            }
        }

        //id 카운트 출력
        public string getIdCount_Bm()
        {
            string searchPath = pathSystemBm;
            string toStr = "";
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); //파일 오픈
                while ((tmpLine = file.ReadLine()) != null)//한줄 읽어옴
                {
                    toStr = tmpLine;
                }
                file.Close();
            }
            else
            {
                return null;//없는 파일, 리턴함
            }
            return toStr;
        }

        //id 카운트 출력
        public string getIdCount_Pc()
        {
            string searchPath = pathSystemPc;
            string toStr = "";
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); //파일 오픈
                while ((tmpLine = file.ReadLine()) != null)//한줄 읽어옴
                {
                    toStr = tmpLine;
                }
                file.Close();
            }
            else
            {
                return null;//없는 파일, 리턴함
            }
            return toStr;
        }

        //id 카운트 증가
        public void plusIdCount_Bm(string count)
        {
            string searchPath = pathSystemBm;

            int tmpDat = 0;
            string tmpLine;

            Int32.TryParse(count, out tmpDat);
            tmpDat++;
            tmpLine = Convert.ToString(tmpDat);
            System.IO.File.WriteAllText(searchPath, tmpLine, Encoding.Default);//값 갱신
        }

        //id 카운트 증가
        public void plusIdCount_Pc(string count)
        {
            string searchPath = pathSystemPc;

            int tmpDat = 0;
            string tmpLine;

            Int32.TryParse(count, out tmpDat);
            tmpDat++;
            tmpLine = Convert.ToString(tmpDat);
            System.IO.File.WriteAllText(searchPath, tmpLine, Encoding.Default);//값 갱신
        }

        //id 파일 존재 여부 확인 함수(pc)(파일이름을 통해 비교)
        public bool isExistIdFile_Pc(string d_fileName, ref string o_id)
        {
            string searchPath = pathPcId;
            string fileName;
            string tmpWindowName;
            string tmpPath;
            string nameDat;
            System.IO.StreamReader fileR;

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(searchPath);
            foreach (var item in di.GetFiles())
            {
                fileR = new System.IO.StreamReader(item.FullName, Encoding.Default);
                fileName = item.Name;
                tmpWindowName = fileR.ReadLine();
                tmpPath = fileR.ReadLine();//경로의 값을 읽어옴

                nameDat = System.IO.Path.GetFileName(tmpPath).ToLower();

                if (d_fileName.Equals(nameDat))
                {
                    string[] temp = fileName.Split(new char[] { '.' });
                    o_id = temp[0];//읽은 파일 이름 반환 idxxx
                    return true;
                }
                else
                {
                    fileR.Close();
                    continue;
                }
            }
            return false;
        }

        //id 파일 존재 여부 확인 함수(pc)(파일이름을 통해 비교)
        public bool isExistIdFile_PcAnother(string d_windowName, string d_fileName, ref string o_id)
        {
            string searchPath = pathPcId;
            string fileName;
            string tmpWindowName;
            string tmpPath;
            string nameDat;
            System.IO.StreamReader fileR;

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(searchPath);
            foreach (var item in di.GetFiles())
            {
                fileR = new System.IO.StreamReader(item.FullName, Encoding.Default);
                fileName = item.Name;
                tmpWindowName = fileR.ReadLine();
                tmpPath = fileR.ReadLine();//경로의 값을 읽어옴

                nameDat = System.IO.Path.GetFileName(tmpPath).ToLower();

                if (d_windowName.Equals(tmpWindowName) && d_fileName.Equals(nameDat))
                {
                    string[] temp = fileName.Split(new char[] { '.' });
                    o_id = temp[0];//읽은 파일 이름 반환 idxxx
                    return true;
                }
                else
                {
                    fileR.Close();
                    continue;
                }
            }
            return false;
        }
        
        //id 파일 삭제 BM
        public void deleteIdData_Bm(string d_id)
        {
            string searchPath = pathPgId + d_id +".txt";

            FileInfo file = new FileInfo(searchPath);
            try
            {
                if (file.Exists)
                {
                    file.Delete();
                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        //id 파일 삭제 PC
        public void deleteIdData_Pc(string d_id)
        {
            string searchPath = pathPcId + d_id + ".txt";

            FileInfo file = new FileInfo(searchPath);
            try
            {
                if (file.Exists)
                {
                    file.Delete();
                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        //릴레이션 파일 삭제 Bm
        public void deleteRelationData_Bm(string d_id)
        {
            string searchPath = pathPgRel;

            if (System.IO.Directory.Exists(searchPath))
            {
                DirectoryInfo directoryDat = new DirectoryInfo(searchPath);
                foreach (var dir in directoryDat.GetDirectories())//데이터 릴레이션의 모든 폴더를 탐색
                {
                    DirectoryInfo fileDat = new DirectoryInfo(searchPath + dir.Name);
                    foreach (var item in fileDat.GetFiles())//폴더 안의 파일을 탐색
                    {
                        if (item.Name.Equals(d_id + ".txt"))
                        {
                            item.Delete();//id가 일치하면 삭제
                        }
                    }

                    if (dir.Name.Equals(d_id))
                    {
                        dir.Delete(true);//폴더 삭제
                    }
                }
            }
        }
        
        //릴레이션 파일 삭제 Pc
        public void deleteRelationData_Pc(string d_id)
        {
            string searchPath = pathPcRel;

            if (System.IO.Directory.Exists(searchPath))
            {
                DirectoryInfo directoryDat = new DirectoryInfo(searchPath);
                foreach (var dir in directoryDat.GetDirectories())//데이터 릴레이션의 모든 폴더를 탐색
                {
                    DirectoryInfo fileDat = new DirectoryInfo(searchPath + dir.Name);
                    foreach (var item in fileDat.GetFiles())//폴더 안의 파일을 탐색
                    {
                        if (item.Name.Equals(d_id + ".txt"))
                        {
                            item.Delete();//id가 일치하면 삭제
                        }
                    }

                    if (dir.Name.Equals(d_id))
                    {
                        dir.Delete(true);//폴더 삭제
                    }
                }
            }
        }

        //시간 기록 파일 삭제 Bm
        public void deleteTimeData_Bm(string d_id)
        {
            string searchPath = pathPgTime;

            if (System.IO.Directory.Exists(searchPath))
            {
                DirectoryInfo directoryDat = new DirectoryInfo(searchPath);
                foreach (var dir in directoryDat.GetDirectories())//데이터 릴레이션의 모든 폴더를 탐색
                {
                    DirectoryInfo fileDat = new DirectoryInfo(searchPath + dir.Name);
                    foreach (var item in fileDat.GetFiles())//폴더 안의 파일을 탐색
                    {
                        if (item.Name.Equals(d_id + ".txt"))
                        {
                            item.Delete();//id가 일치하면 삭제
                        }
                    }
                }
            }
        }
        
        //파일 내용 카운터 증가 함수, 현재 파일의 연관폴더에 다음 파일의 연관성 증가 시킴
        public void incrementRelationData_Bm(string idNumNow, string idNumNext)
        {
            string searchPath = pathPgRel + idNumNow + "\\" + idNumNext + ".txt";
            string tmpLine ="";
            int tmpDat = 0;
            getRelData_Bm(idNumNow, idNumNext+".txt");
            Console.WriteLine("str_value 값" + str_value);
            if (!str_value.Equals("none"))
            {
                Int32.TryParse(str_value, out tmpDat);
                tmpDat++;
                tmpLine = Convert.ToString(tmpDat);
            }
                
            if (str_value.Equals("none"))
            {
                FileStream fs = new FileStream(searchPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("1");
                sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(searchPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(tmpLine);
                sw.Close();
                fs.Close();

            }
        }

        //파일 내용 카운터 증가 함수, 현재 파일의 연관폴더에 다음 파일의 연관성 증가 시킴
        public void incrementRelationData_Pc(string idNumNow, string idNumNext)
        {
            string searchPath = pathPcRel + idNumNow + "\\" + idNumNext + ".txt";
            string tmpLine = "";
            int tmpDat = 0;
            getRelData_Pc(idNumNow, idNumNext + ".txt");
            Console.WriteLine("str_value_Pc 값" + str_value_Pc);
            if (!str_value_Pc.Equals("none"))//값이 존재 할 경우 미리 값을 증가시켜 둠
            {
                Int32.TryParse(str_value_Pc, out tmpDat);
                tmpDat++;
                tmpLine = Convert.ToString(tmpDat);
            }

            if (str_value_Pc.Equals("none"))//값이 존재 하지 않을 경우 1부터 기입
            {
                FileStream fs = new FileStream(searchPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("1");
                sw.Close();
                fs.Close();
            }
            else//존재할 경우 기입하고 종료
            {
                FileStream fs = new FileStream(searchPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(tmpLine);
                sw.Close();
                fs.Close();

            }
        }

        //폴더 내용 목록 리스트뷰 설정 함수(id파일 출력용)
        public void setIdListView_Bm(ListView lv)
        {
            //등록된 파일의 갯수를 읽어온다
            //갯수만큼 배열에 저장한다? ㄴㄴ 바로 읽어오면서 등록
            //파일의 이름을 통해 정보를 읽어온다
            //하나하나 등록한다
            lv.BeginUpdate();//일시정지

            string searchPath = pathPgId;
            ListViewItem tmpitem;

            if (System.IO.Directory.Exists(searchPath))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(searchPath);
                foreach (var item in di.GetFiles())
                {
                    this.getDataOfId_Bm(item.Name); //정보 읽음
                    //리스트 아이템 생성
                    tmpitem = new ListViewItem(System.IO.Path.GetFileNameWithoutExtension(item.FullName));
                    tmpitem.SubItems.Add(this.str_name);
                    tmpitem.SubItems.Add(this.str_path);
                    tmpitem.SubItems.Add(this.str_type);
                    //리스트에 추가
                    lv.Items.Add(tmpitem);
                }//모든 아이템을 탐색
            }
            lv.EndUpdate();//정지해제
        }
        
        //추천 리스트 작성 함수
        public void setRelListView_Bm(ListView lv, string id)
        {
            lv.BeginUpdate();//일시정지

            string searchPath = pathPgRel + id; //경로지정
            ListViewItem tmpitem;
            int numOfRel = countRelFolder_Bm(id);    //파일 수 획득
            //Console.WriteLine("파일 개수" + numOfRel);
            int iterator = 0;
            makeArray_Bm(numOfRel);                   //배열 생성
            
            
            if (System.IO.Directory.Exists(searchPath))
            {
                DirectoryInfo di = new DirectoryInfo(searchPath);
                foreach (var item in di.GetFiles())
                {
                    getRelData_Bm(id, item.Name); //크기값 읽음
                    //Console.WriteLine("파일 이름" + item.Name);
                    arrayIdBm[iterator] = System.IO.Path.GetFileNameWithoutExtension(item.FullName);
                    Int32.TryParse(str_value, out arrayValueBm[iterator]);
                    //Console.WriteLine("파일 이름" + arrayIdBm[iterator] + "파일 크기" + str_value);
                    iterator++;
                }//모든 아이템을 탐색
            }
            //배열 2개 추천모듈에 보내서 정렬
            mRec.arrangeBmData(ref arrayIdBm, ref arrayValueBm, numOfRel);

            string idPath = pathPgId;

            for (int i=0; i<numOfRel; i++)
            {
                getDataOfId_Bm(arrayIdBm[i] + ".txt");

                tmpitem = new ListViewItem(arrayIdBm[i]);
                tmpitem.SubItems.Add(this.str_name);
                tmpitem.SubItems.Add(this.str_path);
                tmpitem.SubItems.Add(this.str_type);
                //리스트에 추가
                lv.Items.Add(tmpitem);
            }

            lv.EndUpdate();//정지해제
        }

        //Pc모드 리스트 작성 함수
        public void makeRelList_Pc(ListView lv)
        {
            lv.BeginUpdate();//일시정지

            string searchPath = pathPcRel; //경로지정
            ListViewItem tmpitem;
            //List<string> 
            int numOfRel = 0;
            string[] arrayIdSub = new string[3]; //서브 결정자에도 메인 결정자의 연관 id가 있는지 확인하기 위해 기록하는것
            int[] arrayValueSub = new int[3];
            string mainName;
            string subName;
            int subValue;
            //Console.WriteLine("파일 개수" + numOfRel);
            int iterator = 0;
            bool isExist = false;
            int iterPoint=0;
            string outPutId = "";
            string outPutName = "";

            List<string> reccomedList = new List<string>();//최종 출력용 리스트

            if (System.IO.Directory.Exists(searchPath))
            {
                DirectoryInfo directoryDat = new DirectoryInfo(searchPath);
                foreach (var dir in directoryDat.GetDirectories())//데이터 릴레이션의 모든 폴더를 탐색
                {
                    reccomedList.Add(dir.Name);//루트 폴더 리스트에 추가
                    mainName = dir.Name;//메인 아이디 기억

                    DirectoryInfo fileDatMain = new DirectoryInfo(searchPath + dir.Name);//메인이 될 릴레이션의 id 폴더 안을 탐색
                    numOfRel = countRelFolder_Pc(dir.Name);    //파일 수 획득
                    makeArray_Pc(numOfRel);                   //배열 생성

                    iterator = 0;

                    if (numOfRel != 0) //파일이 0개가 아닌 경우만
                    {
                        foreach (var file in fileDatMain.GetFiles())//메인 id 에 관한 모든 파일 아이템의 관계값 얻음
                        {
                            getRelData_Pc(dir.Name, file.Name);
                            arrayIdPc[iterator] = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                            Int32.TryParse(str_value_Pc, out arrayValuePc[iterator]);
                            iterator++;
                        }
                        mRec.arrangePcData(ref arrayIdPc, ref arrayValuePc, numOfRel);//크기 순 정렬

                        subName = arrayIdPc[0];//서브 아이디 기록
                        subValue = arrayValuePc[0];
                        reccomedList.Add(subName);//서브 아이디를 리스트에 추가

                        if (numOfRel >= 4)//메인아이디 파일 수 판별
                        {                                                       
                            for (int i = 1; i < 4; i++) //서브 id 1순위(서브자신)을 제외하고 메인의 값을 배열에 3개 할당
                            {
                                arrayIdSub[i - 1] = arrayIdPc[i];
                                arrayValueSub[i - 1] = arrayValuePc[i];
                            }

                            DirectoryInfo fileDatSub = new DirectoryInfo(searchPath + subName);//가장 높은 순위의 id폴더에 접근 서브 결정자
                            numOfRel = countRelFolder_Pc(subName);    //파일 수 획득
                            makeArray_Pc(numOfRel);                   //배열 생성

                            iterator = 0;

                            if(numOfRel >= 3)//서브아이디 파일 수 판별
                            {
                                foreach (var file in fileDatSub.GetFiles())//모든 아이템을 탐색 서브 결정자에 관한 관계값 얻음
                                {
                                    if (!mainName.Equals(System.IO.Path.GetFileNameWithoutExtension(file.FullName)))//메인 아이디에 관한 관계값이 서브값에도 있다면 그 항목 무시
                                    {
                                        getRelData_Pc(subName, file.Name);
                                        arrayIdPc[iterator] = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                                        Int32.TryParse(str_value_Pc, out arrayValuePc[iterator]);
                                        iterator++;
                                    }                                    
                                }
                                mRec.arrangePcData(ref arrayIdPc, ref arrayValuePc, numOfRel);//크기 순 정렬


                                //이제 배열을 얻었다
                                //모든 id 릴레이션 폴더 순회
                                //시작 릴레이션 폴더를 기준으로 만들어 나감
                                //첫 릴레이션 폴더에서 상위 3개, 3개중 1위 폴더에 나머지 2개가 있다면 추가한다? 없으면 추가 X
                                //결과 각각의 폴더에서 관계그룹을 하나씩 만들어서 제출이 가능함

                                for (int i = 0; i < 3; i++)//메인 이터레이터
                                {
                                    for (int j = 0; j < 3; j++)//서브 이터레이터
                                    {
                                        if (arrayIdSub[i].Equals(arrayIdPc[j]))
                                        {
                                            isExist = true;//메인이 관계를 맺는 아이디가 서브에도 존재함
                                            iterPoint = j;
                                        }
                                    }
                                    if (isExist == true)
                                    {
                                        if (((subValue + arrayValueSub[iterPoint]) / 2.0) > (subValue * 0.7))
                                        {
                                            //일정치 이상의 관계값을 만족할 경우 그룹에 추가한다
                                            reccomedList.Add(arrayIdSub[i]);
                                        }
                                        else
                                        {
                                            isExist = false;//초기화
                                        }
                                    }
                                    else
                                    {
                                        isExist = false;//초기화
                                    }
                                }
                                for (int i = 0; i < reccomedList.Count; i++)
                                {
                                    getDataOfId_Pc(reccomedList[i] + ".txt");
                                    outPutId += reccomedList[i] + "-";
                                    outPutName += str_name_Pc + "-";
                                }
                                //리스트 갱신
                                tmpitem = new ListViewItem(outPutId);
                                tmpitem.SubItems.Add(outPutName);
                                tmpitem.SubItems.Add(reccomedList.Count.ToString());
                                outPutId = "";
                                outPutName = "";
                                lv.Items.Add(tmpitem);
                                reccomedList.Clear();
                            }else if(numOfRel < 3)//서브 아이디의 파일 수가 적을 경우
                            {
                                for (int i = 0; i < reccomedList.Count; i++)
                                {
                                    getDataOfId_Pc(reccomedList[i] + ".txt");
                                    outPutId += reccomedList[i] + "-";
                                    outPutName += str_name_Pc + "-";
                                }
                                tmpitem = new ListViewItem(outPutId);
                                tmpitem.SubItems.Add(outPutName);
                                tmpitem.SubItems.Add(reccomedList.Count.ToString());
                                outPutId = "";
                                outPutName = "";
                                lv.Items.Add(tmpitem);
                                reccomedList.Clear();
                            }

                        }else if (numOfRel < 4)//메인 아이디의 파일 수가 적을 경우
                        {
                            for (int i = 0; i < reccomedList.Count; i++)
                            {
                                getDataOfId_Pc(reccomedList[i] + ".txt");
                                outPutId += reccomedList[i] + "-";
                                outPutName += str_name_Pc + "-";
                            }
                            //리스트 갱신
                            tmpitem = new ListViewItem(outPutId);
                            tmpitem.SubItems.Add(outPutName);
                            tmpitem.SubItems.Add(reccomedList.Count.ToString());
                            outPutId = "";
                            outPutName = "";
                            lv.Items.Add(tmpitem);
                            reccomedList.Clear();
                        }
                    }else if (numOfRel == 0)
                    {
                        reccomedList.Clear();
                    }
                }
            }

            lv.EndUpdate();//정지해제
        }



        //프로세스 추적 관계

        //프로세스 이벤트 감지 시작 함수
        public void processEventOn()
        {
            if (isActivatedChaseProcess == false)
            {
                makeIgnoreList();//무시 목록 생성

                _thread = new Thread(new ThreadStart(incrementRelationData_Pc));//스레드 설정
                _thread.Start();

                try//실행부
                {
                    string scope = @"\\.\root\CIMV2";
                    ManagementScope mgtScope = new ManagementScope(scope);

                    WqlEventQuery query =
                    new WqlEventQuery("__InstanceCreationEvent",
                                      new TimeSpan(0, 0, 1),
                                      "TargetInstance isa \"Win32_Process\"");

                    watcherCre = new ManagementEventWatcher();
                    watcherCre.Query = query;
                    watcherCre.Scope = mgtScope;
                    watcherCre.EventArrived += new EventArrivedEventHandler(eventRunProcess);
                    watcherCre.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception : " + ex.Message);
                }

                try//종료부
                {
                    string scope = @"\\.\root\CIMV2";
                    ManagementScope mgtScope = new ManagementScope(scope);

                    WqlEventQuery query =
                    new WqlEventQuery("__InstanceDeletionEvent",
                                      new TimeSpan(0, 0, 1),
                                      "TargetInstance isa \"Win32_Process\"");

                    watcherDel = new ManagementEventWatcher();
                    watcherDel.Query = query;
                    watcherDel.Scope = mgtScope;
                    watcherDel.EventArrived += new EventArrivedEventHandler(eventEndProcess);
                    watcherDel.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception : " + ex.Message);
                }
                isActivatedChaseProcess = true;
            }        
        }

        //프로세스 이벤트 감지 종료 함수
        public void processEventOff()
        {
            if (isActivatedChaseProcess == true)
            {
                watcherCre.Stop();
                watcherCre.Dispose();
                watcherDel.Stop();
                watcherDel.Dispose();
                _thread.Abort();
                isActivatedChaseProcess = false;
            }
        }

        //프로세스 실행될 때의 이벤트
        void eventRunProcess(object sender, EventArrivedEventArgs e)
        {
            _pauseEvent.Reset();

            bool alreadyExist;
            string d_windowTitle;
            string d_path;
            string o_id = "";
            string idCount;
            ManagementBaseObject eventArg = (ManagementBaseObject)
                                (e.NewEvent["TargetInstance"]);
            string processName = eventArg["Name"].ToString();
            Console.WriteLine("실행-이름 " + processName.ToString());
            if (!ignoreList.Contains(processName.ToLower()) && !processName.EndsWith("dll"))//무시 프로세스 리스트에 포함되는지 검사
            {
                string[] temp = processName.Split(new char[] { '.' });

                Process[] processes = Process.GetProcessesByName(temp[0]);
                try
                {
                    Console.WriteLine("실행-이름 " + processes[0].ProcessName.ToString());
                    Console.WriteLine("실행-경로 " + processes[0].Modules[0].FileName.ToString());
                    Console.WriteLine("실행-타이틀 " + processes[0].MainWindowTitle.ToString());

                    d_windowTitle = processes[0].MainWindowTitle.ToString();
                    d_path = processes[0].Modules[0].FileName.ToString();

                    alreadyExist = isExistIdFile_Pc(processName.ToLower(), ref o_id);

                    if (alreadyExist == true)
                    {
                        //1 등록된것이다
                        //id번호를 가져온다
                        //90 alreadyExistInList = isExistInList(o_id);
                        //프로세스 리스트에 존재하는지 확인한다
                        if (processList.Contains(o_id) == true)//존재할시
                        {
                            _pauseEvent.Set();
                            return;//종료
                        }
                        else if (processList.Contains(o_id) == false)//존재하지않을시
                        {
                            processList.Add(o_id);//프로세스 리스트에 추가
                            _pauseEvent.Set();
                            return;
                        }

                    }
                    else if (alreadyExist == false)
                    {
                        idCount = getIdCount_Pc();//id번호를 가져온다
                        makeIdFile_Pc(idCount, temp[0], d_path);//id를 새로 등록한다
                        makeRelFolder_Pc(idCount);//관계기록 폴더 생성

                        //id 최근번호 얻어서 규격화
                        string id_count;
                        int tmpnum;
                        Int32.TryParse(idCount, out tmpnum);
                        id_count = string.Format("{0:D3}", tmpnum);

                        processList.Add("id" + id_count);//프로세스 리스트에 넣는다
                        plusIdCount_Pc(idCount);//인덱스 카운트 증가
                    }
                }
                catch (System.ComponentModel.Win32Exception)
                {                    
                    _pauseEvent.Set();
                    return;
                }
                _pauseEvent.Set();
            }
        }

        //프로세스 종료될 때의 이벤트
        void eventEndProcess(object sender, EventArrivedEventArgs e)
        {
            _pauseEvent.Reset();
            string o_id = "";
            string[] del_name;
            ManagementBaseObject eventArg = (ManagementBaseObject)
                    (e.NewEvent["TargetInstance"]);
            string processName = eventArg["Name"].ToString();
            Console.WriteLine("종료-이름 " + processName.ToString());


            //주의 - 종료하면 프로세스 리스트에는 이미 없기때문에 기타 정보를 얻는것이 불가능하다
            //오직 프로세스의 이름만을 얻는것이 가능
            //경로값 획득이 불가
            //프로세스 이름으로 찾아야 한다
            if (!ignoreList.Contains(processName.ToLower()))//무시 프로세스 리스트에 포함되는지 검사(name.ext)
            {
                //string[] temp = processName.Split(new char[] { '.' });
                //Process[] processes = Process.GetProcessesByName(temp[0]);
                //Console.WriteLine("프로세스 갯수" + processes.Length);

                //d_path = processes[0].Modules[0].FileName.ToString();
                isExistIdFile_Pc(processName.ToLower(), ref o_id);
                //del_name = o_id.Split(new char[] { '.' });
                processList.Remove(o_id);//프로세스 idxxx 제거
            }
            _pauseEvent.Set();
        }

        //특정 시간마다 관계값을 증가시키는 함수(스레드)
        public void incrementRelationData_Pc() //스레드 함수
        {
            while (_pauseEvent.WaitOne())//실행 된 경우 계속 반복
            {
                int listLength = processList.Count;//리스트 길이 획득
                for (int i = 0; i < listLength; i++)
                {
                    for (int j = 0; j < listLength; j++)
                    {
                        if (i != j)
                        {
                            incrementRelationData_Pc(processList[i], processList[j]);
                        }
                    }
                }
                Thread.Sleep(10000);//10초에 한번씩
            }
        }



        //FormViewGroup 관계

        //그룹 리스트 생성 함수
        public void setGroupListView_Pc(ListView lv, string d_id)
        {
            ListViewItem tmpitem;
            string fileName = d_id + ".txt";
            this.getDataOfId_Pc(fileName); //정보 읽음
            //리스트 아이템 생성
            tmpitem = new ListViewItem(d_id);
            tmpitem.SubItems.Add(this.str_name_Pc);
            tmpitem.SubItems.Add(this.str_path_Pc);
            tmpitem.SubItems.Add(this.str_type_Pc);
            //리스트에 추가
            lv.Items.Add(tmpitem);
        }



        //FormIgnore 관계

        //무시 프로세스 목록 불러오기
        public void loadIgnoreList(ref TextBox d_tbox)
        {
            string searchPath = pathIgnorePc;
            int acker = 0;
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); // 파일 오픈(읽기전용)
                while ((tmpLine = file.ReadLine()) != null)//한줄씩 읽어옴
                {
                    d_tbox.AppendText(tmpLine+ "\n");//한줄씩 추가
                }
                file.Close();
            }
            else
            {
                System.IO.File.Create(searchPath);//파일 생성
                return;//없는 파일, 리턴함
            }
        }

        //무시 프로세스 목록 저장하기
        public void saveIgnoreList(TextBox d_tbox)
        {
            string searchPath = pathIgnorePc;
            string[] tmpArray = d_tbox.Text.Split('\n');
            //makeIgnoreList();
            System.IO.StreamWriter file = new System.IO.StreamWriter(searchPath, false); // 파일 오픈(읽기전용)

            for (int i = 0; i < d_tbox.Lines.Length; i++)
            {
                Console.WriteLine(tmpArray[i]);
                file.WriteLine(tmpArray[i]);
                //System.IO.File.AppendAllText(searchPath, d_tbox.Lines[i] + "\r\n", Encoding.Default);
               
            }
            file.Close();
        }

        //무시 목록 추가
        public void addToIgnoreList(string d_procName)
        {
            string searchPath = pathIgnorePc;
            System.IO.File.AppendAllText(searchPath, d_procName.ToLower(), Encoding.Default);
        }

        //무시 목록 파일 만들기
        private void makeIgnoreList()
        {
            string searchPath = pathIgnorePc;
            int acker = 0;
            if (System.IO.File.Exists(searchPath))
            {
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); // 파일 오픈(읽기전용)
                while ((tmpLine = file.ReadLine()) != null)//한줄씩 읽어옴
                {
                    ignoreList.Add(tmpLine);
                }
                file.Close();
                Console.WriteLine(ignoreList.ToArray());

            }
            else
            {
                System.IO.File.Create(searchPath);//파일 생성
                return;//없는 파일, 리턴함
            }
        }

        //받은 아이디에 해당하는 파일과 폴더를 지운다
        public void deleteIdFilesAndFolders(string d_id)
        {

        }

        

        //FormViewRelationData - 관계 정보 출력 폼 설정 함수모음

        //콤보박스 목록 설정
        public void setupIdComboBox_Bm(ComboBox d_cb)
        {
            string searchPath = pathPgId;
            string combinedName;
            DirectoryInfo di = new DirectoryInfo(searchPath);
            foreach (var item in di.GetFiles())
            {
                this.getDataOfId_Bm(item.Name);
                combinedName = System.IO.Path.GetFileNameWithoutExtension(item.FullName) + "-" + str_name;
                d_cb.Items.Add(combinedName);
            }
        }

        //콤보박스 목록 설정
        public void setupIdComboBox_Pc(ComboBox d_cb)
        {
            string searchPath = pathPcId;
            string combinedName;
            DirectoryInfo di = new DirectoryInfo(searchPath);
            foreach (var item in di.GetFiles())
            {
                this.getDataOfId_Pc(item.Name);
                combinedName = System.IO.Path.GetFileNameWithoutExtension(item.FullName) + "-" + str_name_Pc;
                d_cb.Items.Add(combinedName);
            }
        }

        //리스트뷰 정보 설정
        public void setupRelDataListView_Bm(ListView d_lv, string d_id)
        {
            d_lv.BeginUpdate();
            string searchPath = pathPgRel + d_id;
            string idNum;
            ListViewItem lvItem;
            DirectoryInfo di = new DirectoryInfo(searchPath);
            foreach (var item in di.GetFiles())
            {
                idNum = System.IO.Path.GetFileNameWithoutExtension(item.FullName);

                getDataOfId_Bm(item.Name);
                getRelData_Bm(d_id, item.Name);

                lvItem = new ListViewItem(idNum);
                lvItem.SubItems.Add(str_name);
                lvItem.SubItems.Add(str_value);
                lvItem.SubItems.Add(str_path);
                lvItem.SubItems.Add(str_type);

                d_lv.Items.Add(lvItem);
            }

            d_lv.EndUpdate();
        }

        //리스트뷰 정보 설정
        public void setupRelDataListView_Pc(ListView d_lv, string d_id)
        {
            string searchPath = pathPcRel + "\\" + d_id;
            string idNum;
            ListViewItem lvItem;
            DirectoryInfo di = new DirectoryInfo(searchPath);
            foreach (var item in di.GetFiles())
            {
                idNum = System.IO.Path.GetFileNameWithoutExtension(item.FullName);
                
                getDataOfId_Pc(item.Name);
                getRelData_Pc(d_id, item.Name);

                lvItem = new ListViewItem(idNum);
                lvItem.SubItems.Add(str_name_Pc);
                lvItem.SubItems.Add(str_value_Pc);
                lvItem.SubItems.Add(str_path_Pc);
                lvItem.SubItems.Add(str_type_Pc);

                d_lv.Items.Add(lvItem);
            }
        }



        //FormTimeTable - 시간표 출력 폼 설정 함수모음

        //시간 파일 값을 증가시킴
        public void calculateTimeData(string d_id, int d_time)
        { 
            string searchPath = pathPgTime;

            if ((0 <= d_time) && (d_time <= 2))
            {
                searchPath = searchPath + "time1" +"\\" + d_id + ".txt";
                incrementTimeData(searchPath);
            }
            else if ((3 <= d_time) && (d_time <= 5))
            {
                searchPath = searchPath + "time2" + "\\" + d_id + ".txt";
                incrementTimeData(searchPath);
            }
            else if ((6 <= d_time) && (d_time <= 8))
            {
                searchPath = searchPath + "time3" + "\\" + d_id + ".txt";
                incrementTimeData(searchPath);
            }
            else if ((9 <= d_time) && (d_time <= 11))
            {
                searchPath = searchPath + "time4" + "\\" + d_id + ".txt";
                incrementTimeData(searchPath);
            }
            else if ((12 <= d_time) && (d_time <= 14))
            {
                searchPath = searchPath + "time5" + "\\" + d_id + ".txt";
                incrementTimeData(searchPath);
            }
            else if ((15 <= d_time) && (d_time <= 17))
            {
                searchPath = searchPath + "time6" + "\\" + d_id + ".txt";
                incrementTimeData(searchPath);
            }
            else if ((18 <= d_time) && (d_time <= 20))
            {
                searchPath = searchPath + "time7" + "\\" + d_id + ".txt";
                incrementTimeData(searchPath);
            }
            else if ((21 <= d_time) && (d_time <= 23))
            {
                searchPath = searchPath + "time8" + "\\" + d_id + ".txt";
                incrementTimeData(searchPath);
            }            
        }

        //리스트 설정 함수
        public void setupTimeTableList(ListView d_lv, string d_selectedTimeNum)
        {
            d_lv.BeginUpdate();//일시정지

            string searchPath = pathPgTime + "time" + d_selectedTimeNum + "\\"; //경로지정
            ListViewItem tmpitem;
            int numOfRel = countTimeFolder_Bm(searchPath);    //파일 수 획득
            //Console.WriteLine("파일 개수" + numOfRel);
            int iterator = 0;
            makeArray_Bm(numOfRel);                   //배열 생성

            if (System.IO.Directory.Exists(searchPath))
            {
                DirectoryInfo di = new DirectoryInfo(searchPath);
                foreach (var item in di.GetFiles())
                {
                    getTimeData_Bm(item.FullName); //크기값 읽음
                    //Console.WriteLine("파일 이름" + item.Name);
                    arrayIdBm[iterator] = System.IO.Path.GetFileNameWithoutExtension(item.FullName);
                    Int32.TryParse(str_time, out arrayValueBm[iterator]);
                    //Console.WriteLine("파일 이름" + arrayIdBm[iterator] + "파일 크기" + str_time);
                    iterator++;
                }//모든 아이템을 탐색
            }
            //배열 2개 추천모듈에 보내서 정렬
            mRec.arrangeBmData(ref arrayIdBm, ref arrayValueBm, numOfRel);

            string idPath = pathPgId;

            for (int i = 0; i < numOfRel; i++)
            {
                getDataOfId_Bm(arrayIdBm[i] + ".txt");

                tmpitem = new ListViewItem(arrayIdBm[i]);
                tmpitem.SubItems.Add(this.str_name);
                tmpitem.SubItems.Add(this.str_path);
                tmpitem.SubItems.Add(this.str_type);
                //리스트에 추가
                d_lv.Items.Add(tmpitem);
            }

            d_lv.EndUpdate();//정지해제

        }

        //경로의 파일의 시간값 증가
        private void getTimeData_Bm(string d_filePath)
        {
            string searchPath = d_filePath;
            if (System.IO.File.Exists(searchPath))
            { 
                string tmpLine;
                System.IO.StreamReader file = new System.IO.StreamReader(searchPath, Encoding.Default); // 파일 오픈(읽기전용)
                while ((tmpLine = file.ReadLine()) != null)//한줄씩 읽어옴
                {
                    str_time = tmpLine;
                }
                file.Close();
            }
            else
            {
                str_time = "none";//없는 파일, none 메시지 리턴함
            }
        }

        public void incrementTimeData(string d_filePath)
        {
            string searchPath = d_filePath;
            string tmpLine = "";
            int tmpDat = 0;
            getTimeData_Bm(searchPath);        
            if (!str_time.Equals("none"))
            {
                Int32.TryParse(str_time, out tmpDat);
                tmpDat++;
                tmpLine = Convert.ToString(tmpDat);
            }

            if (str_time.Equals("none"))
            {
                FileStream fs = new FileStream(searchPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("1");
                sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(searchPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(tmpLine);
                sw.Close();
                fs.Close();

            }
        }
    }
}
