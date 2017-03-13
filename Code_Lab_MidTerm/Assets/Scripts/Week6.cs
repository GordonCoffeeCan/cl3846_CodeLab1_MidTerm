using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using SimpleJSON;

public class Week6 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UtilScript.WriteStringToFile(Application.dataPath, "Hello.txt", "Hi");

        JSONClass subClass = new JSONClass();
        subClass["test"] = "value";

        JSONClass json = new JSONClass();

        json["x"].AsFloat = 7;
        json["y"].AsFloat = 0;
        json["z"].AsFloat = 2;
        json["name"] = "Gordon";
        json["Alt Facts"].AsBool = false;
        json["sub"] = subClass;

        UtilScript.WriteStringToFile(Application.dataPath, "file.json", json.ToString());

        Debug.Log(json);

        string result = UtilScript.ReadStringFromFile(Application.dataPath, "file.json");

        JSONNode readJSON = JSON.Parse(result);

        Debug.Log(readJSON["z"].AsFloat);

        WebClient client = new WebClient();
        string content = client.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20astronomy.sunset%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22maui%2C%20hi%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");

        JSONNode hawaii = JSON.Parse(content);

        string sunset = hawaii["query"]["result"]["channel"]["astronomy"]["sunset"];

        print(sunset);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
