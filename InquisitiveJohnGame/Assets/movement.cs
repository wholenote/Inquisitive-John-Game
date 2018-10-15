using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMovement = 0f;
    bool jump = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("MainMenu"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
	}

    void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
