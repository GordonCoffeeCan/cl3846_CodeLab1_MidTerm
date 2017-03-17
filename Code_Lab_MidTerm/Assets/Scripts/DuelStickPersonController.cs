using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class DuelStickPersonController : MonoBehaviour {
    public float walkSpeed = 1.8f;
    public float runSpeed = 3.5f;
    public float jumpSpeed = 8;

    public Animator PlayerAnimator;

    private float speed;
    private float _rotationSpeed = 35;
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
                _moveDirection.y = speed;
            }

            PlayerAnimator.SetFloat("Speed", Mathf.Max(Mathf.Abs(Input.GetAxis("Horizontal")), Mathf.Abs(Input.GetAxis("Vertical"))));
        }
        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterCtr.Move(_moveDirection * Time.deltaTime);

        FaceToDirection(true);
        RotatePlayer();
        SetSpin();
    }

    private void FixedUpdate() {
        
        
    }

    private void FaceToDirection(bool _isFacingDirection) {
        if(_isFacingDirection == true) {
            if(_characterCtr.velocity.magnitude > 0.1f) {
                _rotationPivot.rotation = Quaternion.Slerp(_rotationPivot.rotation, Quaternion.Euler(new Vector3(0, MathAngle(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical")), 0)), _rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void RotatePlayer() {
        if (Mathf.Abs(Input.GetAxis("Right_Stick_X")) > 0.1f || Mathf.Abs(Input.GetAxis("Right_Stick_Y")) > 0.1f) {
            _rotationPivot.rotation = Quaternion.Slerp(_rotationPivot.rotation, Quaternion.Euler(new Vector3(0, MathAngle(-Input.GetAxis("Right_Stick_X"), -Input.GetAxis("Right_Stick_Y")), 0)), 5 * Time.deltaTime);
        }
    }

    private void SetSpin() {
        if (Input.GetButton("Spin")) {
            speed = runSpeed;
            PlayerAnimator.SetBool("Spin", true);
        } else {
            speed = walkSpeed;
            PlayerAnimator.SetBool("Spin", false);
        }
    }

    private float MathAngle(float _axisX, float _axisY) {
        float axisAngle = Mathf.Atan2(_axisX, _axisY) * Mathf.Rad2Deg;
        return axisAngle;
    }
}
