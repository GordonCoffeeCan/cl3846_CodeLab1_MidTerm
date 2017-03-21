using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehavior : MonoBehaviour {
    private Collider _collider;

    private void Awake() {
        _collider = this.GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    // Use this for initialization
    void Start () {
        GameManager.wireColor = Color.green;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider _col) {
        if(_col.tag == "Player") {

            switch (this.name) {
                case "HackerPad":
                    GameManager.infoText = "HackerPad picked up";
                    GameManager.isHackerPadPickedUp = true;
                    break;
                case "PipeBomb":
                    GameManager.infoText = "PipeBomb picked up";
                    GameManager.isPipeBombPickedUp = true;
                    break;
                case "HackConsole":
                    if(GameManager.isHackerPadPickedUp == true) {
                        GameManager.infoText = "Door Hacked!";
                        GameManager.wireColor = Color.green;
                    } else {
                        GameManager.infoText = "You need HackerPad to hack the door";
                    }
                    break;
            }

            //Destroy(this.gameObject);
        }
    }
}
