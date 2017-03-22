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
        if (_col.tag == "Player" && GameManager.isGameOver == false) {
            if(Input.GetJoystickNames()[0] != "") {
                GameManager.infoText = "Press A to open Crate";
            }else {
                GameManager.infoText = "Press F to open Crate";
            }

            if (Input.GetButtonDown("Action")) {
                Destroy(this.gameObject);
            }
        }
    }
}
