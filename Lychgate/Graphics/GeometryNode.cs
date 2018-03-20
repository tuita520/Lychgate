// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class GeometryNode : SceneNode, IDisposable
    {
        private Mesh nodeMesh;
        /// <summary>
        /// 
        /// </summary>
        public Mesh NodeMesh { get => nodeMesh; set => nodeMesh = value; }

        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            NodeMesh.Draw();
            base.Draw(); 
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            // Update our geometry here...
            base.Update();
        }
    }
}
