using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private float fall = 1.5f;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TileManager.Instance.SpawnTile();
            StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fall);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(2);

        switch (gameObject.name)
        {
            case "LeftTile":
                TileManager.Instance.LeftTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "TopTile":
                TileManager.Instance.TopTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
        }
    }
}
