using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tigerpacing : MonoBehaviour
{


    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 speed = new Vector3(3, 0, 0);

    // Distance the object will move horizontally.x, vertically.y, and z-ically.z
    public Vector3 moveDistance = new Vector3(7, 0, 0);

    // Enemy pace - default : always on
    public int paceDirection = 1; // 1 = move right, -1 = move left
    public Quaternion lookLeft = Quaternion.Euler(0, 0, 0);
    public Quaternion lookRight = Quaternion.Euler(0, 180, 0);


    void Start()
    {
        pointA = this.GetComponent<Rigidbody>().position;
        pointB = pointA + moveDistance;
    }

    void FixedUpdate()
    {
        // Decides pace direction, 1 = Right, -1 = Left
        if (GetComponent<Rigidbody>().position.x >= pointB.x && paceDirection == 1)
        {
            paceDirection = -paceDirection;
            transform.rotation = lookRight;
        }
        else if (GetComponent<Rigidbody>().position.x < pointA.x && paceDirection == -1)
        {
            paceDirection = -paceDirection;
            transform.rotation = lookLeft;
        }

        // Moves Object with Ridgebody left and right
        this.GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (paceDirection * speed) * Time.deltaTime);

    }

}