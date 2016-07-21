namespace Janken
{
    /// <summary>
    /// プレーヤーというクラスを生成する
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets 各プレーヤーが出した手の種類
        /// </summary>
        public int Fist
        {
            get;
            internal set;
        }

        /// <summary>
        /// 引数の手の種類に対応した文字列に変換する
        /// </summary>
        /// <param name="input">手の種類</param>
        /// <returns>手の種類に対応した文字列</returns>
        public string IntToFist(int input)
        {
            string result = string.Empty;
            switch (input)
            {
                case Utils.CHOKI:
                    result = "チョキ";
                    break;
                case Utils.GU:
                    result = "グー";
                    break;
                case Utils.PA:
                    result = "パー";
                    break;
            }

            return result;
        }
    }
}
