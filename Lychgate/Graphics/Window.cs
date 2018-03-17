// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

namespace Sigon.Lychgate.Graphics
{
    public abstract class Window
    {
        public abstract Key KeyPressed { get; set; }
        public abstract bool WindowActive { get; set; }
        public abstract void CreateWindow(int width, int height, bool fullscreen, string title);
        public abstract void EndFrame();
    }

    public enum Key
    {
        A=1,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z
    }
}
