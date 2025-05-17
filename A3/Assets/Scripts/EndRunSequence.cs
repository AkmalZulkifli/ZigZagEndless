using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDistance;
    public GameObject endScreen;
    public GameObject fadeOut;

    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(1f);
        liveCoins.SetActive(false);
        liveDistance.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
