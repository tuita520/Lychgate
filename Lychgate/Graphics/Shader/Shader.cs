// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information 

namespace Sigon.Lychgate.Graphics.Shader
{
    /// <summary>
    /// 
    /// </summary>
    public struct Shader
    {
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ShaderType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ShaderId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ShaderType
    {
        /// <summary>
        /// 
        /// </summary>
        VertexShader,
        /// <summary>
        /// 
        /// </summary>
        FragmentShader,
        /// <summary>
        /// 
        /// </summary>
        GeometryShader
    }
}