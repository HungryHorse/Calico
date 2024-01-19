using FriedSynapse.FlowEnt;
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

    private bool isBeingHeld;
    public bool IsBeingHeld => isBeingHeld;

    Tween moveTileTween;

    Vector3? SnapPosition;

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
        if (SnapPosition != null)
        {

            return;
        }

        isBeingHeld = false;
        RB.isKinematic = false;
    }

    private void Update()
    {
        moveTileTween?.Stop();

        if (IsBeingHeld && SnapPosition != null)
        {
            moveTileTween = new Tween(0.05f)
                .SetEasing(Easing.EaseOutSine)
                .For(transform)
                    .MoveTo(SnapPosition.Value)
                .Start();
        }
        else if (IsBeingHeld)
        {
            Vector3 mouseWithYOffset = GameController.Instance.MouseWorldPosition;
            mouseWithYOffset.y = YOffset;
            moveTileTween = new Tween(0.1f)
                .SetEasing(Easing.EaseOutSine)
                .For(transform)
                    .MoveTo(mouseWithYOffset)
                .Start();
        }
    }
}
