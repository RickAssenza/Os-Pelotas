using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{

    public EnemieController enemieController;
    public GameObject hitPrefab;
    public GameObject hitBoss;
    
   

    // Start is called before the first frame update
    void Start()
    {
        enemieController = FindObjectOfType(typeof(EnemieController)) as EnemieController;
    }

    // Update is called once per frame
    void Update()
    {

    }





    private void OnTriggerEnter2D(Collider2D collision)
    {




        switch (collision.gameObject.tag)
        {
            case "Inimigo":

                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                GameObject tempExplosion = Instantiate(hitPrefab, transform.position, transform.localRotation);
                Destroy(tempExplosion, 0.5f);
                

                break;

            case "Crazy":
                Destroy(this.gameObject); break;

            case "Boss":
                Destroy(this.gameObject); 
                 GameObject tempExplosao = Instantiate(hitBoss, transform.position, transform.localRotation);
                Destroy(tempExplosao, 0.5f); break;



        }

    }


}


