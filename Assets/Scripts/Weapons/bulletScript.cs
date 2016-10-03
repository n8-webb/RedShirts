using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
    public float speed;
    

    void Start () {
        
    }
	
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
        
     



    }
	void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
