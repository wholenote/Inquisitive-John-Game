using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialbanana3 : MonoBehaviour
{

    public GameObject player;
    public Camera camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            camera.transform.position = new Vector3((float)72.58, 0, (float)-10);
            player.transform.position = new Vector3((float)66.15, (float)-3.3, 0);
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
