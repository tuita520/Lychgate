// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using OpenTK;

namespace Sigon.LychgateExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameWindow gw = new GameWindow();
            gw.CreateWindow(800, 600, false, "Lychgate Test");
            gw.Run(60);

        }
    }
}
