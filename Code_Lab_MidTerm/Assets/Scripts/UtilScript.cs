using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class UtilScript : MonoBehaviour {

    /// <summary>
    /// Read JSON from the file;
    /// </summary>
    /// <param name="path">Path to file to read.</param>
    /// <returns>Returns an integer based on the passed value.</returns>
    public static void WriteJSONtoFile(string path, string fileName, JSONClass json) {
        WriteStringToFile(path, fileName, json.ToString());
    }

	public static void WriteStringToFile(string path, string fileName, string content) {
        StreamWriter _sw = new StreamWriter(path + "/" + fileName);

        _sw.WriteLine(content);

        _sw.Close();

    }

    public static JSONNode ReadJSONfromFile(string path, string fileName) {
        return JSON.Parse(ReadStringFromFile(path, fileName));

    }

    public static string ReadStringFromFile(string path, string fileName) {
        StreamReader sr = new StreamReader(path + "/" + fileName);
        string result = sr.ReadToEnd();

        sr.Close();
        return result;
    }

    public static Vector3 CloneVector3(Vector3 _vec) {
        return new Vector3(_vec.x, _vec.y, _vec.z);
    }

    public static Vector3 CloneModVector3(Vector3 vec, float xMod, float yMod, float zMod) {
        return new Vector3(vec.x + xMod, vec.y + yMod, vec.z + zMod);
    }
}
