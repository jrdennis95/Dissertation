using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public int spawnCount;
    public GameObject[] prefabs;
    public GameObject human;
    private Transform player;
    private float spawnLocation = 0;
    private float spawnLength = 12;
    private int count;
    private int maxSpawns = 2;
    private List<GameObject> activeSpawn;
    private List<int> spawnHistory;
    private int lastPrefab = 0;
    private int randomNo;
    private Vector3 copyposition;
    // Use this for initialization

    private void Awake()
    {
        activeSpawn = new List<GameObject>();
        spawnHistory = new List<int>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        count = 0;
        for (int i = 0; i < spawnCount; i++)
        {
            if (i < 1)
            {
                Spawn(0);
            }
            else
            {
                Spawn();
            }
        }
        //activeSpawn[0].tag = "Behind";
        //activeSpawn[5].tag = "Ground";
        //activeSpawn[6].tag = "Untagged";
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DeActivate();
    }

    void Spawn(int foo = -1)
    {
        GameObject go;
        if (foo == -1 && count < spawnCount)
        {
            go = Instantiate(prefabs[count]) as GameObject;
        }
        else
        {
            go = Instantiate(prefabs[foo]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(1.0f,0.0f,0.0f) * spawnLocation;
        copyposition = go.transform.position;
        spawnLocation += spawnLength;
        activeSpawn.Add(go);
        count++;
    }

    void DeActivate()
    {
        for(int i = 0; i < activeSpawn.Count; i++)
        {
            if (player.position.x > activeSpawn[i].transform.position.x + 14)
            {
                activeSpawn[i].SetActive(false);
            } else if (player.position.x < activeSpawn[i].transform.position.x - 14)
            {
                activeSpawn[i].SetActive(false);
            } else
            {
                activeSpawn[i].SetActive(true);
            }
        }
        //Destroy(activeSpawn[0]);
        //activeSpawn.RemoveAt(0);
    }


    public List<int> getSpawnHistory()
    {
        return spawnHistory;
    }

}
