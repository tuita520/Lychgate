// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Sigon.Lychgate.Graphics;

namespace Sigon.LychgateExample
{
    public class GameWindow : BaseWindow
    {
        private float angle = 0;
        
        private SceneManager sceneManager;
        /// <summary>
        /// 
        /// </summary>
        public SceneManager SceneManager { get => sceneManager; set => sceneManager = value; }

        public GameWindow()
        {
            sceneManager = new SceneManager();
        }
        public override void CreateWindow(int width, int height, bool fullscreen, string title)
        {
            wintitle = title;
            base.CreateWindow(width, height, fullscreen, title);

            Window.KeyDown += OnKeyDown;
        }

        protected void OnKeyDown(object o, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Window.Close();
        }

        protected override void OnUpdateFrame(object o, FrameEventArgs e)
        {
            (SceneManager.RootNode as DOFNode).RotationZ = angle;

            if (angle == 359)
                angle = 0;
            else
                angle += 0.05f;

            sceneManager.Update();
            base.OnUpdateFrame(o, e); // This has to be called AFTER our update.
        }

        protected override void OnRenderFrame(object o, FrameEventArgs e)
        {
            Renderer.ClearScreen();
            sceneManager.Draw();
            base.OnRenderFrame(o, e); // This has to be called AFTER our update.
        }
    }
}
