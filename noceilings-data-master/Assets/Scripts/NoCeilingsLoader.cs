using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class NoCeilingsLoader : MonoBehaviour {
    private const string JSON_COUNTRIES = "noceilings-data-master/countries.json";
    private const string JSON_NET_SECOND_FEMALE = "noceilings-data-master/json/NERASEFE.json";
    private const string JSON_NET_PHYSDENS = "noceilings-data-master/json/PHYSDENS.json";

    Dictionary<string, string> countryCodes = new Dictionary<string, string>();

    Dictionary<string, string> phyDens = new Dictionary<string, string>();


    // Use this for initialization
    void Start () {
        JSONNode json = UtilScript.ReadJSONfromFile(Application.dataPath, JSON_COUNTRIES);
        JSONArray jsonCountries = (JSONArray)json;

        foreach(JSONNode country in jsonCountries) {
            string key = country["iso"];
            string value = country["name"];

            countryCodes.Add(key, value);
        }

        //Debug.Log(countryCodes["BGD"]);

        //JSONNode womenInSceSchool = UtilScript.ReadJSONfromFile(Application.dataPath, JSON_NET_SECOND_FEMALE);

        //Debug.Log("data: " + womenInSceSchool.ToString());

        JSONNode phy = UtilScript.ReadJSONfromFile(Application.dataPath, JSON_NET_PHYSDENS);
        JSONArray jsonPhy = (JSONArray)json;

        foreach(JSONNode _phy in jsonPhy) {
            string key = _phy["iso"];
            string value = _phy["name"];

            phyDens.Add(key, value);
        }

        Debug.Log(phyDens["BHR"]);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
