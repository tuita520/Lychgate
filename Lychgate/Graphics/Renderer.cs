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
    public static class Renderer
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Init()
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            // Enable counter-clock-wise Back-Face Culling
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Cw);

            GL.EnableClientState(ArrayCap.VertexArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static int AddVertexBuffer(Vertex[] buffer)
        {
            int vbo = GL.GenBuffer();
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, (buffer.Length * 3), buffer, BufferUsageHint.StaticDraw);
            return vbo;
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
        /// Draws the Buffers.
        /// </summary>
        public static void DrawMesh(Mesh mesh)
        {
            GL.DrawElements(BeginMode.Lines, mesh.VertexCount, DrawElementsType.UnsignedByte, 0);
        }
    }
}

