using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringObject : MonoBehaviour {
    public float rotateSpeed = 10;

	// Use this for initialization
	void Start () {
        this.transform.rotation = Quaternion.Euler(new Vector3(50, 0, 0));
        this.transform.position = new Vector3(transform.position.x, 0.5f, this.transform.position.z);
        this.GetComponent<BoxCollider>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0), Space.World);
	}
}
