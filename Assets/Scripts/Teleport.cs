using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Camera maincamera; // Have to assign the main camera 

    //Controls teleporting cooldown
    public bool canTeleport;
    public float timer;
    //Set cooldown in inspector
    public float cooldown;

    //UI Component
    public GameObject TeleportLoad;

    void Start()
    {
        canTeleport = false;
        TeleportLoad.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canTeleport) //Teleport on Right Click
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Mathf.Abs(maincamera.transform.position.z);
            transform.position = maincamera.ScreenToWorldPoint(mousePos);
            //Above 3 lines of code by ChatGPT https://chatgpt.com/

            canTeleport = false;
            TeleportLoad.SetActive(false);
        }

        if(!canTeleport)    //Cooldown for teleport
        {
            timer += Time.deltaTime;
            if(timer > cooldown){
                canTeleport = true;
                timer = 0f;

                TeleportLoad.SetActive(true);
            }
        }
    }
}


