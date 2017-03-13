using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructureExampleScript : MonoBehaviour {

    public List<string> names = new List<string>();
    public Queue<string> waitInLine;
    public Stack<string> stack = new Stack<string>();
    public Dictionary<string, string> websters = new Dictionary<string, string>(); //dictionary key and value can by anything expected.


	// Use this for initialization
	void Start () {

        names.Add("at");
        names.Add("teaching");

        names.Insert(2, "not");

        names.Remove("not");
        names.RemoveAt(0);

        string[] nameArray = names.ToArray();

        for (int i = 0; i < names.Count; i++) {
            //Debug.Log(names[i]);
        }

        foreach (string name in names) {
            Debug.Log("name: " + name);
        }

        //queue here
        waitInLine = new Queue<string>();

        waitInLine.Enqueue("redDoor");
        waitInLine.Enqueue("blueDoor");
        waitInLine.Enqueue("greenDoor");

        string firstInLine = waitInLine.Dequeue();
        Debug.Log(firstInLine);

        foreach(string lego in waitInLine) {
            Debug.Log(waitInLine.Peek());
        }

        //stack here
        stack.Push("Ace");
        stack.Push("King");
        stack.Push("Queen");

        Debug.Log(stack.Pop());

        //Dictionary
        websters.Add("car", "4 wheel auto");
        websters.Add("camel", "horse by committee");
        websters.Add("dog", "better than cat");
        websters.Add("apple", "better than orange");

        Debug.Log(websters["dog"]);

        foreach(string key in websters.Keys) {
            Debug.Log("key: " + key + " value: " + websters[key]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
