using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBehaviour : MonoBehaviour {

    bool hasJump = false;
    Jump jumpScript;
    Vector3 velocity;
    Vector3 acceleration;
    float maxVelocity = 1f;

    private void Awake()
    {
        jumpScript = GetComponent<Jump>();
        hasJump = !(jumpScript == null);
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
    }

    public void MovePlayer(PlayerController.PlayerInput playerInput, float timePassed)
    {
        acceleration = Vector3.zero;

        ApplyInput(playerInput, timePassed);
        UpdateVelocity(timePassed);
        ApplyVelocity();
    }

    private void ApplyInput(PlayerController.PlayerInput playerInput, float timePassed)
    {
        if (hasJump && playerInput.jump)
            jumpScript.TryJump();

        if (jumpScript.CurrentlyJumping)
            acceleration += jumpScript.Update(timePassed);
        else
        {
            //other movement? falling?
        }
    }

    private void UpdateVelocity(float timePassed)
    {
        velocity += acceleration * timePassed;
        if (velocity.magnitude > maxVelocity)
            velocity = velocity.normalized * maxVelocity;
    }

    private void ApplyVelocity()
    {
        Vector3 moveTo = transform.position;
        moveTo += velocity;
        transform.position = moveTo;
    }
}
