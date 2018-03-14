// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using Sigon.Lychgate.Graphics;

namespace Sigon.Lychgate
{
    public class GameEngine
    {
        private Graphics.SceneManager sceneManager;
        private Graphics.VideoDriver videoDriver;
        private bool run;

        public Graphics.SceneManager SceneManager { get => sceneManager; }
        public VideoDriver VideoDriver { get => videoDriver; set => videoDriver = value; }
        public bool Run { get => run; set => run = value; }

        public void InitGraphics(Graphics.DriverType dt, int width, int height)
        {
            sceneManager = new Graphics.SceneManager();
            switch(dt)
            {
                case DriverType.OpenGL:
                    videoDriver = new OpenGLVideoDriver(width, height);
                    break;
                case DriverType.DirectX:
                    throw new NotImplementedException();
            }
            sceneManager.VideoDriver = videoDriver;

            videoDriver.CreateWindow();

            Run = true;
        }
        public void Loop()
        {
            // Main Loop
            //InputManager.Update();
            // If(InputManager.QuitApplication)
            //      Run = false;
            //      return;
            //SoundManager.Update();
            SceneManager.Update();
        }
    }
}
