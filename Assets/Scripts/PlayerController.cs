using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerController : MonoBehaviour {

    private PlayerBehaviour behaviour;

    public class PlayerInput
    {
        public Vector3 moveAxes;
        public bool jump;
    }
    private PlayerInput playerInput;

    private void Awake()
    {
        behaviour = GetComponent<PlayerBehaviour>();
        playerInput = new PlayerInput();
    }

    void Update () {
        ResetInput();
        GetInput();
        behaviour.MovePlayer(playerInput, Time.deltaTime);
	}

    private void ResetInput()
    {
        playerInput.moveAxes = Vector3.zero;
        playerInput.jump = false;
    }

    private void GetInput()
    {
        playerInput.moveAxes.x = Input.GetAxis("Horizontal");
        playerInput.moveAxes.y = Input.GetAxis("Vertical");
        if (Input.GetButton("Jump"))
            playerInput.jump = true;
    }

    public PlayerBehaviour Behaviour
    {
        get { return behaviour; }
    }
}
