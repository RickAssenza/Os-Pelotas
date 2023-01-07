using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    
    public GameObject pontoA;
public bool isMove;
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, pontoA.transform.position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                GetComponent<Rigidbody2D>().gravityScale = 0.7f;
                GetComponent<Rigidbody2D>().mass = 10;
                break;
        }
           
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":

                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().mass = 0;
                isMove = true;
                break;

        }
    }

}



