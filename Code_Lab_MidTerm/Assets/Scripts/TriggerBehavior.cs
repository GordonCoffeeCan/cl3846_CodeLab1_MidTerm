using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehavior : MonoBehaviour {
    private Collider _collider;

    public static GameObject pipeBomb;

    private void Awake() {
        _collider = this.GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider _col) {
        if(_col.tag == "Player" && GameManager.isLauncherConsoleHacked == false) {

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
                        GameManager.infoText = "Doors are Hacked!";
                        GameManager.isDoorHacked = true;
                        GameManager.wireColor.SetColor("_SpecColor", Color.green);
                        GameManager.wireColor.SetColor("_EmissionColor", Color.green);

                        GameManager.hackDoorAnim.SetBool("OpenDoor", true);
                    } else {
                        GameManager.infoText = "You need HackerPad to hack the door";
                    }
                    break;
                case "BreakDoors":
                    if(GameManager.isDoorExploded == false) {
                        if (GameManager.isPipeBombPickedUp == true) {
                            if (GameManager.isPipeBombPlaced == false) {
                                if (Input.GetJoystickNames()[0] != "") {
                                    GameManager.infoText = "Press A to place PipeBomb";
                                } else {
                                    GameManager.infoText = "Press F to place PipeBomb";
                                }
                            }
                            
                        } else {
                            GameManager.infoText = "Need a PipeBomb to break the door!";
                        }
                    }
                    break;
                case "LauncherConsole":
                    GameManager.infoText = "Launcher Console is hacked! You stopped North Korea world-wide Nuclear bombard! The world is saved now! ";
                    GameManager.isLauncherConsoleHacked = true;
                    break;
            }
        }
    }

    private void OnTriggerStay(Collider _col) {
        if (_col.tag == "Player") {
            switch (this.name) {
                case "BreakDoors":
                    if (GameManager.isPipeBombPlaced == false && GameManager.isPipeBombPickedUp == true) {
                        if (Input.GetButtonDown("Action")) {
                            Transform _bombPivot = GameObject.Find("BombPivot").transform;
                            pipeBomb = Instantiate(Resources.Load("Prefabs/PipeBomb"), _bombPivot.position, Quaternion.Euler(new Vector3(Random.Range(0, 360), 0, 90))) as GameObject;
                            pipeBomb.GetComponent<BoxCollider>().enabled = false;
                            GameManager.infoText = "PipeBomb placed";
                            GameManager.isPipeBombPlaced = true;
                        }
                    }
                    break;
            }
        }
    }
}
