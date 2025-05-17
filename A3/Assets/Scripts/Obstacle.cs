using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float delayTime;

    private void Start()
    {
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        while (true)
        {
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(3f);
        }
    }
}
