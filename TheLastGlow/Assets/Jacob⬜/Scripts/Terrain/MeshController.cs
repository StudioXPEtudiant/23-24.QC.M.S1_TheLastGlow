using System;
using System.Collections;
using System.Collections.Generic;
using Jacob_.Scripts;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[ExecuteInEditMode]
public class MeshController : MonoBehaviour
{
    [Range(0f, 20f)]
    public static int radius = 1;
    [Range(0f, 5f)]
    public static float strength = 1;
    
    TerrainGenerator mapGen;
}
