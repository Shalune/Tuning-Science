using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpStateText : MonoBehaviour {

    public JumpMono jumpMono;
    private Jump jumpScript;
    private Text uiText;

    private void Awake()
    {
        jumpScript = jumpMono.JumpScript;
        uiText = GetComponent<Text>();
    }

    private void Update()
    {
        uiText.text = jumpScript.JumpState.ToString();
    }
}
