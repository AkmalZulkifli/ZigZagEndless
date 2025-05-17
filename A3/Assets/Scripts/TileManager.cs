using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject currentTile;
    public GameObject[] tilePrefabs;

    private static TileManager instance;

    private Stack<GameObject> leftTiles = new Stack<GameObject>();
    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

    public Stack<GameObject> LeftTiles 
    {
        get { return leftTiles; }
        set { leftTiles = value; } 
    }
    public Stack<GameObject> TopTiles
    {
        get { return topTiles; }
        set { topTiles = value; }
    }

    void Start()
    {
        CreateTile(20);

        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
    }

    public void CreateTile(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            leftTiles.Push(Instantiate(tilePrefabs[0]));
            topTiles.Push(Instantiate(tilePrefabs[1]));
            topTiles.Peek().SetActive(false);
            topTiles.Peek().name = "TopTile";
            leftTiles.Peek().name = "LeftTile";
            leftTiles.Peek().SetActive(false);
        }
    }

    public void SpawnTile()
    {
        if (leftTiles.Count == 0 || topTiles.Count == 0)
        {
            CreateTile(10);
        }

        int randomIndex = Random.Range(0, 2);

        if (randomIndex == 0)
        {
            GameObject tmp = leftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }
        else if (randomIndex== 1) 
        {
            GameObject tmp = topTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }

        int spawnPickup = Random.Range(0, 10);

        if (spawnPickup == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }

        int spawnObstacle = Random.Range(0, 10);

        if (spawnObstacle == 0) 
        {
            currentTile.transform.GetChild(2).gameObject.SetActive(true);
        }

        //currentTile = (GameObject)Instantiate(tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity);
    }
}
