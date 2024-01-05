using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableTile : MonoBehaviour, BaseTile
{
    [Header("Physics")]
    [SerializeField]
    private Rigidbody rb;
    public Rigidbody RB => rb;

    [Header("Movement")]
    [SerializeField]
    private float yOffset;
    public float YOffset => yOffset;

    [Header("Visuals")]
    [SerializeField]
    private Material faceMaterial;
    public Material FaceMaterial => faceMaterial;
    
    [SerializeField]
    private Texture faceTexture;
    public Texture FaceTexture => faceTexture;

    private Vector3 mouseWorldPosition;
    private Plane plane = new Plane(Vector3.up, 0);

    private bool isBeingHeld;
    public bool IsBeingHeld => isBeingHeld;

    private void OnMouseDown()
    {
        PickUp();
    }

    private void OnMouseUp()
    {
        Drop();
    }

    private void PickUp()
    {
        isBeingHeld = true;
        RB.isKinematic = true; 
    }

    private void Drop()
    {
        isBeingHeld = false;
        RB.isKinematic = false;
    }

    private void Update()
    {
        if (IsBeingHeld)
        {
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                mouseWorldPosition = ray.GetPoint(distance);
                mouseWorldPosition.y = YOffset;
            }
            transform.position = mouseWorldPosition;
        }
    }
}
