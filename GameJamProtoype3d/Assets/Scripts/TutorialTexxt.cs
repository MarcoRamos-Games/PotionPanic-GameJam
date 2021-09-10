using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTexxt : MonoBehaviour
{

    [SerializeField] GameObject messageToDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            messageToDisplay.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            messageToDisplay.gameObject.SetActive(false);
        }
    }
}
