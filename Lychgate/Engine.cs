// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;

namespace Sigon.Lychgate
{
    public class GameEngine
    {
        public GameEngine(Graphics.DriverType dt)
        {
            _sceneManager = new Graphics.SceneManager(dt);
        }

        public Graphics.SceneManager SceneMgr
        {
            get { return _sceneManager; }
        }
        private readonly Graphics.SceneManager _sceneManager;
        
    }
}
