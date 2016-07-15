namespace Janken
{
    public class Player
    {
        public int Fist
        {
            get;
            internal set;
        }

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
