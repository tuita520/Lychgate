// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using System.Collections.Generic;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class SceneNode : IDisposable
    {
        private List<SceneNode> nodeList;
        
        /// <summary>
        /// 
        /// </summary>
        public SceneNode()
        {
            nodeList = new List<SceneNode>();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Update()
        {
            // loop through the list and update the children
            foreach (SceneNode node in nodeList)
                node.Update();
        }

        /// <summary>
        /// destroy all the children
        /// </summary>
        public virtual void Destroy()
        {
            foreach (SceneNode node in nodeList)
                node.Dispose();

            nodeList.Clear();
        }

        /// <summary>
        /// add a child to our custody
        /// </summary>
        /// <param name="node"></param>
        public virtual void AddChild(SceneNode node)
        {
            nodeList.Add(node);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose()
        {

        }
    }
}
