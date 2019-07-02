using System;

namespace SevenWorldWonders
{
    class Program
    {
        static void Main(string[] args)
        {
            GizaPyramid gp = new GizaPyramid();
            BabylonGardens bg = new BabylonGardens();
            ZeusStatue zs = new ZeusStatue();
            ArtemisTemple at = new ArtemisTemple();
            HalicarnassusMausoleum hm = new HalicarnassusMausoleum();
            RhodesColossus rc = new RhodesColossus();
            AlexandriaLighthouse al = new AlexandriaLighthouse();
            Console.Title = "7 чудес света";
            Console.WriteLine("7 чудес света:");
            Console.WriteLine("1) " + gp.GetName());
            Console.WriteLine("2) " + bg.GetName());
            Console.WriteLine("3) " + zs.GetName());
            Console.WriteLine("4) " + at.GetName());
            Console.WriteLine("5) " + hm.GetName());
            Console.WriteLine("6) " + rc.GetName());
            Console.WriteLine("7) " + al.GetName());
            Console.ReadKey();
        }
    }
}