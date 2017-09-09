﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump {

    private bool canJump = true;
    private bool useFloat;
    public enum _jumpState { GROUNDED, RISING, FLOATING, FALLING, NUMELEMENTS };
    private _jumpState jumpState = _jumpState.GROUNDED;
    private bool impulseApplied = true;

    // future - load values below from file or game manager
    private float gravity;
    private float jumpHeight;
    private float jumpTimeToMaxHeight;
    private float gravityOnJump;
    private float jumpImpulse;

    public Jump(float gravity, float jumpHeight, float jumpTimeToMaxHeight, float gravityOnJump = 0.3f, bool useFloat = true, _jumpState jumpState = _jumpState.GROUNDED)
    {
        this.gravity = gravity;
        this.jumpHeight = jumpHeight;
        this.jumpTimeToMaxHeight = jumpTimeToMaxHeight;
        this.useFloat = useFloat;
        this.jumpState = jumpState;
        this.gravityOnJump = gravityOnJump;
        this.jumpImpulse = CalculateJumpImpulse();
    }

    public bool TryJump()
    {
        if(canJump)
        {
            StartJump();
            return true;
        }
        return false;
    }

    private void StartJump()
    {
        jumpState = _jumpState.RISING;
        canJump = false;
        impulseApplied = false;
    }

    public Vector3 Update(float timePassed)
    {
        Vector3 moveBy = Vector3.zero;
        switch (jumpState)
        {
            case _jumpState.RISING:
                moveBy = Rising(timePassed);
                break;
            case _jumpState.FLOATING:
                moveBy = Floating(timePassed);
                break;
            case _jumpState.FALLING:
                moveBy = Falling(timePassed);
                break;
            default:
                break;
        }
        return moveBy;
    }

    private Vector3 Rising(float timePassed)
    {
        Vector3 result = Vector3.zero;
        if (!impulseApplied)
        {
            result.y += jumpImpulse;
            impulseApplied = true;
        }
        result.y -= gravity * gravityOnJump * timePassed;
        return result;
    }

    private Vector3 Floating(float timePassed)
    {
        return Vector3.zero;
    }

    private Vector3 Falling(float timePassed)
    {
        return Vector3.down * gravity * timePassed;
    }

    private float CalculateJumpImpulse()
    {
        return (jumpHeight / jumpTimeToMaxHeight) + (gravity * jumpTimeToMaxHeight * gravityOnJump);
    }

    #region Public Variable Access
    public bool CanJump
    {
        get { return canJump; }
        set { canJump = value; }
    }
    public _jumpState JumpState
    {
        get { return jumpState; }
    }
    public bool CurrentlyJumping
    {
        get { return jumpState != _jumpState.GROUNDED; }
    }

    public float Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }
    public float JumpHeight
    {
        get { return jumpHeight; }
        set { jumpHeight = value; }
    }
    public float JumpTimeToMaxHeight
    {
        get { return jumpTimeToMaxHeight; }
        set { jumpTimeToMaxHeight = value; }
    }
    #endregion
}
