// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using System.Collections.Generic;

namespace Sigon.Lychgate.Graphics
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class SceneNode : IDisposable
    {
        private readonly List<SceneNode> _nodeList;
        
        /// <summary>
        /// 
        /// </summary>
        public SceneNode()
        {
            _nodeList = new List<SceneNode>();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Draw()
        {
            foreach (var node in _nodeList)
                node.Draw();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Update()
        {
            // loop through the list and update the children
            foreach (var node in _nodeList)
                node.Update();
        }

        /// <summary>
        /// destroy all the children
        /// </summary>
        public virtual void Destroy()
        {
            foreach (var node in _nodeList)
                node.Dispose();

            _nodeList.Clear();
        }

        /// <summary>
        /// add a child to our custody
        /// </summary>
        /// <param name="node"></param>
        public virtual void AddChild(SceneNode node)
        {
            _nodeList.Add(node);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public virtual void Dispose()
        {

        }
    }
}
