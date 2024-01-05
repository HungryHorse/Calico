using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseTile
{
    public Material FaceMaterial { get; }

    public Texture FaceTexture { get; }
}
