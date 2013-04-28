using UnityEngine;
using System.Collections;

public class RandSquare : MonoBehaviour {
    public float speed = 5;
    private Vector2 scale = new Vector2(Random.value, Random.value);
	// Use this for initialization
	void Start () {
        scale *= speed;
	}

    void FixedUpdate()
    {
//        transform.RotateAround(Vector3.up, Mathf.PerlinNoise(transform.position.
        transform.Translate(Vector3.forward * speed);
    }

	// Update is called once per frame
	void Update () {
	}
}
