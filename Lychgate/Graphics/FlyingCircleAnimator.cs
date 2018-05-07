// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    ///
    /// </summary>
    public class FlyingCircleAnimator : SceneNodeAnimator
    {
        /// <summary>
        ///
        /// </summary>
        public float Radius { get;set; }

        /// <summary>
        ///
        /// </summary>
        public override void Animate(SceneNode node)
        {
            if(node == null)
                return;
            //	node->setPosition(Center + Radius * ((VecU*cosf(time)) + (VecV*sinf(time))));
            //  node->setPosition(Center + (Radius*cosf(time)*VecU) + (r2*sinf(time)*VecV ) );
        }

    }
}