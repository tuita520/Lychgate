// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using System;
using System.Collections.Generic;

namespace Sigon.Lychgate.Graphics
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class SceneNode : IDisposable
    {
        private Matrix4 _relativeTransformation;
        private readonly List<SceneNode> _nodeList;
        private readonly List<SceneNodeAnimator> _animatorList;

        private Vector3 _relativePosition;
        private Vector3 _relativeRotation;
        private Vector3 _relativeScale;
        /// <summary>
        /// 
        /// </summary>
        public ref Vector3 RelativePosition => ref _relativePosition;

        /// <summary>
        /// 
        /// </summary>
        public ref Vector3 RelativeRotation => ref _relativeRotation;

        /// <summary>
        /// 
        /// </summary>
        public ref Vector3 RelativeScale => ref _relativeScale;

        /// <summary>
        /// 
        /// </summary>
        public virtual Matrix4 AbsolutePosition
        {
            get
            {
                GetRelativeTransformation();
                if (Parent == null)
                    return _relativeTransformation;

                return Parent.AbsolutePosition * _relativeTransformation;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SceneNode Parent { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected SceneNode()
        {
            Parent = null;
            _relativeTransformation = Matrix4.Identity;
            _nodeList = new List<SceneNode>();
            _animatorList = new List<SceneNodeAnimator>();
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
            foreach (var anim in _animatorList)
                anim.Animate(this);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anim"></param>
        public virtual void AddAnimator(SceneNodeAnimator anim)
        {
            _animatorList.Add(anim);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public virtual void Dispose()
        {

        }
        
        /// <summary>
        /// 
        /// </summary>
        protected virtual void GetRelativeTransformation()
        {
            _relativeTransformation = Matrix4.CreateRotationX(RelativeRotation.X);
            _relativeTransformation *= Matrix4.CreateRotationY(RelativeRotation.Y);
            _relativeTransformation *= Matrix4.CreateRotationZ(RelativeRotation.Z);
            _relativeTransformation *= Matrix4.CreateTranslation(RelativePosition);
           // _relativeTransformation *= Matrix4.CreateScale(RelativeScale);
        }
    }
}
