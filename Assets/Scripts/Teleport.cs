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
    public bool onWall;

    void Start()
    {
        canTeleport = false;
        onWall = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canTeleport && !onWall) //Teleport on Right Click
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Mathf.Abs(maincamera.transform.position.z);
            transform.position = maincamera.ScreenToWorldPoint(mousePos);
            //Above few lines of code by ChatGPT https://chatgpt.com/

            canTeleport = false;
        }

        if(!canTeleport)    //Cooldown for teleport
        {
            timer += Time.deltaTime;
            if(timer > cooldown){
                canTeleport = true;
                timer = 0f;
            }
        }
    }

    void OnMouseOver()
    {
        Wallscript w = GetComponent<Wallscript>();
        if(w)
        {
            onWall = true;
        }
        else
        {
            onWall = false;
        }
    }
}


