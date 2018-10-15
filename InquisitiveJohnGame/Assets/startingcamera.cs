using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//private GameObject monkey;


public class startingcamera : MonoBehaviour {
    //public AudioClip gameplayMusic;
    //private AudioSource source;
    //private float vol = .1f;
    //public GameObject player;
    //GameObject player = GameObject.Find("Monkey1");
    float speed = (float)2;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3((float)-4.47, 0, (float)-10);
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * Time.deltaTime * speed;
        
    }
}
