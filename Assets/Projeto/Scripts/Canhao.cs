using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Morte":

                Destroy(this.gameObject);


                break;




        }
    }
}
