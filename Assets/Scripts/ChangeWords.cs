using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWords : MonoBehaviour {

    public Text dictation;
    public Button button;


    private void ChangeButtonColor(Color color)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = color;
        cb.highlightedColor = color;
        cb.pressedColor = color;
        button.colors = cb;
    }

    public void Fruits()
    {
        dictation.text = "orange apple";
        ChangeButtonColor(Color.white);
    }

    public void Colors()
    {
        dictation.text = "black green red";
        ChangeButtonColor(Color.white);

    }

    public void Royalty()
    {
        dictation.text = "king queen";
        ChangeButtonColor(Color.white);

    }

    public void People()
    {
        dictation.text = "man woman";
        ChangeButtonColor(Color.white);

    }

    public void Soviets()
    {
        dictation.text = "moscow russia";
        ChangeButtonColor(Color.white);

    }

    public void JapanMan()
    {
        dictation.text = "tokyo japan";
        ChangeButtonColor(Color.white);

    }
}
