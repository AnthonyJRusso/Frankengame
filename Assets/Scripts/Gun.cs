using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Credit to tutorial: https://youtu.be/-bkmPm_Besk?si=ltPoYMAlDX0LmVyZ

    private Camera mainCam;
    private Vector3 mousePos;
    //Sets bullet position
    public GameObject bullet;
    public Transform bulletTransform;

    //Controls shooting cooldown
    public bool canFire;
    public float timer;
    //Set cooldown in inspector
    public float cooldown;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
    }

    void Update()
    {
        //Rotating reticle based on the position of the mouse
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float Zrotate = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Zrotate);

        //Gun will fire after cooldown expires, then resets cooldown
        if(!canFire){
            timer += Time.deltaTime;
            if(timer > cooldown){
                canFire = true;
                timer = 0f;
            }
        }

        //Spawns bullet prefab at position
        if(Input.GetMouseButtonDown(0) && canFire){
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
