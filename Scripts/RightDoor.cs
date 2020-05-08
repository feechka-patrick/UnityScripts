using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RightDoor : MonoBehaviour
{
    public GameObject Player;
    Camera cam;
    public float speed = 5f;
    public float interactDistance = 1f;
    public float distance;
    float openDoor = -180;
    float closeDoor = 0;
    bool onOpen = false;
    void Awake()
    {
        cam = Camera.main;
    }

    void OnMouseDrag()
    {
        distance = Vector3.Distance(Player.GetComponent<Transform>().position, transform.position);
        if (distance <= interactDistance && !onOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                            Quaternion.Euler(transform.rotation.x, openDoor, transform.rotation.z), speed*Time.deltaTime);
            //onOpen = true;
        }

    }
}
