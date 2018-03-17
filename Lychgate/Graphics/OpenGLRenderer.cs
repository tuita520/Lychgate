// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Sigon.Lychgate.Graphics
{
    public class OpenGLRenderer : Renderer
    {
        private GraphicsContext context;
        public GraphicsContext Context { get => context; set => context = value; }

        public override void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public override void Draw()
        {
        
        }
    }
}

