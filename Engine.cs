// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;

namespace Sigon.Lychgate
{
    public class GameEngine
    {
        public Graphics.SceneManager SceneManager
        {
            get { return sceneManager; }
        }
        private readonly Graphics.SceneManager sceneManager;

        public GameEngine(Graphics.DriverType dt)
        {
            sceneManager = new Graphics.SceneManager(dt);
        }        
    }
}
