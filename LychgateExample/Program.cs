using System;
using System.Diagnostics;
using Sigon.Lychgate;
using Sigon.Lychgate.Graphics;

namespace Sigon.LychgateExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sceneMgr = new SceneManager(BackendType.OpenTK);
            sceneMgr.Window.CreateWindow(800, 600, false, "Lychgate 3D Engine Test-Application");

            Debug.WriteLine("Entering main loop...");

            while (sceneMgr.Window.WindowActive)
            {
                if(sceneMgr.Window.KeyPressed == Key.A)
                    Console.WriteLine("A-Key Pressed");

                if(sceneMgr.Window.KeyPressed == Key.B)
                    Console.WriteLine("B-Key Pressed");

                if (sceneMgr.Window.KeyPressed == Key.C)
                    Console.WriteLine("C-Key Pressed");

                sceneMgr.Update();
                sceneMgr.Renderer.Draw();
                sceneMgr.Window.EndFrame();
            }
        }
    }
}
