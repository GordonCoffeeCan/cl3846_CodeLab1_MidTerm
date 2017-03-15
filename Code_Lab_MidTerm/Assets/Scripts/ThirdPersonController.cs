using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class ThirdPersonController : MonoBehaviour {
    public float speed = 5;
    public float jumpSpeed = 8;

    private float _rotationSpeed = 50;
    private float _gravity = 20;
    private Vector3 _moveDirection = Vector3.zero;

    private CharacterController _characterCtr;
    private Transform _rotationPivot;

    private void Awake() {
        _characterCtr = this.GetComponent<CharacterController>();
        _rotationPivot = this.transform.FindChild("RotationPivot");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_characterCtr.isGrounded) {
            _moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
            _moveDirection = this.transform.TransformDirection(_moveDirection);
            _moveDirection *= speed;

            if (Input.GetButtonDown("Jump")) {
                _moveDirection.y = jumpSpeed;
            }
        }
        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterCtr.Move(_moveDirection * Time.deltaTime);

        FaceToDirection(true);

        //Test joysticks
        Debug.Log("Right Stick X: " + Input.GetAxis("Right_Stick_X") + ", " + "Right Stick Y: " + Input.GetAxis("Right_Stick_Y"));
	}

    private void FaceToDirection(bool _isFacingDirection) {
        if(_isFacingDirection == true) {
            if(_characterCtr.velocity.magnitude > 0) {
                _rotationPivot.forward += _characterCtr.velocity.normalized * _rotationSpeed * Time.deltaTime;
                _rotationPivot.rotation = Quaternion.Euler(new Vector3(0, _rotationPivot.eulerAngles.y, 0));
            }
        }
    }
}
