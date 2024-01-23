using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private const float tileOffset = 0.866f;
    public float TileOffset => tileOffset;

    private static GameController instance;
    public static GameController Instance => instance;

    [SerializeField]
    private MaterialLookup materialLookup;
    public MaterialLookup MaterialLookup => materialLookup;

    [SerializeField]
    private TextureLookup textureLookup;
    public TextureLookup TextureLookup => textureLookup;

    [SerializeField]
    private Player currentPlayer;
    public Player CurrentPlayer => currentPlayer;

    private Vector3 mouseWorldPosition;
    public Vector3 MouseWorldPosition => mouseWorldPosition;

    private Plane plane = new Plane(Vector3.up, 0);

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    private void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            mouseWorldPosition = ray.GetPoint(distance);
        }
    }
}
