using System.Collections;
using System.Collections.Generic;
using Jacob_.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (TerrainGenerator))]
public class TerrainGeneratorEditor : Editor
{
    private TerrainGenerator mapGen;
    public override void OnInspectorGUI()
    {
        TerrainGenerator mapGen = (TerrainGenerator)target;
        DrawDefaultInspector();

        if (GUILayout.Button("generate"))
        {
            mapGen.terrainData.voxelMap = new bool[VoxelData.chunkWidth, VoxelData.chunkHeight, VoxelData.chunkLength];
            for (int z = 0; z < VoxelData.chunkLength; z++)
            {
                for (int x = 0; x < VoxelData.chunkWidth; x++)
                {
                    for (int y = 0; y < VoxelData.chunkHeight; y++)
                    {
                        mapGen.voxelMap[x, y, z] = false;
                        mapGen.voxelMap[x, 0, z] = true;
                    }
                }
            }
            mapGen.UpdateChunk();
            mapGen.meshCollider.sharedMesh = mapGen.mesh;
        }
        
        if (GUILayout.Button("Remove"))
        {
            mapGen.meshFilter.mesh = null;
            mapGen.meshCollider.sharedMesh = null;
        }
    }
    
    void OnSceneGUI()
    {
        mapGen = (TerrainGenerator)target;
        RaycastHit hit;
        Ray ray = HandleUtility.GUIPointToWorldRay( Event.current.mousePosition );

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            for (int i = -(mapGen.radius*2); i < (mapGen.radius*2); i++)
            {
                for (int p = -(mapGen.radius*2); p < (mapGen.radius*2); p++)
                {
                    if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && new Vector3(p,0,i).sqrMagnitude < (mapGen.radius*2))
                    {
                        mapGen.voxelMap[Mathf.FloorToInt(hit.point.x - mapGen.transform.position.x)+p,Mathf.FloorToInt(hit.point.y - mapGen.transform.position.y), Mathf.FloorToInt(hit.point.z - mapGen.transform.position.z)+i] = true;
                        mapGen.UpdateChunk();
                        mapGen.CreateMesh();
                    }
                    else if (Event.current.type == EventType.MouseDown && Event.current.button == 1 && new Vector3(p,0,i).sqrMagnitude < (mapGen.radius*2))
                    {
                        mapGen.voxelMap[Mathf.FloorToInt(hit.point.x - mapGen.transform.position.x)+p,Mathf.FloorToInt(hit.point.y - 0.01f - mapGen.transform.position.y), Mathf.FloorToInt(hit.point.z - mapGen.transform.position.z)+i] = false;
                        mapGen.UpdateChunk();
                        mapGen.CreateMesh();
                    }
                }
            }
        }
    }
}
