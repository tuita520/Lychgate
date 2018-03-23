// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Runtime.CompilerServices;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class Mesh
    {
        private Vertex[] vertices;
        private ushort[] indices;
        private Color4[] colors;
        private int vbo, ibo, cbo;

        /// <summary>
        /// 
        /// </summary>
        public Vertex[] Vertices { get => vertices; set => vertices = value; }

        /// <summary>
        /// 
        /// </summary>
        public ushort[] Indices { get => indices; set => indices = value; }

        /// <summary>
        /// 
        /// </summary>
        public Color4[] Colors { get => colors; set => colors = value; }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetBuffers()
        {
            vbo = Renderer.AddVertexBuffer(ref vertices);
            ibo = Renderer.AddIndexBuffer(ref indices);
            cbo = Renderer.AddColorBuffer(ref colors);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Draw()
        {
            Renderer.RenderVertexBuffer(vbo, ibo, cbo, indices.Length);
        }
    }
}
