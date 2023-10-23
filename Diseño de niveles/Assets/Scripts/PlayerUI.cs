using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//TP2 - Imhotep Zumpano
public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    void Start()
    {
        
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

}
