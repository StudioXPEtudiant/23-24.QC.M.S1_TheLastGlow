using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

namespace Jacob_.Scripts
{
    public class TerrainGenerator : MonoBehaviour
    {
        public MeshRenderer meshRenderer;
        public MeshFilter meshFilter;
        public MeshCollider meshCollider;
        public int radius;
        
        private static int vertexIndex = 0;
        private static List<Vector3> vertices = new List<Vector3>();
        private static List<int> triangles= new List<int>();
        private static List<Vector2> uvs = new List<Vector2>();
        public Mesh mesh;
        public bool[,,] voxelMap = new bool[VoxelData.chunkWidth, VoxelData.chunkHeight, VoxelData.chunkLength];
        public ScriptableObjTerrainData terrainData;
        public void UpdateChunk()
        {
            ClearMeshData();
            for (int z = 0; z < VoxelData.chunkLength; z++)
            {
                for (int x = 0; x < VoxelData.chunkWidth; x++)
                {
                    for (int y = 0; y < VoxelData.chunkHeight; y++)
                    {
                        CreateCube(x,y,z);
                    }
                }
            }
            CreateMesh();
        }

        public void ClearMeshData()
        {
            vertexIndex = 0;
            vertices.Clear();
            triangles.Clear();
            uvs.Clear();
            meshFilter.mesh = null;
            meshCollider.sharedMesh = null;
        }
        
        public void CreateCube(int x, int y, int z)
        {
            if (voxelMap[x, y, z])
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int p = 0; p < 6; p++)
                    {
                        int triangleIndex = VoxelData.voxelTris[i, p];
                        vertices.Add(VoxelData.voxelVerts[triangleIndex] + new Vector3(x, y, z));
                        triangles.Add(vertexIndex);
                        voxelMap[x, y, z] = true;

                        uvs.Add(Vector2.zero);
                        vertexIndex++;
                    }
                }
            }
        }

        public void CreateMesh()
        {
            mesh = new Mesh();
            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.RecalculateNormals();
            
            meshFilter.mesh = mesh;
            meshCollider.sharedMesh = mesh;
        }
    }
}
