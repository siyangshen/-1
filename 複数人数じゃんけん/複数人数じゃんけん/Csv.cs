namespace Janken
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Csvファイルのデータを読み込むクラス
    /// </summary>
    internal class Csv
    {
        /// <summary>
        /// Csvファイルのデータを読み込んで、勝率を計算する
        /// </summary>
        public static void CsvOpen()
        {
            string[] kekka = System.IO.File.ReadAllLines(@"C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\janken.csv");
            IEnumerable<IEnumerable<int>> multiColQuery =
                from line in kekka
                let elements = line.Split(',')
                let janken = elements.Skip(0)
                select from str in janken
                       select Convert.ToInt32(str);
            var results = multiColQuery.ToList();
            int columnCount = results[0].Count();
            for (int column = 0; column < columnCount; column += 2)
            {
                var results2 = from row in results
                               select row.ElementAtOrDefault(column);
                double sumwin = results2.Sum();
                var results3 = from row in results
                               select row.ElementAtOrDefault(column + 1);
                double sumlose = results3.Sum();
                Console.WriteLine("ユーザー{0}は{1}勝{2}敗　勝率は{3:##.##}%", (column + 2) / 2, sumwin, sumlose, sumwin / (sumwin + sumlose) * 100);
                Console.ReadKey();
            }
        }
    }
}
