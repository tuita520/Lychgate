// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Sigon.Lychgate.Graphics
{
    public class OpenGLVideoDriver : VideoDriver
    {
        private NativeWindow window;
        private GraphicsContext context;

        public override bool WindowActive { get => window.Exists; }

        public OpenGLVideoDriver()
        {
            window = null; context = null;
        }

        private void OnResize(object o, EventArgs e)
        {
            GL.Viewport(window.ClientRectangle.X, window.ClientRectangle.Y, window.ClientRectangle.Width, window.ClientRectangle.Height);
            var projection = Matrix4.CreatePerspectiveFieldOfView((float)System.Math.PI / 4, window.Width / (float)window.Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);
        }
        public override void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        }

        public override void Draw()
        {
            ClearScreen();
            // Drawing goes here...
            EndFrame();
        }

        public override void CreateWindow(int width, int height, bool fullscreen, string title)
        {
            window = new NativeWindow(width, height, title, fullscreen ? GameWindowFlags.Fullscreen : GameWindowFlags.FixedWindow, GraphicsMode.Default, DisplayDevice.Default);
            context = new GraphicsContext(GraphicsMode.Default, window.WindowInfo, 4, 4, GraphicsContextFlags.Default);
            context.MakeCurrent(window.WindowInfo);
            (context as IGraphicsContextInternal).LoadAll();
            window.Visible = true;
            window.Resize += OnResize;

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.CullFace);
        }

        public void EndFrame()
        {
            window.ProcessEvents();
            if(window.Exists)
                context.SwapBuffers();

        }
    }
}

