using UnityEngine;

namespace Jacob_.Scripts
{
    public static class VoxelData
    {
        public static int chunkWidth = 32;
        public static int chunkLength = 32;
        public static int chunkHeight = 16;
        
        public static readonly Vector3[] voxelVerts = new Vector3[8]
        {
            new Vector3(0,0,0), //0
            new Vector3(1,0,0), //1
            new Vector3(1,1,0), //2
            new Vector3(1,1,1), //3
            new Vector3(0,1,1), //4
            new Vector3(0,0,1), //5
            new Vector3(0,1,0), //6
            new Vector3(1,0,1)  //7
        };

        public static readonly int[,] voxelTris = new int[6, 6]
        {
            {0,6,1,1,6,2},
            {5,4,0,0,4,6},
            {7,3,5,5,3,4},
            {1,2,7,7,2,3},
            {6,4,2,2,4,3},
            {1,7,0,0,7,5}
        };
    
        public static readonly Vector2[] voxelUvs = new Vector2[6]
        {
            new Vector2(0f,0f),
            new Vector2(0f,1f),
            new Vector2(1f,0f),
            new Vector2(1f,0f),
            new Vector2(0f,1f),
            new Vector2(1f,1f)
        };
    }
}
