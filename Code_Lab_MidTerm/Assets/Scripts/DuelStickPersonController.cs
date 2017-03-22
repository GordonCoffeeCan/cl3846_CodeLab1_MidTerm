using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class DuelStickPersonController : MonoBehaviour {
    public float walkSpeed = 1.9f;
    public float runSpeed = 3.5f;
    //public float jumpSpeed = 8;

    public Animator PlayerAnimator;

    private float speed;
    private float _rotationSpeed = 15;
    private float _gravity = 20;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _rotationSpace = Vector3.zero;

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

        if (GameManager.isGameOver == true) {
            PlayerAnimator.SetFloat("Speed", 0);
            PlayerAnimator.SetBool("Sprint", false);
            return;
        }

        if (_characterCtr.isGrounded) {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = Camera.main.transform.TransformDirection(_moveDirection);
            _moveDirection.y = 0;
            _moveDirection.Normalize();
            _moveDirection *= speed;

            /*if (Input.GetButtonDown("Jump")) {
                _moveDirection.y = speed;
            }*/
        }
        PlayerAnimator.SetFloat("Speed", Mathf.Max(Mathf.Abs(Input.GetAxis("Horizontal")), Mathf.Abs(Input.GetAxis("Vertical"))));
        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterCtr.Move(_moveDirection * Time.deltaTime);

        FaceToDirection(true);

        if(_characterCtr.velocity.magnitude == 0) {
            RotatePlayer(Input.GetAxis("Right_Stick_X"), Input.GetAxis("Right_Stick_Y"));
        }

        SetSprint();

    }

    private void FixedUpdate() {
        
        
    }

    private void FaceToDirection(bool _isFacingDirection) {
        if(_isFacingDirection == true) {
            if(_characterCtr.velocity.magnitude > 0.1f) {
                RotatePlayer(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }
    }

    private void RotatePlayer(float _rotateStickX, float _rotateStickY) {
        if (Mathf.Abs(_rotateStickX) > 0.1f || Mathf.Abs(_rotateStickY) > 0.1f) {

            _rotationSpace = Camera.main.transform.TransformDirection(new Vector3(_rotateStickX, 0, _rotateStickY));
            _rotationSpace.y = 0;
            _rotationSpace.Normalize();
            _rotationSpace *= Time.deltaTime;

            _rotationSpace *= (Mathf.Abs(_rotateStickX) > Mathf.Abs(_rotateStickY)) ? Mathf.Abs(_rotateStickX) : Mathf.Abs(_rotateStickY);

            _rotationPivot.rotation = Quaternion.Slerp(_rotationPivot.rotation, Quaternion.Euler(new Vector3(0, MathAngle(_rotationSpace.x, _rotationSpace.z), 0)), _rotationSpeed * Time.deltaTime);
        }
    }

    private void SetSprint() {
        if (Input.GetButton("Sprint")) {
            speed = runSpeed;
            PlayerAnimator.SetBool("Sprint", true);
        } else {
            speed = walkSpeed;
            PlayerAnimator.SetBool("Sprint", false);
        }
    }

    private float MathAngle(float _axisX, float _axisY) {
        float axisAngle = Mathf.Atan2(_axisX, _axisY) * Mathf.Rad2Deg;
        return axisAngle;
    }
}
