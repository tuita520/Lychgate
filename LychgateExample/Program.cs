// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Sigon.Lychgate.Graphics;

namespace Sigon.LychgateExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameWindow gw = new GameWindow();
            gw.CreateWindow(800, 600, false, "Lychgate Test");

            var mesh = new Mesh();
            var vertices = new Vertex[3];
            var indices = new ushort[3];
            var colors = new Color4[3];

            vertices[0].Position = new Vector3(1.0f, -1.0f, 0.0f);
            vertices[0].Normal = new Vector3();
            vertices[0].TexCoords = new Vector2();
            indices[0] = 0;
            colors[0] = new Color4(255, 255, 0, 255);
            vertices[1].Position = new Vector3(0.0f, 1.0f, 0.0f);
            vertices[1].Normal = new Vector3();
            vertices[1].TexCoords = new Vector2();
            indices[1] = 1;
            colors[1] = new Color4(0, 255, 255, 255);
            vertices[2].Position = new Vector3(-1.0f, -1.0f, 0.0f);
            vertices[2].Normal = new Vector3();
            vertices[2].TexCoords = new Vector2();
            indices[2] = 2;
            colors[2] = new Color4(255, 255, 255, 255);
            mesh.Vertices = vertices;
            mesh.Indices = indices;
            mesh.Colors = colors;
            mesh.SetBuffers();

            var node = new GeometryNode();
            node.NodeMesh = mesh;
            var dofnode = new DOFNode();
            dofnode.Position = new Vector3(0.0f, 0.0f, -6.0f);
            
            gw.SceneManager.RootNode = dofnode;
            dofnode.AddChild(node);

            gw.Run(60.0);
        }
    }
}
