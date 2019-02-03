using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using HoloToolkit.Unity.InputModule;
 
public class cubecollider : MonoBehaviour, IInputClickHandler, INavigationHandler {

    private Color[] colors = new Color[]{Color.red, Color.cyan};
    private int i = 0;
    private Renderer rend;

    void Start () {
    rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputClicked(InputClickedEventData eventData) {
        //here we change the color of the cube
        rend.material.color = colors[i];
        //index is calculated with mode operation so that
        //it stays in the size of the array
        i = (i + 1) % colors.Length;
    }

    public float RotationSensitivity = 10.0f;

    private float rotationFactor;

    public void OnNavigationStarted(NavigationEventData eventData)
    {
        Debug.Log("Navigation is started");
    }
    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        rotationFactor = eventData.CumulativeDelta.x * RotationSensitivity;

        //transform.Rotate along the Y axis using rotationFactor.
        transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
    }
    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        Debug.Log("Navigation is completed");
    }
    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        Debug.Log("Navigation is canceled");
    }
}