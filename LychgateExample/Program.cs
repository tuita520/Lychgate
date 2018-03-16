using System;
using OpenTK;
using Sigon.Lychgate;
using Sigon.Lychgate.Graphics;

namespace Sigon.LychgateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();

            engine.InitGraphics(DriverType.OpenGL, 800, 600, false, "Lychgate 3D Test", OnKeyPress);
            engine.Loop();
        }

        // depending on the framework used, we have to implement another delegate.
        public static void OnKeyPress(object o, EventArgs e)
        {
            Console.WriteLine("Event triggered {0}", (e as KeyPressEventArgs).KeyChar);
        }
    }
}
