// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using System.Diagnostics;
using Sigon.Lychgate.Graphics;

namespace Sigon.Lychgate
{
    public class Engine
    {
        private const int VER_MAJOR = 0;
        private const int VER_MINOR = 1;
        private const int VER_PLVL = 0;
        private const string VER_ADD = "-pre-alpha1";
        private const int API_VER = 20180314;
        private bool run;

        public bool Run { get => run; set => run = value; }

        public Engine()
        {
            Debug.WriteLine("Starting Lychgate 3D-Engine Version: " + VER_MAJOR + "." + VER_MINOR + "." + VER_PLVL + VER_ADD + " API: " + API_VER);
        }

        public void Init(BackendType backend)
        {
        }
    }

    public enum BackendType
    {
        OpenTK
    }
}
