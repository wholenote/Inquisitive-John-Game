using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialbanana : MonoBehaviour {

    public GameObject player;
    public Camera camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            camera.transform.position = new Vector3((float)26.31, 0, (float)-10);
            player.transform.position = new Vector3((float)19.48, (float)-3.3, 0);
        }
    }   
	// Use this for initialization
	void Start () {
        camera.transform.position = new Vector3(0, 0, (float)-10);
        player.transform.position = new Vector3((float)-7.65, (float)-3.3, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
