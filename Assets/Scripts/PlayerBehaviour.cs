using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBehaviour : MonoBehaviour {

    // move to game manager on full implementation
    public Transform ground;

    bool hasJump = false;
    Jump jumpScript;
    Vector3 velocity;
    Vector3 acceleration;
    float maxVelocity = 1f;

    private void Awake()
    {
        jumpScript = GetComponent<JumpMono>().JumpScript;
        hasJump = !(jumpScript == null);
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
    }

    public void MovePlayer(PlayerController.PlayerInput playerInput, float timePassed)
    {
        acceleration = Vector3.zero;

        ApplyInput(playerInput, timePassed);
        UpdateAcceleration(timePassed);
        UpdateVelocity(timePassed);
        ApplyVelocity();
    }

    private void ApplyInput(PlayerController.PlayerInput playerInput, float timePassed)
    {
        if (hasJump && playerInput.jump)
            jumpScript.TryJump();
    }

    private void UpdateAcceleration(float timePassed)
    {
        if (jumpScript.CurrentlyJumping)
            acceleration += jumpScript.Update(timePassed);
        else
        {
            //other movement? falling?
        }
    }

    private void UpdateVelocity(float timePassed)
    {
        //Debug.Log(timePassed);
        velocity += acceleration;
        if (velocity.magnitude > maxVelocity)
            velocity = velocity.normalized * maxVelocity;
        // if(velocity != Vector3.zero)
        //    Debug.Log(acceleration.y + "   " + velocity.y);
    }

    private void ApplyVelocity()
    {
        Vector3 moveTo = transform.position;
        moveTo += velocity;
        moveTo = CorrectForCollision(moveTo);
        transform.position = moveTo;
    }

    private Vector3 CorrectForCollision(Vector3 moveTo)
    {
        if(moveTo.y - (transform.lossyScale.y/2f) < ground.position.y + (ground.lossyScale.y / 2f))
        {
            moveTo.y = ground.position.y + (ground.lossyScale.y / 2f) + (transform.lossyScale.y / 2f);
            jumpScript.GroundCharacter();
            velocity.y = 0f;
        }
        return moveTo;
    }
}
