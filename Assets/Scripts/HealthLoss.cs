using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthLoss : MonoBehaviour
{
    public Image Health;
    public GameObject Losetext;

     //creates place to write in name of scene
    public string SceneName;
 


    // Start is called before the first frame update
    void Start()
    {
        Losetext.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Health goes down each time enemy bullet hits player
        EnemyBulletscript eb = collision.gameObject.GetComponent<EnemyBulletscript>();
        if(eb)
        {
            Health.fillAmount -= 0.21f;
        }

        if(Health.fillAmount == 0)
        {
            Time.timeScale = 0;
             Losetext.SetActive(true);
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(SceneName);
    }
}
