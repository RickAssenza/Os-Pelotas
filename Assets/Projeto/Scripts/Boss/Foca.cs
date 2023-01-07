using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foca : MonoBehaviour
{
    public GameObject hitPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "Ground":
              
                GameObject tempExplosion = Instantiate(hitPrefab, collision.gameObject.transform.position, transform.localRotation);
                Destroy(tempExplosion, 0.5f);
                Destroy(collision.gameObject);
               
                break;
        }

    }

}