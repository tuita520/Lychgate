// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Runtime.InteropServices;

namespace Sigon.Lychgate.Graphics.Rendering
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Renderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="buffer">The Vertexarray to be passed</param>
        /// <returns>The Vertexbuffer Object</returns>
        public static int AddVertexBuffer(Vector3[] buffer)
        {
            if(buffer == null)
                return 0;

            var vbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(buffer.Length * Marshal.SizeOf(default(Vector3))), buffer, BufferUsageHint.StaticDraw);
            GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out int outval);
            if (outval == 0)
                throw new Exception("No Buffer data passed to Indexbuffer");

            return vbo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer">The Vertexarray to be passed</param>
        /// <returns>The Vertexbuffer Object</returns>
        public static int AddNormalBuffer(Vector3[] buffer)
        {
            if(buffer == null)
                return 0;
                
            var nbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, nbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(buffer.Length * Marshal.SizeOf(default(Vector3))), buffer, BufferUsageHint.StaticDraw);
            GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out int outval);
            if (outval == 0)
                throw new Exception("No Buffer data passed to Indexbuffer");

            return nbo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer">The Vertexarray to be passed</param>
        /// <returns>The Vertexbuffer Object</returns>
        public static int AddTexCoordBuffer(Vector2[] buffer)
        {
            if(buffer == null)
                return 0;
                
            var tcbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, tcbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(buffer.Length * Marshal.SizeOf(default(Vector2))), buffer, BufferUsageHint.StaticDraw);
            GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out int outval);
            if (outval == 0)
                throw new Exception("No Buffer data passed to Indexbuffer");

            return tcbo;
        }


        /// <summary>
        /// Sets the Indexbuffer
        /// </summary>
        /// <param name="data">The indices to be set</param>
        /// <returns></returns>
        public static int AddIndexBuffer(ushort[] data)
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
        public static int AddColorBuffer(Color4[] data)
        {
            if (data == null)
                throw new ArgumentNullException($"index data not found");

            var cbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, cbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(data.Length * sizeof(int)*4), data, BufferUsageHint.DynamicDraw);
            GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out int outval);
            if (outval == 0)
                throw new Exception("No Buffer data passed to Indexbuffer");
            
            return cbo;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vbo"></param>
        /// <param name="nbo"></param>
        /// <param name="tcbo"></param>
        /// <param name="ibo"></param>
        /// <param name="cbo"></param>
        /// <param name="count"></param>
        public static void RenderBuffers(int vbo, int nbo, int tcbo, int ibo, int cbo, int count)
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.VertexPointer(3, VertexPointerType.Float, Marshal.SizeOf(default(Vector3)), new IntPtr(0));
            GL.BindBuffer(BufferTarget.ArrayBuffer, nbo);
            GL.NormalPointer(NormalPointerType.Float, Marshal.SizeOf(default(Vector3)), new IntPtr(0));
            GL.BindBuffer(BufferTarget.ArrayBuffer, tcbo);
            GL.TexCoordPointer(2, TexCoordPointerType.Float, Marshal.SizeOf(default(Vector3)), new IntPtr(0));
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