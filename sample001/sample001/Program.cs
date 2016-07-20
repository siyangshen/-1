using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample001
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestData
            var userCount = 3;
     
            var playCount = 3;
            var resultList = new List<List<int>>();
            var detaillist = new List<int>() ;
            var count = 0;
            while (count < playCount) {
                detaillist.Clear();
                for (int i = 1; i <= userCount;i++) {

                    if (i == 1)
                    {
                        detaillist.Add(1);
                    }
                    else {
                        detaillist.Add(0);
                    }
                }
                count++;
                resultList.Add(detaillist);
             }

            var test = resultList;

            // 対戦回数
            resultList.Count();

            // 勝率
            var taisenkaisu = 1;
            var user1 = 0;
            var user2 = 0;
            var user3 = 0;
            foreach (var result in resultList) {

                if (result[0] == 1) {
                    user1 += 1;

                }
                if (result[1] == 1)
                {
                    user2 += 1;

                }
                if (result[2] == 1)
                {
                    user3 += 1;

                }
                
                taisenkaisu++;
            }
            System.Diagnostics.Debug.WriteLine("対戦第{0}回", taisenkaisu);
            System.Diagnostics.Debug.WriteLine("ユーザ1は,{0}", user1);
            System.Diagnostics.Debug.WriteLine("ユーザ2は,{0}", user2);
            System.Diagnostics.Debug.WriteLine("ユーザ3は,{0}", user3);
        }
    }
}
