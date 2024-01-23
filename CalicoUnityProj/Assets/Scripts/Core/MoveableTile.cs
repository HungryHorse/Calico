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

    private bool isStatic = false;

    private void OnMouseDown()
    {
        if (moveTileTween?.PlayState != PlayState.Playing && CanBePickedUp())
        {
            PickUp();
        }
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
            isBeingHeld = false;
            isStatic = true;
            GameController.Instance.CurrentPlayer.PlayerBoard.PlaceTile(this);
            return;
        }

        moveTileTween?.Stop();
        isBeingHeld = false;
        RB.isKinematic = false;
    }

    public void MoveToPosition(Vector3 positionToMoveTo, float time)
    {
        moveTileTween?.Stop();
        moveTileTween = new Tween(time)
                .SetEasing(Easing.EaseOutSine)
                .For(transform)
                    .MoveTo(positionToMoveTo)
                .Start();
    }

    private void Update()
    {
        if (IsBeingHeld && SnapPosition != null)
        {
            MoveToPosition(SnapPosition.Value, 0.05f);
        }
        else if (IsBeingHeld)
        {
            Vector3 mouseWithYOffset = GameController.Instance.MouseWorldPosition;
            mouseWithYOffset.y = YOffset;
            MoveToPosition(mouseWithYOffset, 0.1f);
        }
    }

    private bool CanBePickedUp()
    {
        bool canBePickedUp = true;

        canBePickedUp = !isStatic;

        return canBePickedUp;
    }
}
