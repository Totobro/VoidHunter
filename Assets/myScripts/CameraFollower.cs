using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour
{

    // Use this for initialization
    public int spaceX = 50;
    public int spaceZ = 30;
    public Vector3 mapBoundLow = new Vector3(-50, 0, -30);
    public Vector3 mapBoundHigh = new Vector3(50, 0, 30);
    void Start()
    {

    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Vector3 min = mapBoundLow;
        Vector3 max = mapBoundHigh;
        foreach (GameObject player in players)
        {
            if (min.x > player.transform.position.x)
                min.x = player.transform.position.x;
            if (min.z > player.transform.position.z)
                min.z = player.transform.position.z;
            if (max.x < player.transform.position.x)
                max.x = player.transform.position.x;
            if (max.z < player.transform.position.z)
                max.z = player.transform.position.z;
        }
        min.x -= spaceX; min.z -= spaceZ;
        max.x += spaceX; max.z += spaceZ;
        float adj = (max.x - min.x) / Mathf.Tan(gameObject.camera.fieldOfView * Mathf.Deg2Rad);
        gameObject.transform.position = new Vector3((float)((min.x + max.x) / 2.0), adj, (float)((min.z + max.z) / 2.0));
        //en partant de ça, j'ai le FoV, la taille que je dois voir
        //j'ai coté opposé, je veux coté adjacent, et j'ai l'angle. Si je me souvient bien, c'est un truc du genre tan(ang) = opp / adj;
        //adj = opp / tan(ang)
    }
}
