using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
    public float bulletSpeed = 2.0f;
    
    void Start () {
        
    }
	
    void Update()
    {
        Rigidbody2D bulletRigid = GetComponent<Rigidbody2D>();
        bulletRigid.velocity = new Vector2(bulletSpeed, 0.0f);
    }
	void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
