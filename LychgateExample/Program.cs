using System;
using Sigon.Lychgate;

namespace Sigon.LychgateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();

            engine.InitGraphics(Lychgate.Graphics.DriverType.OpenGL, 800, 600, false, "Lychgate 3D Test");
            engine.Loop();
        }
    }
}
