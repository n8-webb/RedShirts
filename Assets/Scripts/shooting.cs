using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {
    public GameObject bullet;
    public GameObject gun;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown("space"))
        {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
        }
	}
}
