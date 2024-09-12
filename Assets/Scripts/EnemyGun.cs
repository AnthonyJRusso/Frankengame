using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    //Drag in player's position
    public Transform playerTransform;
    private Vector3 playerPos;
    //Sets bullet position
    public GameObject bullet;
    public Transform bulletTransform;

    //Controls shooting cooldown
    public bool canFire;
    public float timer;
    //Set cooldown in inspector
    public float cooldown;

    public bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating reticle based on the position of the player
        playerPos = playerTransform.position;
        Vector3 rotation = playerPos - transform.position;
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
        if(canFire && inRange){
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
        //When player enters range of collider enemy starts firing
        PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
        if(pm){
            inRange = true;
        }
     }
}
