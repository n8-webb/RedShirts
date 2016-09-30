using UnityEngine;
using System.Collections;

public class aimDirection : MonoBehaviour {

    public string inputX = "Aim_X_P1";
    public string inputY = "Aim_Y_P1";
    float x;
    float y;
    float aimAngle;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        x = Input.GetAxis(inputX);
        y = Input.GetAxis(inputY);
        aimAngle = 0.0f;

        if (x != 0.0f || y != 0.0f)
        {
            aimAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.back);
        }
        
	
	}
}
