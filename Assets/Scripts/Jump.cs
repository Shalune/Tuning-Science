using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump {

    private bool canJump = true;
    private bool useFloat;
    public enum _jumpState { GROUNDED, RISING, FLOATING, FALLING, NUMELEMENTS };
    private _jumpState jumpState = _jumpState.GROUNDED;

    // future - load values below from file or game manager
    private float gravity;
    private float jumpHeight;
    private float jumpTimeToMaxHeight;

    public Jump(float gravity, float jumpHeight, float jumpTimeToMaxHeight, bool useFloat = true, _jumpState jumpState = _jumpState.GROUNDED)
    {
        this.gravity = gravity;
        this.jumpHeight = jumpHeight;
        this.jumpTimeToMaxHeight = jumpTimeToMaxHeight;
        this.useFloat = useFloat;
        this.jumpState = jumpState;
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
    }

    public Vector3 Update()
    {
        Vector3 moveBy = Vector3.zero;
        switch (jumpState)
        {
            case _jumpState.RISING:
                moveBy = Rising();
                break;
            case _jumpState.FLOATING:
                moveBy = Floating();
                break;
            case _jumpState.FALLING:
                moveBy = Falling();
                break;
            default:
                break;
        }
        return moveBy;
    }

    private Vector3 Rising()
    {
        return Vector3.zero;
    }

    private Vector3 Floating()
    {
        return Vector3.zero;
    }

    private Vector3 Falling()
    {
        return Vector3.zero;
    }

    #region Variable Access
    public bool CanJump
    {
        get { return canJump; }
        set { canJump = value; }
    }
    public _jumpState JumpState
    {
        get { return jumpState; }
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
