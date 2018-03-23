// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Runtime.CompilerServices;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// Implements the OpenTK GameWindow class and encapsulates it for use with the Engine.
    /// </summary>
    public class Engine
    {
        private SceneManager sceneManager;
        private GameWindow window;
        /// <summary>
        /// 
        /// </summary>
        public GameWindow Window { get => window; set { } }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected virtual void OnResize(object o, EventArgs e)
        {
            // TODO: Wrap this in a Renderer Method.
            
            GL.Viewport(window.ClientRectangle.X, window.ClientRectangle.Y, window.ClientRectangle.Width, window.ClientRectangle.Height);
            var projection = Matrix4.CreatePerspectiveFieldOfView((float)System.Math.PI / 4, window.Width / (float)window.Height, 1.0f, 64.0f);

            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void OnLoad(object o, EventArgs e)
        {
            Renderer.Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected virtual void OnRenderFrame(object o, FrameEventArgs e)
        {
            // Drawing goes here
            Window.SwapBuffers();
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
 
            // Setting Event-Handlers
            Window.Resize += OnResize;
            Window.Load += OnLoad;
            Window.RenderFrame += OnRenderFrame;
            Window.UpdateFrame += OnUpdateFrame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fps"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void Run(double fps)
        {
            Window.Run(fps, 0.0);
        }
    }
}
