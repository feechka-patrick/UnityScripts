using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public bool CursorLock = true; // курсор заблокирован
    // Start is called before the first frame update
    void Start()
    {
        if (CursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("ESC") && CursorLock)
        {
            Cursor.lockState = CursorLockMode.None; //показываем курсор
            CursorLock = false;
        }
        
    }
}
