// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using System.Collections;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Sigon.Lychgate.Graphics
{
    public class OpenGLVideoDriver : VideoDriver
    {
        private float[] vertexBufferArray;
        private GameWindow window;

        public OpenGLVideoDriver()
        {
            window = new GameWindow();

            window.Load += OnLoad;
            window.RenderFrame += OnRenderFrame;
        }

        public OpenGLVideoDriver(int width, int height)
        {
            window = new GameWindow(width, height);

            window.Load += OnLoad;
            window.RenderFrame += OnRenderFrame;
            window.Resize += OnResize;
        }

        public void setVertexBufferArray(float[] array)
        {
            vertexBufferArray = array;
        }

        private void OnRenderFrame(object o, FrameEventArgs e)
        {
            // Drawing vertexBufferArray
            // Drawing comes here...
            ClearScreen();
            window.SwapBuffers();
        }

        // Initialization goes here.
        private void OnLoad(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.CullFace);
        }

        private void OnResize(object o, EventArgs e)
        {
            GL.Viewport(window.ClientRectangle.X, window.ClientRectangle.Y, window.ClientRectangle.Width, window.ClientRectangle.Height);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)System.Math.PI / 4, window.Width / (float)window.Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);
        }
        public override void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        }
        public override void Draw()
        {
            // Implementation is handled by OnRenderFrame() for use with OpenTK.
        }

        public override void CreateWindow()
        {
            window.Run();
        }
    }
}
