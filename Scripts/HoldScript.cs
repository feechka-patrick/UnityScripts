using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldScript : MonoBehaviour
{
    public GameObject Player;
    public Transform aim;
    public float interactDistance = 1f;
    public float distance;
    public bool ObjectController = false;
    public Image hand;

    void Start()
    {
        hand.enabled = false;
    }
    void OnMouseOver()
    {
        distance = Vector3.Distance(Player.GetComponent<Transform>().position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && (distance <= interactDistance))
        {
            transform.SetParent(aim);
            ObjectController = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
        if (distance <= interactDistance)
        {
            hand.enabled = true;
        }
        if (distance > interactDistance)
        {
            hand.enabled = false;
        }
    }

    void Update()
    {
        if (ObjectController)
        {
            transform.position = aim.position;
            //transform.rotation = aim.rotation;
        }
        if (ObjectController && Input.GetKeyDown(KeyCode.R))
        {
            transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            ObjectController = false;
        }
    }

    void onMouseExit()
    {
        hand.enabled = false;
    }
}
