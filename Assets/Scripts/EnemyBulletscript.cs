using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletscript : MonoBehaviour
{
    //Drag in player's position
    //public Transform playerTransform;
    private Vector3 playerPos;
    private Rigidbody2D rb;
    //Set bullet speed
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = playerPos - transform.position;
        Vector3 rotation = transform.position - playerPos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float Zrotate = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Zrotate + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Wallscript w = collision.gameObject.GetComponent<Wallscript>();
        PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
        if(w || pm)
        {
            Destroy(gameObject);
        }
    }
}
