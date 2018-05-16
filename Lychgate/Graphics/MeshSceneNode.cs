// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using Sigon.Lychgate.Graphics.Rendering;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class MeshSceneNode : SceneNode
    {
        /// <summary>
        /// 
        /// </summary>
        public Mesh NodeMesh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        public MeshSceneNode(Mesh mesh)
        {
            NodeMesh = mesh;
            SetBuffers();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetBuffers()
        {
            NodeMesh.VertexBufferId = Renderer.AddVertexBuffer(NodeMesh.Vertices);
            NodeMesh.NormalBufferId = Renderer.AddNormalBuffer(NodeMesh.Normals);
            NodeMesh.TexCoordBufferId = Renderer.AddTexCoordBuffer(NodeMesh.TexCoords);
            NodeMesh.IndexBufferId = Renderer.AddIndexBuffer(NodeMesh.Indices);
            NodeMesh.ColorBufferId = Renderer.AddColorBuffer(NodeMesh.Colors);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Renderer.SetTransformation(AbsolutePosition);
            Renderer.RenderBuffers(NodeMesh.VertexBufferId, NodeMesh.NormalBufferId, NodeMesh.TexCoordBufferId, NodeMesh.IndexBufferId, NodeMesh.ColorBufferId, NodeMesh.Indices.Length);
            base.Draw(); 
        }
    }
}
