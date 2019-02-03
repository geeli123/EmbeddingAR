using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour {

    public Text dictation;
    private string[] words;

    public void CreateLine() {
        words = dictation.text.Split();
        Balls[] balls = FindObjectsOfType<Balls>();
        for (int i = 0; i < words.Length - 1; i++)
        {
            DrawLine(FindV(words[i], balls), FindV(words[i + 1], balls), Color.red);
        }
	}

    Vector3 FindV(string s, Balls[] balls)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i].name.ToLower().Equals(s.ToLower())) {
                return balls[i].transform.position;
            }
        }
        return new Vector3();
    }

    void DrawLine(Vector3 start, Vector3 end, Color color)
    {

        GameObject lineObj = new GameObject("DragLine", typeof(LineRenderer));
        LineRenderer line = lineObj.GetComponent<LineRenderer>();
        line.material.color = color;
        
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        line.material = whiteDiffuseMat;

    }
}
