// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information 

using OpenTK.Graphics.OpenGL;
using System.Runtime.CompilerServices;

namespace Sigon.Lychgate.Graphics.Rendering
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Renderer
    {
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
