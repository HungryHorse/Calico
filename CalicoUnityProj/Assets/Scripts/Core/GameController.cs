using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance => instance;

    [SerializeField]
    private MaterialLookup materialLookup;
    public MaterialLookup MaterialLookup => materialLookup;

    [SerializeField]
    private TextureLookup textureLookup;
    public TextureLookup TextureLookup => textureLookup;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }
}
