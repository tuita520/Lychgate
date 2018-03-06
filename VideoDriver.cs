// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

namespace Sigon.Lychgate.Graphics
{
    public abstract class VideoDriver
    {
        public VideoDriver()
        {
        }

        public abstract void Draw2D();
    }

    public enum DriverType {
        OpenGL,
        DirectX
    }
}
