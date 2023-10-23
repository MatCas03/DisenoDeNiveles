using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Teo Indomito
public class DialogueUI : MonoBehaviour, IFeedbackObject
{
    public void GiveFeedback()
    {
        Debug.Log("NPC triggereado");
    }
}
