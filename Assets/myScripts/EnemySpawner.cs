using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public int spawnId = -1;
    private float nextSpawn;
    public GameObject[] enemies;
    public SpawnerStruct[] spawners;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnId >= 0 && nextSpawn <= Time.time)
        {
            Instantiate(enemies[spawnId], Vector3.zero, Quaternion.identity);
            nextSpawn = Time.time + (float)(0.5);
        }
        foreach (SpawnerStruct spawner in spawners)
        {
            spawner.spawn();
        }
    }
}
