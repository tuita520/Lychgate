// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information 

using Sigon.Lychgate.Graphics.Rendering;
using System.Collections.Generic;
using System.IO;

namespace Sigon.Lychgate.Graphics.Shader
{
    /// <summary>
    /// 
    /// </summary>
    public class ShaderProgram
    {
        private int _pobj;
        /// <summary>
        /// 
        /// </summary>
        private readonly List<Shader> _shaderList;

        /// <summary>
        /// 
        /// </summary>
        public ShaderProgram()
        {
            _shaderList = new List<Shader>();
            _pobj = Renderer.CreateShaderProgram();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        public void AddShader(Shader shader)
        {
            var sr = new StreamReader(shader.Source);

            shader.ShaderId = Renderer.CreateShaderObject(shader.Type);
            Renderer.ShaderSource(shader.ShaderId, sr.ReadToEnd());
            Renderer.CompileShader(shader.ShaderId);
            Renderer.AttachShader(_pobj, shader.ShaderId);

            _shaderList.Add(shader);
            
        }
    }
}
