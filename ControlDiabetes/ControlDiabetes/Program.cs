using System;
using Models;

namespace ControlDiabetes
{
    class Program
    {
        static void Main(string[] args)
        {
            Business bo = new Business();
            bo.Load();
        }
    }
}
