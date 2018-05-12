// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// The Class Mesh is soleley build out of properties which represent the data of the Mesh.
    /// </summary>
    public class Mesh
    {
        /// <summary>
        /// The Vertices of the Mesh as array of Vertex structures.
        /// </summary>
        public Vector3[] Vertices {get;set;}

       /// <summary>
        /// The Vertices of the Mesh as array of Vertex structures.
        /// </summary>
        public Vector3[] Normals {get;set;}

       /// <summary>
        /// The Vertices of the Mesh as array of Vertex structures.
        /// </summary>
        public Vector2[] TexCoords {get;set;}
        /// <summary>
        /// The Indices of the Mesh as an array of unsigned short integers.
        /// </summary>
        public ushort[] Indices {get;set;}

        /// <summary>
        /// The Colors of each Vertex as an array of Color4 structures.
        /// </summary>
        public Color4[] Colors {get;set;}

        /// <summary>
        /// The VBO Id.
        /// </summary>
        public int VertexBufferId { get; set; }

        /// <summary>
        /// The VBO Id.
        /// </summary>
        public int NormalBufferId { get; set; }

        /// <summary>
        /// The VBO Id.
        /// </summary>
        public int TexCoordBufferId { get; set; }

        /// <summary>
        /// The IBO Id.
        /// </summary>
        public int IndexBufferId { get; set; }

        /// <summary>
        /// The CBO Id.
        /// </summary>
        public int ColorBufferId { get; set; }
    }
}
