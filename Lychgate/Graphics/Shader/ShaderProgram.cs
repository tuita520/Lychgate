// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information 

using System.Collections.Generic;
using System.IO;
using Sigon.Lychgate.Graphics.Renderer;

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
            _pobj = Render.CreateShaderProgram();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        public void AddShader(Shader shader)
        {
            var sr = new StreamReader(shader.Source);

            shader.ShaderId = Render.CreateShaderObject(shader.Type);
            Render.ShaderSource(shader.ShaderId, sr.ReadToEnd());
            Render.CompileShader(shader.ShaderId);
            Render.AttachShader(_pobj, shader.ShaderId);

            _shaderList.Add(shader);
            
        }
    }
}
