using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMono : MonoBehaviour {
    private Jump jumpScript = null;

    private void Awake()
    {
        jumpScript = GetComponent<Jump>() as Jump;
        if (jumpScript == null)
            jumpScript = new Jump();
    }

    public void Jump()
    {
        jumpScript.StartJump();
    }

    private void Update()
    {
        
    }

}
