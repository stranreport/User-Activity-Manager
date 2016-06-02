using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UX_ProgramManager
{
    class moduleRun
    {
        String str_path;        //경로정보
        String str_name;        //파일이름
        String str_exct;        //확장자 정보
        String str_website;     //인터넷 경로 정보
        String idNow;           //실행중인 파일 id
        String idNext;          //다음 실행할 파일 id


        public void runProgram(String toRunData)
        {
            System.Diagnostics.Process.Start(toRunData);
            //System.Diagnostics.Process.Start("F:\\RSADecrypt.java");
        }

        public void runFolder(String toRunPath)
        {
            System.Diagnostics.Process.Start("explorer.exe", toRunPath);
            //System.Diagnostics.Process.Start("explorer.exe", "F:\\Project\\visual studio 2015\\Projects\\UX-ProgramManager\\UX-ProgramManager");
        }


        public void runWeb(String toRunWeb)
        {
            //System.Diagnostics.ProcessStartInfo pro = new
            //    System.Diagnostics.ProcessStartInfo("iexplorer.exe", toRunWeb);
            //System.Diagnostics.Process.Start("iexplorer.exe", toRunWeb);
            //System.Diagnostics.Process.Start("explorer.exe", "http://google.com");
            //System.Diagnostics.Process.Start(pro);
            System.Diagnostics.Process.Start(toRunWeb);
        }

        public void runBase(String path, String type)
        {
            if(type.Equals("파일"))
            {
                runProgram(path);
            }
            else if(type.Equals("폴더"))
            {
                runFolder(path);
            }
            else if (type.Equals("웹사이트"))
            {
                runWeb(path);
            }
        }

        public void runGroup(String path)
        {
            runProgram(path);
        }




    }
}
