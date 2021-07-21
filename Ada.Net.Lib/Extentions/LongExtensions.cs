using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Net.Lib.Extentions
{
    public static class LongExtensions
    {
        public static long ToAda(this long Value)
        {
            try
            {
                if (Value > 0)
                    return (long)Value / 1000000;
                else
                    return 0;
            }
            catch (Exception)
            {
                return -1;  //Gracefully Fail
            }
        }
    }
}
