using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        //Debug.Log("Collision");
    }
}
