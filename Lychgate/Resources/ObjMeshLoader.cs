// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using System.Collections.Generic;
using OpenTK;
using Sigon.Lychgate.Graphics;

namespace Sigon.Lychgate.Resources
{
    /// <summary>
    ///
    /// </summary>
    public class ObjMeshLoader : MeshLoader
    {
        /// <summary>
        ///
        /// </summary> 
        public ObjMeshLoader(ResourcePool pool) : base(pool) {}
        /// <summary>
        ///
        /// </summary>
        public override Mesh LoadMesh(string name)
        {
            var outMesh = new Mesh();
            var stream = ResourcePool.GetResourceByName(name, ResourceType.Ascii);
            var buf = stream.ToString();
            var positions = new List<Vector3>();
            var normals = new List<Vector3>();
            var texcoords = new List<Vector2>();

            string[] lines = buf.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);
            
            foreach (var line in lines) {
                string[] tokens = line.Split(' ');

                switch(tokens[0])
                {
                // Comments are ignored                
                case "#":
                    break;
                
                // Vertex Lines begin with v: "v <x> <y> <z>"
                case "v":
                    positions.Add(new Vector3(Convert.ToSingle(tokens[1]), Convert.ToSingle(tokens[2]), Convert.ToSingle(tokens[3])));
                    break;
                // Normal Lines begin with vn: "vn <x> <y> <z>"
                case "vn":
                    normals.Add(new Vector3(Convert.ToSingle(tokens[1]), Convert.ToSingle(tokens[2]), Convert.ToSingle(tokens[3])));
                    break;
                // TexCoord Lines begin with vt: "vt <x> <y>"
                case "vt":
                    texcoords.Add(new Vector2(Convert.ToSingle(tokens[1]), Convert.ToSingle(tokens[2])));
                    break;
                }
            }

            positions.CopyTo(outMesh.Vertices, 0);
            normals.CopyTo(outMesh.Normals, 0);
            texcoords.CopyTo(outMesh.TexCoords, 0);

            return outMesh;
        }
    }
}