using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using System.Runtime.CompilerServices;

public class LeftDoor : MonoBehaviour
{
  
    public GameObject Player;
    public GameObject thisObject = GameObject.Find("door1");
    public Rigidbody aim;
    Camera cam;
    public float speed = 1f;
    public float interactDistance = 1f;
    public float distance;
    public float angleRotation = 3f;
    float openDoor = 120;
    float closeDoor = 0;
    bool onOpen = false;
    
    void Awake()
    {
        cam = Camera.main;
    }    

 

    void OnMouseDrag()
    {
        distance = Vector3.Distance(Player.GetComponent<Transform>().position, transform.position);
        if (distance <= interactDistance)
        {
           thisObject.AddComponent<FixedJoint>();
           thisObject.GetComponent<FixedJoint>().connectedBody = aim;
        }

    }
     void Update()
    {
       // Destroy(thisObject.GetComponent<FixedJoint>());
    }

}

//transform.rotation = Quaternion.Slerp(transform.rotation,
//Quaternion.Euler(transform.rotation.x, openDoor, transform.rotation.z), speed*Time.deltaTime);
//onOpen = true;

