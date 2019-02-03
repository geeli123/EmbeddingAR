using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera m_Camera = Camera.main;
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
        m_Camera.transform.rotation * Vector3.up);
    }
}
