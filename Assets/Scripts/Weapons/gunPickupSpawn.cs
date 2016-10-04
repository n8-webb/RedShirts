using UnityEngine;
using System.Collections;

public class gunPickupSpawn : MonoBehaviour {

    float timer = 5.0f, maxTimer = 5.0f;
    int padNumber = 0;
    System.Random rnd = new System.Random();

    public int ownPadNumber = 1;
    public string pedestalSprite = "pedestal1";

    Sprite[] spritePedestal;
    SpriteRenderer pedastalSpriteRenderer;

    // Use this for initialization
    void Start () {
        spritePedestal = Resources.LoadAll<Sprite>(pedestalSprite);
        pedastalSpriteRenderer = GetComponent<SpriteRenderer>();
        pedastalSpriteRenderer.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            spawn();
            timer = maxTimer;
        }
    }

    void spawn ()
    {
        padNumber = rnd.Next(1, 5);

        pedastalSpriteRenderer.enabled = false;
        if (padNumber == ownPadNumber)
        {
            pedastalSpriteRenderer.enabled = true;
        }
    }
}
