// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// Implements the OpenTK GameWindow class and encapsulates it for use with the Engine.
    /// </summary>
    public class BaseWindow
    {
        private GameWindow window;
        /// <summary>
        /// 
        /// </summary>
        public GameWindow Window { get => window; set { } }

        private SceneManager sceneManager;
        private Renderer renderer;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected virtual void OnResize(object o, EventArgs e)
        {
            GL.Viewport(window.ClientRectangle.X, window.ClientRectangle.Y, window.ClientRectangle.Width, window.ClientRectangle.Height);
            var projection = Matrix4.CreatePerspectiveFieldOfView((float)System.Math.PI / 4, window.Width / (float)window.Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected virtual void OnLoad(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.CullFace);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected virtual void OnRenderFrame(object o, FrameEventArgs e)
        {
            renderer.ClearScreen();
            // Drawing goes here
            window.SwapBuffers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected virtual void OnUpdateFrame(object o, FrameEventArgs e)
        {
            // Scenegraph update goes here
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fullscreen"></param>
        /// <param name="title"></param>
        public virtual void CreateWindow(int width, int height, bool fullscreen, string title)
        {
            window = new GameWindow(width, height, GraphicsMode.Default, title, GameWindowFlags.Default, DisplayDevice.Default);
            sceneManager = new SceneManager();
            renderer = new Renderer();

            // Setting Event-Handlers
            window.Resize += OnResize;
            window.Load += OnLoad;
            window.RenderFrame += OnRenderFrame;
            window.UpdateFrame += OnUpdateFrame;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fps"></param>
        public virtual void Run(int fps)
        {
            window.Run(fps);
        }
    }
}
