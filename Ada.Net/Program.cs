using System;

namespace Ada.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                //No args, lets just allow it to be
            }
            Console.WriteLine(Menu.WriteLogo());
        }
    }
}
