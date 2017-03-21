using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static string infoText;
    public static bool isHackerPadPickedUp = false;
    public static bool isPipeBombPickedUp = false;
    public static bool isDoorHacked = false;
    public static bool isDoorExploded = false;

    public static Color wireColor;

    public Text infoUI;

    private Color _wireColor;

    private void Awake() {
        _wireColor = GameObject.Find("Wire").GetComponent<Renderer>().material.color;
        wireColor = _wireColor;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        infoUI.text = infoText;
        _wireColor = wireColor;
    }
}
