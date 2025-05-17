using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;

    void Update()
    {
        coinCountDisplay.GetComponent<TMP_Text>().text = "" + coinCount;
        coinEndDisplay.GetComponent<TMP_Text>().text = "" + coinCount;
    }
}
