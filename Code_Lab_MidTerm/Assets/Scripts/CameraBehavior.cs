using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    public Transform player;
    public float followSpeed = 5;
    public float rotationSpeed = 30;

    private Transform _cameraPivot;
    

    private Vector3 _targetPos;
    private Quaternion _targetRot;

    private void Awake() {
        _cameraPivot = GameObject.Find("CameraPivot").transform;
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null) {
            if(GameManager.isGameOver == false) {
                _targetPos = player.position;
                _targetRot = Quaternion.Euler(new Vector3(0, player.rotation.eulerAngles.y, 0));
                _cameraPivot.position = new Vector3(Mathf.Lerp(_cameraPivot.position.x, _targetPos.x, followSpeed * Time.deltaTime), 0, Mathf.Lerp(_cameraPivot.position.z, _targetPos.z, followSpeed * Time.deltaTime));
                //_cameraPivot.rotation = Quaternion.Slerp(_cameraPivot.rotation, _targetRot, rotationSpeed * Time.deltaTime);

                //Rotate Camera by Left or Right Trigger;RotateCamera
                _cameraPivot.Rotate(new Vector3(0, Input.GetAxis("RotateCamera") * rotationSpeed * Time.deltaTime, 0));
            }
        } else {
            Debug.LogError("Assign Transform to follow");
        }
    }
}
