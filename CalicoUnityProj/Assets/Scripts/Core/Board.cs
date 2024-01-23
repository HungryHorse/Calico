using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject TilePrefab;

    [SerializeField]
    private Transform boardOrigin;

    [SerializeField]
    private BaseTile[,] tilePositions = new BaseTile[7,7];

    [SerializeField]
    private float yTilePos;

    public void BuildBoard()
    {
          
    }

    public Vector3 GetClosestSnapPosition(Vector3 position)
    {
        Vector3 snapPosition = Vector3.zero;

        return snapPosition;
    }

    public void PlaceTile(MoveableTile tile)
    {
        Vector3 tilePosition = GetClosestSnapPosition(tile.transform.position);
        tilePosition.y = yTilePos;
        tile.MoveToPosition(tilePosition, 0.1f);
    }
}
