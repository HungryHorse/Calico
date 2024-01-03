using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextureData", menuName = "ScriptableObjects/Texture Lookup", order = 2)]
public class TextureLookup : ScriptableObject
{
    [SerializeField]
    private Texture[] textures;
    public Texture[] Textures => textures;
}
