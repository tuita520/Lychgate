// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using System.Diagnostics;

namespace Sigon.Lychgate.Graphics
{
    public class SceneManager
    {
        private Window window;
        private Renderer renderer;
        public Window Window { get => window; set => window = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public SceneManager(BackendType backend)
        {
            switch (backend)
            {
                case BackendType.OpenTK:
                    Debug.WriteLine("OpenTK Backend selected...");
                    Window = new OpenTKWindow();
                    Renderer = new OpenGLRenderer();
                    break;
                default:
                    Debug.WriteLine("Not supported BackendType selected...");
                    throw new NotImplementedException();
            }
        }
        public void Update()
        {
        }
    }
}
