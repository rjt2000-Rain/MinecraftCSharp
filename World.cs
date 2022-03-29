using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace MinecraftSharp
{
    class World
    {
        private const short Chunk_Radius = 15;
        private const short Sea_Level = 30;
        private Chunk Center;
        private Chunk[] Quad1 = new Chunk[Chunk_Radius * Chunk_Radius];//north
        private Chunk[] Quad2 = new Chunk[Chunk_Radius * Chunk_Radius];
        private Chunk[] Quad3 = new Chunk[Chunk_Radius * Chunk_Radius];
        private Chunk[] Quad4 = new Chunk[Chunk_Radius * Chunk_Radius];

        public World()
        {
            Center = new Chunk(new Vector3D(0, 0, 0));
            QuadFill(Quad1);
            QuadFill(Quad2);
            QuadFill(Quad3);
            QuadFill(Quad4);

        }

        private void QuadFill(Chunk[] chunks)
        {

        }

        private void ChunkFill(Chunk chunk)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int z = 0; z < 16; z++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        chunk.AddBlock(new Block(new Vector3D(x, y, z)));
                    }
                }
            }
        }
    }
}
