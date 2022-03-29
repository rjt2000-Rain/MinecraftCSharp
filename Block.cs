using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace MinecraftSharp
{
    class Block
    {
        public Vector3D LocalCoord;
        public bool Transparent;
        public Chunk Parent;
        public bool Render = true;

        public Block(Vector3D coord)
        {
            LocalCoord = coord;
        }
    }
}
