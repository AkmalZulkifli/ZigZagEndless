using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDistance : MonoBehaviour
{
    public GameObject distanceDisplay;
    public GameObject distanceEndDisplay;
    public int distanceRun;
    public bool addingDistance = false;
    public float distanceDelay = 0.35f;
    
    void Update()
    {
        if(addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
    }

    IEnumerator AddingDistance()
    {
        distanceRun += 1;
        distanceDisplay.GetComponent<TMP_Text>().text = "" + distanceRun;
        distanceEndDisplay.GetComponent<TMP_Text>().text = "" + distanceRun;
        yield return new WaitForSeconds(distanceDelay);
        addingDistance = false;
    }
}
