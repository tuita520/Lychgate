// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using Sigon.Lychgate;
using Sigon.Lychgate.Graphics;

namespace Sigon.LychgateExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameEngine ge = new GameEngine(BackendType.OpenTK);
            SceneManager sceneMgr = ge.SceneManager;

            sceneMgr.Window.CreateWindow(800, 600, false, "Lychgate 3D Engine - Test Application");

            while (sceneMgr.Window.WindowActive)
            {
                ge.Loop();
            }
        }
    }
}
