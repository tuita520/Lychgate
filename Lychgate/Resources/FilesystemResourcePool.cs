// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System.IO;

namespace Sigon.Lychgate.Resources
{
    /// <summary>
    ///
    /// </summary>
    public class FilesystemResourcePool : ResourcePool
    {
        /// <summary>
        ///
        /// </summary>
        public override bool Open(string location)
        {
            return false;
        }

        /// <summary>
        ///
        /// </summary>
        public override void Close()
        {

        }

        /// <summary>
        ///
        /// </summary>
        public override Stream GetResourceByName(string name)
        {
            return null;
        }
    }
}