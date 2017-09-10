using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMono : MonoBehaviour {
    private Jump jumpScript = null;

    public void Jump()
    {
        jumpScript.TryJump();
    }

    private void Update()
    {
        //Vector3 moveBy = jumpScript.Update();
        // move player by amount
        //likely move to non-Update call to be called by player's or game manager's update
    }

    public Jump JumpScript
    {
        get
        {
            if (jumpScript == null)
                jumpScript = new Jump(1f, 0.025f, 0.15f, 0.5f, 0.5f);
            return jumpScript;
        }

    }
}