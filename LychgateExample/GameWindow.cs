// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using OpenTK;
using OpenTK.Input;
using Sigon.Lychgate.Graphics;

namespace Sigon.LychgateExample
{
    public class GameWindow : BaseWindow
    {
        private SceneManager sceneManager;

        public GameWindow()
        {
            sceneManager = new SceneManager();
        }
        public override void CreateWindow(int width, int height, bool fullscreen, string title)
        {
            base.CreateWindow(width, height, fullscreen, title);

            Window.KeyDown += OnKeyDown;
        }

        protected void OnKeyDown(object o, KeyboardKeyEventArgs e)
        {
            Console.WriteLine("Taste {0} gedrückt", e.Key.ToString());

            if (e.Key == Key.Escape)
                Window.Close();
        }

        protected override void OnUpdateFrame(object o, FrameEventArgs e)
        {
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
