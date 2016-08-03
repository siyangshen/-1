namespace Janken
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// じゃんけん開始だけをJankenStartクラスに処理するという要求に適合させる
    /// </summary>
    public class JankenAdapter
    {
        private JankenStart janken;

        /// <summary>
        /// Initializes a new instance of the <see cref="JankenAdapter"/> class.
        /// JankenStartにじゃんけんゲームを開始させる
        /// </summary>
        public JankenAdapter()
        {
            this.janken = new JankenStart();
        }

        /// <summary>
        /// 要求前後の処理
        /// </summary>
        /// <param name="args"></param>
        public void AdaptedJanken(string[] args)
        {
            Console.WriteLine("MainClassでじゃんけんゲーム開始の処理を行いません。");
            this.janken.Start(args);
        }
    }
}
