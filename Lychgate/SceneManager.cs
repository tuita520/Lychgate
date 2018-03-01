// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;

namespace Sigon.Lychgate.Graphics
{
    public class SceneManager
    {
        public SceneManager(DriverType type)
        {
            switch(type) {
                case DriverType.DRV_OPENGL:
                // VideoDrv = new OpenGLVideoDriver();
                    break;
                case DriverType.DRV_DIRECTX:
                // VideoDrv = new DirectXVideoDriver();
                    break;
            }
        }


        public VideoDriver VideoDrv {
            get { return _videoDriver; }
            set { _videoDriver = value; }
        }
        private VideoDriver _videoDriver;
    }
}
