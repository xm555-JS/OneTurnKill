using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cPopup : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public Text mainText;
    public Text yesButtonText;
    public Text noButtonText;

    void Awake()
    {
        yesButton = this.GetComponentsInChildren<Button>()[0];
        noButton = this.GetComponentsInChildren<Button>()[1];

        mainText = this.GetComponentsInChildren<Text>()[0];
        yesButtonText = this.GetComponentsInChildren<Text>()[1];
        noButtonText = this.GetComponentsInChildren<Text>()[2];
    }
}
