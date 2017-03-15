using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class RPGPersonController : MonoBehaviour {
    private Animator _anim;

    private void Awake() {
        _anim = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetAnimation();
	}


    private void SetAnimation() {
        _anim.SetFloat("MoveZ", Input.GetAxis("Vertical"));
        _anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
    }
}
