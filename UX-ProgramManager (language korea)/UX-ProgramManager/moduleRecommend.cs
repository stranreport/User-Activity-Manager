using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX_ProgramManager
{
    class moduleRecommend
    {
        String tmp_str;
        int tmp_int;

        //bm 모드의 결과값 계산 버블정렬 내림차순
        public void arrangeBmData(ref String[] arr_id, ref int[] arr_val, int length)
        {
            for(int i=length-1; 0 <= i; i--)
            {
                for(int j=i-1; 0 <= j; j--)
                {
                    if (arr_val[i] > arr_val[j])
                    {
                        tmp_str = arr_id[i];
                        tmp_int = arr_val[i];
                        arr_id[i] = arr_id[j];
                        arr_val[i] = arr_val[j];
                        arr_id[j] = tmp_str;
                        arr_val[j] = tmp_int;
                    }
                }
            }
        }

        //pc 모드의 결과값 계산 버블정렬 내림차순
        public void arrangePcData(ref String[] arr_id, ref int[] arr_val, int length)
        {
            for (int i = length - 1; 0 <= i; i--)
            {
                for (int j = i - 1; 0 <= j; j--)
                {
                    if (arr_val[i] > arr_val[j])
                    {
                        tmp_str = arr_id[i];
                        tmp_int = arr_val[i];
                        arr_id[i] = arr_id[j];
                        arr_val[i] = arr_val[j];
                        arr_id[j] = tmp_str;
                        arr_val[j] = tmp_int;
                    }
                }
            }
        }

        //pc 모드의 결과값을 만들어서 등록함
        public void arrangePcData()
        {
            List<string> reccomedList = new List<string>();

            //모든 id 릴레이션 폴더 순회
            //시작 릴레이션 폴더를 기준으로 만들어 나감
            //첫 릴레이션 폴더에서 상위 3개, 3개중 1위 폴더에 나머지 2개가 있다면 추가한다? 없으면 추가 X
            //결과 각각의 폴더에서 관계그룹을 하나씩 만들어서 제출이 가능함

            string pathPcId = @"C:\UAM\opt_proc\dat_id\";
            string pathPcRel = @"C:\UAM\opt_proc\dat_relation\";






        }


    }
}
