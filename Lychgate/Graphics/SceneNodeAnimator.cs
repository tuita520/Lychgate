// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SceneNodeAnimator
    {
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float RotationX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float RotationY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float RotationZ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public abstract void Animate(SceneNode node);
    }
}
