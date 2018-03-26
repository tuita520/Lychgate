// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;

namespace Sigon.Lychgate.Graphics.Rendering
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
            var vbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(buffer.Length * Vertex.Stride), buffer, BufferUsageHint.StaticDraw);
            GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out int outval);
            if (outval == 0)
                throw new Exception("No Buffer data passed to Indexbuffer");

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
                throw new ArgumentNullException($"index data not found");

            var ibo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, new IntPtr(data.Length * sizeof(ushort)), data, BufferUsageHint.DynamicDraw);
            GL.GetBufferParameter(BufferTarget.ElementArrayBuffer, BufferParameterName.BufferSize, out int outval);
            if (outval == 0)
                throw new Exception("No Buffer data passed to Indexbuffer");

            return ibo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddColorBuffer(ref Color4[] data)
        {
            if (data == null)
                throw new ArgumentNullException($"index data not found");

            var cbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, cbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(data.Length * sizeof(int)*4), data, BufferUsageHint.DynamicDraw);
            GL.GetBufferParameter(BufferTarget.ElementArrayBuffer, BufferParameterName.BufferSize, out int outval);
            if (outval == 0)
                throw new Exception("No Buffer data passed to Indexbuffer");
            
            return cbo;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vbo"></param>
        /// <param name="ibo"></param>
        /// <param name="cbo"></param>
        /// <param name="count"></param>
        public static void RenderVertexBuffer(int vbo, int ibo, int cbo, int count)
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.VertexPointer(3, VertexPointerType.Float, Vertex.Stride, new IntPtr(0));
            GL.NormalPointer(NormalPointerType.Float, Vertex.Stride, new IntPtr(Vector3.SizeInBytes));
            GL.TexCoordPointer(2, TexCoordPointerType.Float, Vertex.Stride, new IntPtr(2 * Vector3.SizeInBytes));
            GL.BindBuffer(BufferTarget.ArrayBuffer, cbo);
            GL.ColorPointer(4, ColorPointerType.Float, 0, new IntPtr(0));
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);

            GL.DrawElements(PrimitiveType.Triangles, count, DrawElementsType.UnsignedShort, IntPtr.Zero);

            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.NormalArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);
            GL.DisableClientState(ArrayCap.ColorArray);
        }
    }
}