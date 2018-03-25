// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK.Graphics;
using Sigon.Lychgate.Graphics.Renderer;
using System.Runtime.CompilerServices;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class Mesh
    {
        private Vertex[] _vertices;
        private ushort[] _indices;
        private Color4[] _colors;
        private int _vbo, _ibo, _cbo;

        /// <summary>
        /// 
        /// </summary>
        public Vertex[] Vertices { get => _vertices; set => _vertices = value; }

        /// <summary>
        /// 
        /// </summary>
        public ushort[] Indices { get => _indices; set => _indices = value; }

        /// <summary>
        /// 
        /// </summary>
        public Color4[] Colors { get => _colors; set => _colors = value; }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetBuffers()
        {
            _vbo = Render.AddVertexBuffer(ref _vertices);
            _ibo = Render.AddIndexBuffer(ref _indices);
            _cbo = Render.AddColorBuffer(ref _colors);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Draw()
        {
            Render.RenderVertexBuffer(_vbo, _ibo, _cbo, _indices.Length);
        }
    }
}
