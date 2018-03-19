// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace Sigon.Lychgate.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Renderer
    {
        /// <summary>
        /// Adds a <see cref="Vertex"/>Array to the OpenGL Subsystem
        /// </summary>
        /// <param name="buffer">The Vertexarray to be passed</param>
        /// <returns>The Vertexbuffer Object</returns>
        public static int AddVertexBuffer(ref Vertex[] buffer)
        {
            int vbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(buffer.Length * Vertex.Stride), buffer, BufferUsageHint.StaticDraw);

            return vbo;
        }

        /// <summary>
        /// Sets the Indexbuffer
        /// </summary>
        /// <param name="data">The indices to be set</param>
        /// <returns></returns>
        public static int AddIndexBuffer(ref ushort[] data)
        {
            if (data == null)
                throw new ArgumentNullException("index data not found");

            int ibo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, new IntPtr(data.Length * sizeof(ushort)), data, BufferUsageHint.DynamicDraw);

            return ibo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vbo"></param>
        /// <param name="ibo"></param>
        /// <param name="count"></param>
        public static void RenderVertexBuffer(int vbo, int ibo, int count)
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);
            GL.VertexPointer(3, VertexPointerType.Float, Vertex.Stride, new IntPtr(0));
            GL.NormalPointer(NormalPointerType.Float, Vertex.Stride, new IntPtr(Vector3.SizeInBytes));
            GL.TexCoordPointer(2, TexCoordPointerType.Float, Vertex.Stride, new IntPtr(2 * Vector3.SizeInBytes));

            GL.DrawElements(BeginMode.Triangles, count, DrawElementsType.UnsignedInt, ibo);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.NormalArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);
        }
    }
}