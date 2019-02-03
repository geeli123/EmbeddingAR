using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupPoints : MonoBehaviour {

    private Color[] groupColors;
    private int groups;
    private string[] words;

    public Text dictation;

	// Use this for initialization
	void Start () {
        groups = 0;
        groupColors = new Color[5];
        groupColors[0] = Color.blue;
        groupColors[1] = Color.red;
        groupColors[2] = Color.green;
        groupColors[3] = Color.cyan;
        groupColors[4] = Color.yellow;
	}
	
	// Update is called once per frame
	public void AddGroup() {
        words = dictation.text.Split();
        Balls[] balls = FindObjectsOfType<Balls>();
        for (int i = 0; i < words.Length; i++)
        {
            UpdateColor(words[i], balls, groupColors[groups]);
        }
        groups += 1;
    }

    void UpdateColor(string s, Balls[] balls, Color color)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i].name.ToLower().Equals(s.ToLower()))
            {
                Color cur = balls[i].GetComponent<Renderer>().material.color;
                if (balls[i].groups == 0)
                {
                    cur = color;
                } 
                else
                {
                    int g = balls[i].groups;
                    cur = new Color((cur.a * g + color.a) / (g + 1), (cur.b * g + color.b) / (g + 1), (cur.g * g + color.g) / (g + 1));
                }
                balls[i].groups += 1;
                balls[i].GetComponent<Renderer>().material.color = cur;
            }
        }
    }
}
