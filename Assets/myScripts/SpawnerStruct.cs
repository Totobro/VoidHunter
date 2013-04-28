using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpawnerStruct {
    public GameObject[] enemies;
    public Transform[] positions;
    public int occurences;
    public float spawnInterval;
    private int currentOccurence;
    private float nextSpawn;
    public bool spawning;

    public SpawnerStruct(ArrayList _enemies, ArrayList _positions, int _occurences, float _spawnInterval)
    {
        this.enemies = _enemies.ToArray() as GameObject[];
        this.positions = _positions.ToArray() as Transform[];
        this.occurences = _occurences;
        this.spawnInterval = _spawnInterval;
    }

    public void spawn()
    {
        if (spawning && nextSpawn <= Time.time && currentOccurence < occurences)
        {
            foreach (Transform position in positions)
            {
                foreach (GameObject enemy in enemies)
                {
                    GameObject.Instantiate(enemy, position.position, Quaternion.identity);
                }
            }
            nextSpawn = Time.time + spawnInterval;
            currentOccurence++;
        }
        if (currentOccurence >= occurences)
        {
            reset();
        }
    }

    private void reset()
    {
        spawning = false;
        currentOccurence = 0;
    }
}
