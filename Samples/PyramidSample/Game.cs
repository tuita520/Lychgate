// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using Sigon.Lychgate.Graphics;
using Sigon.Lychgate.Graphics.Rendering;

namespace Sigon.LychgateExample
{
    public class Game : Engine
    {
        private MeshSceneNode PyramidNode;
        public Game(int width, int height, bool fullscreen, string title) : base()
        {
            CreateWindow(width, height, fullscreen, title);

            Window.KeyDown += OnKeyDown;
        }

        protected void OnKeyDown(object o, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Window.Close();

            if (e.Key == Key.Up)
                PyramidNode.RelativeRotation.X -= 0.1f;
            if (e.Key == Key.Down)
                PyramidNode.RelativeRotation.X += 0.1f;
            if(e.Key == Key.Left)
                PyramidNode.RelativeRotation.Y -= 0.1f;
            if(e.Key == Key.Right)
                PyramidNode.RelativeRotation.Y += 0.1f;

            if (e.Key == Key.F11)
                if (Window.WindowState == WindowState.Normal)
                    Window.WindowState = WindowState.Fullscreen;
                else
                    Window.WindowState = WindowState.Normal;
        }

        protected override void OnUpdateFrame(object o, FrameEventArgs e)
        {
            base.OnUpdateFrame(o, e); // This has to be called AFTER our update.
        }

        protected override void OnRenderFrame(object o, FrameEventArgs e)
        {
            base.OnRenderFrame(o, e);
        }

        public Mesh CreatePyramidMesh()
        {    
            // Pyramid drawing.
            var mesh = new Mesh
            {
                Vertices = new Vector3[5]
                {
                    new Vector3(1.0f, -1.0f, 1.0f),
                    new Vector3(1.0f, -1.0f, -1.0f),
                    new Vector3(-1.0f, -1.0f, -1.0f),
                    new Vector3(-1.0f, -1.0f, 1.0f),
                    new Vector3(0.0f, 1.0f, 0.0f)
                },
                Indices = new ushort[18] {2, 1, 0, 3, 2, 0, 0, 4, 3, 1, 4, 0, 2, 4, 1, 3, 4, 2},
                Colors = new Color4[5]
                {
                    new Color4(255,255,0,255),
                    new Color4(0,255,255,255),
                    new Color4(255,255,255,255),
                    new Color4(0,0,255,255),
                    new Color4(200,128,200,200)
                }
            };
            return mesh;
        }

        public static void Main(string[] args)
        {
            var gameObject = new Game(800, 600, false, "Lychgate Test");

            gameObject.PyramidNode = gameObject.SceneManager.AddMeshSceneNode(null, gameObject.CreatePyramidMesh());
            gameObject.PyramidNode.AddAnimator(new FlyingCircleAnimator());
            
            gameObject.PyramidNode.RelativePosition = new Vector3(0.0f, 0.0f, -6.0f);

            gameObject.Run(60.0);
        }
    }
}
