using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {


    CharacterController2D controller2D;
    Animator animator;
    int runHash = Animator.StringToHash("Run");

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        controller2D = GetComponent<CharacterController2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float ismoving = Input.GetAxisRaw("Horizontal");

        if (ismoving > 0 || ismoving < 0)
        {
            animator.SetBool(runHash, true);
        }
        else
        {
            animator.SetBool(runHash, false);
        }
    }
}
