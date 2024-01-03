using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialData", menuName = "ScriptableObjects/Material Lookup", order = 1)]
public class MaterialLookup : ScriptableObject
{
    [SerializeField]
    private Material[] materials;
    private Material[] Materials => materials;
}
