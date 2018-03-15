// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

namespace Sigon.Lychgate.Graphics
{
    public class SceneManager : IUpdateable
    {
        public VideoDriver VideoDriver
        {
            get { return videoDriver; }
            set { videoDriver = value; }
        }
        private VideoDriver videoDriver;

        public void Update()
        {
            // Update the world and pass everything to the VideoDriver
            VideoDriver.Draw();
        }
    }
}
