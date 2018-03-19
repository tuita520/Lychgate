// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

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
        private int vbo, ibo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Vertex this[int n]
        {
            get => vertices[n];
            set => vertices.SetValue(value, vertices.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetBuffers()
        {
            vbo = Renderer.AddVertexBuffer(ref vertices);
            ibo = Renderer.AddIndexBuffer(ref indices);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Draw()
        {
            Renderer.RenderVertexBuffer(vbo, ibo, indices.Length);
        }
    }
}
