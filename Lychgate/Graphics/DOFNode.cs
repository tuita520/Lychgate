// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace Sigon.Lychgate.Graphics
{

    /// <summary>
    /// Translation or DOF (Degrees of Freedom) Node which represents Matrix manipulation of objects in the 3D World.
    /// </summary>
    public class DofNode : SceneNode, IDisposable
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

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public DofNode()
        {
            
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override void Draw()
        {
            var matrix = Matrix4.Identity;
            
            matrix *= Matrix4.CreateRotationX(RotationX);
            matrix *= Matrix4.CreateRotationY(RotationY);
            matrix *= Matrix4.CreateRotationZ(RotationZ);
            matrix *= Matrix4.CreateTranslation(Position);
            GL.PushMatrix();
            
            GL.LoadMatrix(ref matrix);
            base.Draw();
            GL.PopMatrix();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();
        }        
    }
}
