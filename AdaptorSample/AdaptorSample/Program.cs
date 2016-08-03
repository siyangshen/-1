using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 今まで
            //JankenSurudake jankenSurudake = new JankenSurudake();
            //jankenSurudake.Janken(new string[0]);

            JankenAdaptor adaptor = new JankenAdaptor();
            adaptor.AdaptedJanken(args);
        }
    }
}
