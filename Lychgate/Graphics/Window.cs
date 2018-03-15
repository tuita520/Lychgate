// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

namespace Sigon.Lychgate.Graphics
{
    public abstract class Window : IUpdateable
    {
        public abstract bool WindowActive { get; }
        public abstract void CreateWindow(int width, int height, bool fullscreen, string title);
        public abstract void Update();
    }
}
