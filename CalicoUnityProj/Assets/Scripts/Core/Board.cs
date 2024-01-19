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
    private BaseTile[,] tilePositions = new BaseTile[5,5];

    public void BuildBoard()
    {

    }

    public Vector3 GetClosestSnapPosition(Vector3 mousePosition)
    {
        Vector3 snapPosition = Vector3.zero;

        return snapPosition;
    }

    public void PlaceTile(Vector3 tilePosition)
    {

    }
}
