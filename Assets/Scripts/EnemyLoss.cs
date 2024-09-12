using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoss : MonoBehaviour
{
    public int Health = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Health goes down each time player bullet hits enemy
        Bulletscript b = collision.gameObject.GetComponent<Bulletscript>();
        if(b)
        {
            Health--;
        }
    }
}
