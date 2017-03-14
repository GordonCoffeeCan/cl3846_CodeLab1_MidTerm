using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    public float followSpeed = 5;

    private Transform _cameraPivot;
    private Transform _player;

    private Vector3 _targetPos;

    private void Awake() {
        _cameraPivot = GameObject.Find("CameraPivot").transform;
        _player = GameObject.Find("Player").transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _targetPos = _player.position;

        _cameraPivot.position = new Vector3(Mathf.Lerp(_cameraPivot.position.x, _targetPos.x, followSpeed * Time.deltaTime), 0, Mathf.Lerp(_cameraPivot.position.z, _targetPos.z, followSpeed * Time.deltaTime));

    }
}
