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
    public class MeshSceneNode : SceneNode, IDisposable
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
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetBuffers()
        {
            NodeMesh.VertexBufferId = Renderer.AddVertexBuffer(ref NodeMesh.Vertices);
            NodeMesh.IndexBufferId = Renderer.AddIndexBuffer(ref NodeMesh.Indices);
            NodeMesh.ColorBufferId = Renderer.AddColorBuffer(ref NodeMesh.Colors);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Renderer.SetTransformation(AbsolutePosition);
            Renderer.RenderVertexBuffer(NodeMesh.VertexBufferId, NodeMesh.IndexBufferId, NodeMesh.ColorBufferId, NodeMesh.Indices.Length);
            base.Draw(); 
        }
    }
}
