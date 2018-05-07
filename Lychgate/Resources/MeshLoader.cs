// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using Sigon.Lychgate.Graphics;

namespace Sigon.Lychgate.Resources
{
    /// <summary>
    ///
    /// </summary>
    public abstract class MeshLoader
    {
        /// <summary>
        ///
        /// </summary>
        public ResourcePool ResourcePool;

        /// <summary>
        ///
        /// </summary>
        public MeshLoader(ResourcePool pool)
        {
            ResourcePool = pool;
        }

        /// <summary>
        ///
        /// </summary>
        public abstract Mesh LoadMesh(string name);
    }
}