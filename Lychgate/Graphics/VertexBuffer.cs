// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK.Graphics.OpenGL;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class VertexBuffer : RenderBuffer
    {
        private Vertex[] vertices;
        /// <summary>
        /// 
        /// </summary>
        public int Size { get => vertices.Length; set { } }

        /// <summary>
        /// 
        /// </summary>
        public void AddBuffer(Vertex[] buffer)
        {
            vertices = buffer;
            GL.VertexPointer(3, VertexPointerType.Float, 0, vertices);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct Vertex
    {
        /// <summary>
        /// 
        /// </summary>
        public float x, y, z;
    }
}