using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
    public float speed = 5;
    private Transform player;
	// Use this for initialization

    Transform findClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Transform closest = transform;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in players)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go.transform;
                distance = curDistance;
            }
        }
        return closest;
    }

	void Start () {
        player = findClosestPlayer();
	}
	
	// Update is called once per frame
	void Update () {
        if (!player)
            player = findClosestPlayer();
        this.transform.Translate((player.position - transform.position).normalized * speed * Time.deltaTime, Space.World);
	}
}