using UnityEngine;
using System.Collections;

public class BaseGunClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 
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
