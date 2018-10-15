using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerabehindcollide : MonoBehaviour {

    float speed = (float)2;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3((float)-13.92, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
}
