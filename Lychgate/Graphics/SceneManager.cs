// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System.Runtime.CompilerServices;
using Sigon.Lychgate.Graphics.Rendering;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// Implements a Scene Graph and functionality to manipulate it.
    /// </summary>
    public sealed class SceneManager : SceneNode
    {
        /// <summary>
        /// 
        /// </summary>
        public SceneManager()
        {
            PreRenderHook += OnPreRender;
        }
        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OnPreRender()
        {
            Renderer.ClearScreen();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="mesh"></param>
        public MeshSceneNode AddMeshSceneNode(SceneNode parent, Mesh mesh)
        {
            var node = new MeshSceneNode(mesh);

            if (parent != null)
                parent.AddChild(node);
            else
                AddChild(node);

            return node;
        }
    }
}
