using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptorSample
{
    class JankenAdaptor
    {
        private JankenSurudake janken;
        public JankenAdaptor()
        {
            this.janken = new JankenSurudake();
        }

        public void AdaptedJanken(string[] args)
        {
            // 要求された処理
            Console.WriteLine("要求された処理");
            // もともとやっていた処理
            janken.Janken(args);
        }
    }
}
