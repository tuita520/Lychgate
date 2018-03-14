using System;
using Sigon.Lychgate;

namespace Sigon.LychgateExample
{
    class PRogram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lychgate 3D-Engine Test Application");

            GameEngine engine = new GameEngine();

            engine.InitGraphics(Lychgate.Graphics.DriverType.OpenGL, 800, 600);
            engine.Loop();
        }
    }
}
