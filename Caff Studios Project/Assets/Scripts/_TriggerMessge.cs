using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class _TriggerMessge : MonoBehaviour
{
    public TMP_Text inGameMessage;

    [TextArea]
    public string message;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inGameMessage.text = message;
        }
    }
}
