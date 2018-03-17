// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

namespace Sigon.Lychgate.Graphics
{
    public class SceneManager
    {
        private BaseWindow window;
        private Renderer renderer;
        public BaseWindow Window { get => window; set => window = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public void Update()
        {
        }
    }
}
