using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 100;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
	}
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BananaSplat splat = hitInfo.GetComponent<BananaSplat>();
        if (splat != null)
        {
            splat.TakeDamage(damage);
            Destroy(gameObject);
        }
        
        
    }
	
}
