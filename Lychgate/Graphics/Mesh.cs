// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System.Buffers;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class Mesh
    {
        //List<TexCoordBufferRef> TexCoordBuffers;
        private PrimitiveType meshType;
        /// <summary>
        /// 
        /// </summary>
        public PrimitiveType MeshType { get => meshType; set => meshType = value; }
        //ColorBufferRef Colors;
        //NormalBufferRef Normals;
        //IndexBufferRef Indices;
        private VertexBuffer vertices;
        /// <summary>
        /// 
        /// </summary>
        public VertexBuffer Vertices { get => vertices; set => vertices = value; }

        private int vbo;
        private int size;

        /// <summary>
        /// 
        /// </summary>
        public int VertexCount { get => Vertices.Size; set { } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="buf"></param>
        public Mesh(ref PrimitiveType type, VertexBuffer buf)
        {
            MeshType = type; Vertices = buf;
            
            size = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices"></param>
        public void AddVertices(Vertex[] vertices)
        {
            vbo = Renderer.AddVertexBuffer(vertices);
            size = vertices.Length * 3;
        }

        //void AddTexCoordBuffer(TexCoordBufferRef ref)
        //{
        //    TexCoordBuffers.AddBottom(new TexCoordBufferRef(Ref));
        //}
    }
}
