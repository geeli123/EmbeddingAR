using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class Balls : MonoBehaviour, IInputClickHandler { //, IInputHandler {

    private Renderer rend;
    private bool activated;
    public int groups;

    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        activated = false;
        groups = 0;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Vector3 curLoc = transform.position;

        // last index is closest element 
        string[] closestWords = new string[6];
        float[] closestDistances = new float[6];
        for (int i = 0; i < 6; i++)
        {
            closestWords[i] = "xd";
            closestDistances[i] = 999;
        }

        Balls[] ball_list = FindObjectsOfType<Balls>();
        for (int i = 0; i < ball_list.Length; i++)
        {
            Balls b = ball_list[i];
            UpdateClosest(curLoc, b.transform.position, b.name, closestWords, closestDistances);
        }

        if (activated)
        {
            rend.material.color = Color.green;
        }
        else
        {
            rend.material.color = Color.gray;
        }
        activated = !activated;

        GameObject selectedWord = GameObject.Find("SelectedWord");
        selectedWord.GetComponent<Text>().text = "Selected Word: " + System.Convert.ToString(transform.name);

        GameObject nearestNeighbors = GameObject.Find("NearestNeighbors");
        nearestNeighbors.GetComponent<Text>().text = GetNearestString(closestWords, closestDistances);
    }

    string GetNearestString(string[] words, float[] distances)
    {
        string str = "Nearest Neighbors (Euclidean):\n";
        for (int i = 1; i < 6; i++)
        {
            str += i.ToString() + ". " + words[i] + " (" + distances[i].ToString() + ")\n";
        }

        return str;
    }

    void UpdateClosest(Vector3 orig, Vector3 comp, string new_word, string[] words, float[] distances) 
    {
        string temp_word;
        string cur_word = new_word;
        float temp_dist;
        float cur_dist = CompareVectors(orig, comp);
        for (int i = 0; i < 6; i++)
        {
            if (cur_dist < distances[i])
            {
                temp_dist = distances[i];
                distances[i] = cur_dist;
                cur_dist = temp_dist;

                temp_word = words[i];
                words[i] = cur_word;
                cur_word = temp_word;
            }
        }
        
    }

    float CompareVectors(Vector3 from, Vector3 to)
    {
        // TODO - implement 
        return Vector3.Distance(from, to);
    }
    /*
    public void OnInputDown(InputEventData eventData)
    {
        Debug.Log("input down object");
        rend.material.color = Color.green;
    }

    public void OnInputUp(InputEventData eventData)
    {
        Debug.Log("input up object");
        rend.material.color = Color.cyan;
    }
    */
}
