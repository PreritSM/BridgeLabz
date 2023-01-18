using System;

namespace snakeLadder
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome the game of 'SNAKE AND LADDERS' .");
            SnL cl_Obj = new SnL();
            //cl_Obj.displayStart();
            //cl_Obj.displayRoll();
            cl_Obj.gameSimul2p();

        }
    }
}