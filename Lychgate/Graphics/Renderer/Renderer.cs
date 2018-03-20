// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK.Graphics.OpenGL;
using System.Runtime.CompilerServices;

namespace Sigon.Lychgate.Graphics
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
            ClearScreen();

            // Enable counter-clock-wise Back-Face Culling
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Cw);
        }

        /// <summary>
        /// Clears the OpenGL drawing screen.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}

