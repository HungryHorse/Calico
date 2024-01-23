using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Board playerBoard;
    public Board PlayerBoard => playerBoard;
}
