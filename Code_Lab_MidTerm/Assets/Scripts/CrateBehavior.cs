using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider _col) {
        if (Input.GetButtonDown("Action") && _col.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}
