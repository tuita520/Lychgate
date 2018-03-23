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
    public class DOFNode : SceneNode, IDisposable
    {
        private Matrix4 matrix;

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
        public DOFNode()
        {
            matrix = new Matrix4();
            matrix = Matrix4.Identity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public DOFNode(Matrix4 m)
        {
            matrix = m;
        }



        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            base.Draw();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetMatrix()
        {
            matrix *= Matrix4.CreateTranslation(Position);
            matrix *= Matrix4.CreateRotationX(RotationX);
            matrix *= Matrix4.CreateRotationY(RotationY);
            matrix *= Matrix4.CreateRotationZ(RotationZ);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            GL.PushMatrix();
            SetMatrix();
            GL.LoadMatrix(ref matrix);
            base.Update();

            GL.PopMatrix();
        }        
    }
}
