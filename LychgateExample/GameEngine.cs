// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using Sigon.Lychgate;
using Sigon.Lychgate.Graphics;

namespace Sigon.LychgateExample
{
    public class GameEngine : Engine
    {
        public GameEngine(BackendType backend) : base(backend) { }

        public override void Loop() {
            base.Loop();

            if (SceneManager.Window.KeyPressed == Key.A)
                Console.WriteLine("A-Key Pressed");

            if (SceneManager.Window.KeyPressed == Key.B)
                Console.WriteLine("B-Key Pressed");

            if (SceneManager.Window.KeyPressed == Key.C)
                Console.WriteLine("C-Key Pressed");
        }
    }
}
