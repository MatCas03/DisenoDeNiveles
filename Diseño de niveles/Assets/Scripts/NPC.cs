using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Teo Indomito
public interface IFeedbackObject
{
    void GiveFeedback();
}

//TP2 - Teo Indomito
public class NPC : MonoBehaviour
{
    public GameObject player;

    public float feedbackDistance = 5f;

    private IFeedbackObject feedbackObject;

    private void Start()
    {
        feedbackObject = GetComponent<IFeedbackObject>();
        if (feedbackObject == null)
        {
            Debug.LogError("NPC requires an object that implements IFeedbackObject interface!");
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= feedbackDistance)
        {
            feedbackObject.GiveFeedback();
        }
    }
}
