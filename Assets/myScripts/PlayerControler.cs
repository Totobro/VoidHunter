using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
    private Weapons      mainWeapon;
    private ArrayList secondaryWeapons;
    public float   speed = 10;
    private Plane playerPlane = new Plane(Vector3.up, Vector3.zero);
    // Use this for initialization
	void Start () {
        mainWeapon = gameObject.GetComponent("WSimpleShooter") as Weapons;
	}

    void FixedUpdate()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime, Space.World);
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
 
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
	}

}
