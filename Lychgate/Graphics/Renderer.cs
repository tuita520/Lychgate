// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// This class represents some high-level functionality for OpenGL Rendering.
    /// </summary>
    public class Renderer
    {
        /// <summary>
        /// 
        /// </summary>
        public Renderer()
        {
            GL.EnableClientState(ArrayCap.VertexArray);

        }
        /// <summary>
        /// Clears the OpenGL drawing screen.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        /// <summary>
        /// Draws the Buffers.
        /// </summary>
        public void DrawMesh(Mesh mesh)
        {
            GL.DrawElements(BeginMode.Lines, mesh.VertexCount, DrawElementsType.UnsignedByte, 0);
        }
    }
}

