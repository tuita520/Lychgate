// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK.Graphics;

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

        /// <summary>
        /// 
        /// </summary>
        public ref Vertex[] Vertices => ref _vertices;

        /// <summary>
        /// 
        /// </summary>
        public ref ushort[] Indices => ref _indices;

        /// <summary>
        /// 
        /// </summary>
        public ref Color4[] Colors => ref _colors;

        /// <summary>
        /// 
        /// </summary>
        public int VertexBufferId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IndexBufferId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ColorBufferId { get; set; }
    }
}
