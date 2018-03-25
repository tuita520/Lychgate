// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using System.Runtime.CompilerServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Sigon.Lychgate.Graphics.Renderer
{
    /// <summary>
    /// This class represents some high-level functionality for OpenGL Rendering.
    /// </summary>
    public static partial class Render
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CreateShaderProgram()
        {
            return GL.CreateProgram();
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CreateShaderObject(Shader.ShaderType type)
        {
            switch (type)
            {
                case Shader.ShaderType.VertexShader:
                    return GL.CreateShader(ShaderType.VertexShader);
                case Shader.ShaderType.FragmentShader:
                    return GL.CreateShader(ShaderType.FragmentShader);
                case Shader.ShaderType.GeometryShader:
                    return GL.CreateShader(ShaderType.GeometryShader);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShaderSource(int id, string source)
        {
            GL.ShaderSource(id, source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompileShader(int id)
        {
            GL.CompileShader(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="vid"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AttachShader(int pid, int vid)
        {
            GL.AttachShader(pid, vid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinkProgram(int pid)
        {
            GL.LinkProgram(pid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UseProgram(int pid)
        {
            GL.UseProgram(pid);
        }
    }
}

