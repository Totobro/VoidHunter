using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
    private Weapons		mainWeapon;
    private ArrayList 	secondaryWeapons;
    public float		speed = 10;
    private Plane		playerPlane = new Plane(Vector3.up, Vector3.zero);
 
	// Use this for initialization
	void Start () {
        mainWeapon = gameObject.GetComponent("WSimpleShooter") as Weapons;
	}

    void FixedUpdate() {	
		float			h = Input.GetAxis("Horizontal") * speed;
		float			v = Input.GetAxis("Vertical") * speed;
		ParticleSystem	system = gameObject.GetComponent("ParticleSystem") as ParticleSystem;
		
		if (h != 0 || v != 0) {
			transform.Translate(h * Time.deltaTime, 0, v * Time.deltaTime, Space.World);
			if (system.isStopped)
				system.Play();
			system.startSpeed = 20 * ((h + v) / (speed  * 2));
			if (system.startSpeed < 0)
				system.startSpeed = -system.startSpeed;
		}
		else
			system.Stop();
//        if (transform.position.x 
    }


    void Update () {
        if (Input.GetButton("Fire1"))
        {
            mainWeapon.shoot();
        }
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        float hitdist = 0;
 
        if (playerPlane.Raycast(ray, out hitdist))
        {
 
            var targetPoint = ray.GetPoint(hitdist);
            var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
 
			//mainWeapon.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
	}
}