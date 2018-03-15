// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using System.Diagnostics;
using Sigon.Lychgate.Graphics;

namespace Sigon.Lychgate
{
    public class Engine
    {
        private const int VER_MAJOR = 0;
        private const int VER_MINOR = 1;
        private const int VER_PLVL = 0;
        private const string VER_ADD = "-pre-alpha1";
        private const int API_VER = 20180314;
        private SceneManager sceneManager;
        private VideoDriver videoDriver;
        private bool run;

        public SceneManager SceneManager { get => sceneManager; }
        public VideoDriver VideoDriver { get => videoDriver; set => videoDriver = value; }
        public bool Run { get => run; set => run = value; }

        public Engine()
        {
            Debug.WriteLine("Starting Lychgate 3D-Engine Version: " + VER_MAJOR + "." + VER_MINOR + "." + VER_PLVL + VER_ADD + " API: " + API_VER);
            videoDriver = null;
            sceneManager = null;
        }

        public void InitGraphics(DriverType dt, int width, int height, bool fullscreen, string title)
        {
            sceneManager = new SceneManager();
            switch(dt)
            {
                case DriverType.OpenGL:
                    Debug.WriteLine("OpenGLDriver selected...");
                    videoDriver = new OpenGLVideoDriver();
                    break;
                case DriverType.DirectX:
                    throw new NotImplementedException();
            }
            sceneManager.VideoDriver = videoDriver;

            videoDriver.CreateWindow(width, height, fullscreen, title);

            Run = true;
        }

        public void Loop()
        {
            Debug.WriteLine("Entering main loop...");
            // Main Loop
            //InputManager.Update();
            // If(InputManager.QuitApplication)
            //      Run = false;
            //      return;
            //SoundManager.Update();
            while (videoDriver.WindowActive)
            {
                SceneManager.Update();
            }
        }
    }
}
