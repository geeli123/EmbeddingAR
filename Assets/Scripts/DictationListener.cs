using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using HoloToolkit.Unity.InputModule;        


public class DictationListener : MonoBehaviour { //, IDictationHandler {

    public Button button;
    public Text dictationOutput;

    private bool isRecording;


    private void Awake()
    {
        isRecording = false;
    }

    public void OnVoiceCommand()
    {
        Debug.Log("Input received");
        ChangeButtonColor(Color.red);
        // ToggleRecording();
    }

    private void ChangeButtonColor(Color color)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = color;
        cb.highlightedColor = color;
        cb.pressedColor = color;
        button.colors = cb;
    }

    /*

    private void ToggleRecording()
    {
        if (isRecording)
        {
            StartCoroutine(DictationInputManager.StopRecording());
        }
        else
        {
            StartCoroutine(DictationInputManager.StartRecording());
        }
        isRecording = !isRecording;

    }

    public void OnDictationHypothesis(DictationEventData eventData)
    {
        dictationOutput.text = eventData.DictationResult;
    }

    public void OnDictationResult(DictationEventData eventData)
    {
        dictationOutput.text = eventData.DictationResult;
    }

    public void OnDictationComplete(DictationEventData eventData)
    {
        dictationOutput.text = eventData.DictationResult;
        isRecording = false;
        ChangeButtonColor(Color.white);

    }

    public void OnDictationError(DictationEventData eventData)
    {
        dictationOutput.text = eventData.DictationResult;
        isRecording = false;
        StartCoroutine(DictationInputManager.StopRecording());
        ChangeButtonColor(Color.white);

    }
    */
}
