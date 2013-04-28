using UnityEngine;
using System.Collections;

public class WSimpleShooter : MonoBehaviour, Weapons {
    public double fireRate = 0.25;
    public GameObject[] bulletPrefabs;
    public int level = 0;
    private double nextFire = 0;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public bool canShoot()
    {
        return (Time.time > nextFire);
    }

    public void shoot()
    {
        if (this.canShoot()) {
            Instantiate(bulletPrefabs[level], transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
