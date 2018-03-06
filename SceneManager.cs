// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;

namespace Sigon.Lychgate.Graphics
{
    public class SceneManager
    {
        public VideoDriver VideoDriver
        {
            get { return videoDriver; }
            set { videoDriver = value; }
        }
        private VideoDriver videoDriver;

        public SceneManager(DriverType type)
        {
            switch(type) {
                case DriverType.OpenGL:
                // VideoDrv = new OpenGLVideoDriver();
                    break;
                case DriverType.DirectX:
                // VideoDrv = new DirectXVideoDriver();
                    break;
            }
        }
    }
}
