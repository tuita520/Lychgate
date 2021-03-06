// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System.IO;

namespace Sigon.Lychgate.Resources
{
    /// <summary>
    ///
    /// </summary>
    public abstract class ResourcePool
    {
        /// <summary>
        ///
        /// </summary>
        public abstract bool Open(string location);

        /// <summary>
        ///
        /// </summary>
        public abstract void Close();

        /// <summary>
        ///
        /// </summary>        
        public abstract MemoryStream GetResourceByName(string name, ResourceType type);
    }

    /// <summary>
    ///
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        ///
        /// </summary>
        Binary,
        /// <summary>
        ///
        /// </summary>
        Ascii
    }
}