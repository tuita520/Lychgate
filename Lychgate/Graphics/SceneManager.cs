// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System.Runtime.CompilerServices;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// Implements a Scene Graph and functionality to manipulate it.
    /// </summary>
    public class SceneManager
    {
        private SceneNode rootNode;

        /// <summary>
        /// 
        /// </summary>
        public SceneNode RootNode { get => rootNode; set => rootNode = value; }

        /// <summary>
        /// 
        /// </summary>
        public SceneManager()
        {
            RootNode = new SceneNode();
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Draw()
        {
            RootNode.Draw();
        }


        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Update()
        {
            RootNode.Update();
        }
    }
}
