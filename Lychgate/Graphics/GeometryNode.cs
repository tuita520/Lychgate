﻿// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using Sigon.Lychgate.Graphics.Renderer;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class GeometryNode : SceneNode, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public Mesh NodeMesh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Render.SetTransformation(AbsolutePosition);
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
