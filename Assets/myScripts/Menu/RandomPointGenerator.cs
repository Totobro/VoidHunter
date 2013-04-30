using UnityEngine;
using System.Collections;

public class RandomPointGenerator : MonoBehaviour {
    public GameObject point;
    private float nextPop;

    // Use this for initialization
    void Start () {
        nextPop = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (nextPop < Time.time)
        {
            Instantiate(point, new Vector3(0, 0, 0), Quaternion.identity);
            nextPop = Time.time + Random.Range(1, 5);
        }
	}
}
