// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using Sigon.Lychgate.Graphics;

namespace Sigon.LychgateExample
{
    public class Game : Engine
    {
        private float angle = 0;
        
        private SceneManager sceneManager;
        /// <summary>
        /// 
        /// </summary>
        public SceneManager SceneManager { get => sceneManager; set => sceneManager = value; }

        public Game()
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
            if (e.Key == Key.Escape)
                Window.Close();

            if (e.Key == Key.Up)
                (SceneManager.RootNode as DOFNode).RotationX -= 0.05f;
            if (e.Key == Key.Down)
                (SceneManager.RootNode as DOFNode).RotationX += 0.05f;
            if(e.Key == Key.Left)
                (SceneManager.RootNode as DOFNode).RotationY -= 0.05f;
            if(e.Key == Key.Right)
                (SceneManager.RootNode as DOFNode).RotationY += 0.05f;
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

        public static void Main(string[] args)
        {
            var game = new Game();
          
            game.CreateWindow(800, 600, false, "Lychgate Test");

            var vertices = new Vertex[5];
             
            // Pyramid drawing.
            vertices[0].Position = new Vector3(1.0f, -1.0f, 1.0f);
            vertices[0].Normal = new Vector3();
            vertices[0].TexCoords = new Vector2();
            vertices[1].Position = new Vector3(1.0f, -1.0f, -1.0f);
            vertices[1].Normal = new Vector3();
            vertices[1].TexCoords = new Vector2();
            vertices[2].Position = new Vector3(-1.0f, -1.0f, -1.0f);
            vertices[2].Normal = new Vector3();
            vertices[2].TexCoords = new Vector2();
            vertices[3].Position = new Vector3(-1.0f, -1.0f, 1.0f);
            vertices[3].Normal = new Vector3();
            vertices[3].TexCoords = new Vector2();
            vertices[4].Position = new Vector3(0.0f, 1.0f, 0.0f);
            vertices[4].Normal = new Vector3();
            vertices[4].TexCoords = new Vector2();

            var mesh = new Mesh
            {
                Vertices = vertices,
                Indices = new ushort[18] {2, 1, 0, 3, 2, 0, 0, 4, 3, 1, 4, 0, 2, 4, 1, 3, 4, 2},
                Colors = new Color4[5]
                {
                    new Color4(255,255,0,255),
                    new Color4(0,255,255,255),
                    new Color4(255,255,255,255),
                    new Color4(255,0,255,255),
                    new Color4(200,0,200,200)
                }
            };

            mesh.SetBuffers();

            game.SceneManager.RootNode = new DOFNode();
            (game.SceneManager.RootNode as DOFNode).Position = new Vector3(0.0f, 0.0f, -6.0f);
            var node = new GeometryNode
            {
                NodeMesh = mesh
            };

            game.SceneManager.RootNode.AddChild(node);

            game.Run(60.0);
        }
    }
}
