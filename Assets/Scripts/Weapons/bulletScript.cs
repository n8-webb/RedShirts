using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
    public float speed= 2.0f;
    public aimDirection aiming;
    float angle;
    public GameObject bullet;
    public GameObject gunBarrel;
    
    void Start () {
        //aiming = GameObject.Find("Aim Direction").GetComponent<aimDirection>();
    }
	
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        //Rigidbody2D bulletRigid = GetComponent<Rigidbody2D>();
        //bulletRigid.velocity = new Vector2(bulletSpeed, 0.0f);

     



    }
	void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public class BaseGun
    {
        public float fireRate;
        public float reloadTime;
        public float magSize;
        public float distance;
        public float spray;
        public float speed;
        public bool canBounce;
        public bool isFiring;
    }
}
