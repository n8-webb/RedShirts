using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {
    //public GameObject bullet;
    public GameObject gunBarrel; 
    aimDirection Aiming;

    public bool isFiring;
    public bulletScript bullet;
    public float bulletSpeed;
    private float shotCounter;
    public Transform shootPoint;
    public float tbs;

    
    void Start () {
        Aiming = GetComponent<aimDirection>();
        
    }
	
	
	void Update () {

        //if (Input.GetKeyDown("space"))
        //{

        //    Instantiate(bullet, gunBarrel.transform.position, transform.rotation);

        //}
        if (Input.GetKeyDown("space"))
        {
            isFiring = true;
        }
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = tbs;
                bulletScript newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation) as bulletScript;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }








    }
}
