using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehavior : MonoBehaviour {
    private Collider _collider;
    private bool bombInstantiated = false;

    private void Awake() {
        _collider = this.GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    // Use this for initialization
    void Start () {
        
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
                    Destroy(this.gameObject);
                    break;
                case "PipeBomb":
                    GameManager.infoText = "PipeBomb picked up";
                    GameManager.isPipeBombPickedUp = true;
                    Destroy(this.gameObject);
                    break;
                case "HackConsole":
                    if(GameManager.isHackerPadPickedUp == true) {
                        GameManager.infoText = "Door Hacked!";

                        GameManager.wireColor.SetColor("_SpecColor", Color.green);
                        GameManager.wireColor.SetColor("_EmissionColor", Color.green);

                        GameManager.hackDoorAnim.SetBool("OpenDoor", true);
                    } else {
                        GameManager.infoText = "You need HackerPad to hack the door";
                    }
                    break;
                case "BreakDoors":
                    if (GameManager.isPipeBombPickedUp == true) {
                        if (Input.GetJoystickNames()[0] != "") {
                            GameManager.infoText = "Press A to place PipeBomb";
                        } else {
                            GameManager.infoText = "Press F to place PipeBomb";
                        }

                        if (bombInstantiated == false) {
                            if (Input.GetButtonDown("Action")) {
                                Instantiate(Resources.Load("Prefabs/PipeBomb"), GameObject.Find("BombPivot").transform.position, Quaternion.Euler(GameObject.Find("BombPivot").transform.rotation.eulerAngles));
                                bombInstantiated = true;
                                GameManager.infoText = "PipeBomb placed";
                            }
                        }
                    } else {
                        GameManager.infoText = "Need a PipeBomb to break the door!";
                    }
                    break;
            }
        }
    }
}
