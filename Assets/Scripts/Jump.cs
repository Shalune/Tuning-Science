using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump {

    private bool canJump = true;

    public void StartJump()
    {

    }

    public Vector3 Update()
    {
        Vector3 moveBy = Vector3.zero;

        return moveBy;
    }

    public bool CanJump
    {
        get { return canJump; }
        set { canJump = value; }
    }
}
