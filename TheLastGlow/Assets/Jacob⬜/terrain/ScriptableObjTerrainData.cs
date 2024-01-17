using System.Collections;
using System.Collections.Generic;
using Jacob_.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrainData", menuName = "Create TerrainData")]
public class ScriptableObjTerrainData : ScriptableObject
{
    public bool[,,] voxelMap;
}
