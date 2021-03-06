﻿// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Runtime.CompilerServices;

namespace Sigon.Lychgate.Graphics.Rendering
{
    /// <summary>
    /// This class represents some high-level functionality for OpenGL Rendering.
    /// </summary>
    public static partial class Renderer
    {
        /// <summary>
        /// Initializes the OpenGL Subsystem, clears the screen and sets Backface-culling
        /// </summary>
        public static void Init()
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.LoadIdentity();
            ClearScreen();

            // Enable counter-clock-wise Back-Face Culling
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Ccw);
        }

        /// <summary>
        /// Clears the OpenGL drawing screen.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transformation"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTransformation(Matrix4 transformation)
        {
            GL.LoadMatrix(ref transformation);
        }

       
    }
}

