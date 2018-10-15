using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSplat : MonoBehaviour {

    public int healthType = 100;

    public GameObject newPlatform;

    public void TakeDamage (int damage)
    {
        healthType -= damage;
        
        if (healthType <= 0)
        {
            Change();
        }
    }
    
    void Change()
    {
        Instantiate(newPlatform, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
