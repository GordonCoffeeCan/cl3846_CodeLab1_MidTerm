using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static string infoText;
    public static bool isHackerPadPickedUp = false;
    public static bool isPipeBombPickedUp = false;
    public static bool isDoorHacked = false;
    public static bool isPipeBombPlaced = false;
    public static bool isDoorExploded = false;
    public static bool isLauncherConsoleHacked = false;
    public static bool isGameOver = false;

    public static Animator hackDoorAnim;

    public static Material wireColor;

    public Text infoUI;
    public Text gameTimer;
    public Transform explorePoint;

    private float _bombTimer = 3;
    private float _gameTimer = 0;

    private bool _isTextShowedUp = false;

    private void Awake() {
        wireColor = GameObject.Find("Wire").GetComponent<Renderer>().material;
        hackDoorAnim = GameObject.Find("HackDoors").GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        _gameTimer = 30;
        infoText = "";

        isHackerPadPickedUp = false;
        isPipeBombPickedUp = false;
        isDoorHacked = false;
        isPipeBombPlaced = false;
        isDoorExploded = false;
        isLauncherConsoleHacked = false;
        isGameOver = false;

        _isTextShowedUp = false;
}
	
	// Update is called once per frame
	void Update () {
        infoUI.text = infoText;
        if(_gameTimer > 0) {
            if (isLauncherConsoleHacked == false) {
                _gameTimer -= Time.deltaTime;
            } else {
                if (_isTextShowedUp == false) {
                    if (Input.GetJoystickNames()[0] != "") {
                        infoText += "Press Start to restart the game!";
                    } else {
                        infoText += "Press Space to restart the game!";
                    }
                    _isTextShowedUp = true;
                }

                if (Input.GetButtonDown("Reset Game")) {
                    SceneManager.LoadScene(0, LoadSceneMode.Single);
                }
            }
        } else {
            _gameTimer = 0;
            isGameOver = true;
            infoText = "GAME IS OVER! North Korea missiles are Launched. The world is under Nuclear Bombard! ";

            if (_isTextShowedUp == false) {
                if (Input.GetJoystickNames()[0] != "") {
                    infoText += "Press Start to restart the game!";
                } else {
                    infoText += "Press Space to restart the game!";
                }
                _isTextShowedUp = true;
            }

            if (Input.GetButtonDown("Reset Game")) {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
        }

        gameTimer.text = (Math.Round(_gameTimer, 2, MidpointRounding.ToEven)).ToString();

        if (isPipeBombPlaced == true) {
            if (_bombTimer > 0) {
                infoText = (Math.Round(_bombTimer -= Time.deltaTime, 2, MidpointRounding.ToEven)).ToString();
            } else {
                if (isDoorExploded == false && isPipeBombPlaced == true) {
                    infoText = "Doors are Broken";
                    GameObject.Find("BreakDoor_Left").GetComponent<Rigidbody>().AddExplosionForce(50, TriggerBehavior.pipeBomb.transform.position, 15, 0, ForceMode.Impulse);
                    GameObject.Find("BreakDoor_Right").GetComponent<Rigidbody>().AddExplosionForce(50, TriggerBehavior.pipeBomb.transform.position, 15, 0, ForceMode.Impulse);
                    Destroy(TriggerBehavior.pipeBomb.gameObject);
                    isDoorExploded = true;
                }
            }
        }
    }
}
