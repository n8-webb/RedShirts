using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public bool isFiring;
    public bool isReloading;
    public bulletScript bullet;
    public float bulletSpeed;
    public Transform shootPoint;
    public float fireRate;
    public float reloadTime;
    public float magSize;
    public float distance;
    public float spray;
    public float speed;
    public bool canBounce;
    private float nextShot = 0.0f;
    public float shotsRemaining;
    public float currMagSize;

    public PlayerControl player;

    void Start()
    {
        currMagSize = magSize;
        player = transform.GetComponentInParent<PlayerControl>();
    }

    void Update()
    {


        if (isFiring == true && Time.time > nextShot)
        {
            //for (int i = 0; i < currMagSize; i++) 
            //{
            //    print(i);
            //    if(i < currMagSize)
            //    {
            nextShot = Time.time + fireRate;
            bulletScript newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation) as bulletScript;
            newBullet.transform.GetComponent<bulletScript>().ownerID = player.stats.playerId;
            newBullet.speed = bulletSpeed;
            //currMagSize = (currMagSize - 1.0f);

            //shotsRemaining = (currMagSize - i);
            //}
            //else if(i >= currMagSize)
            //{
            //    isFiring = false;
            //    isReloading = true;

            //    currMagSize = magSize;
            //    nextShot = Time.time + reloadTime;
            //    isReloading = false;
            //    isFiring = true;
            //    return;

            //}
            isFiring = false;
        }

    }


}


