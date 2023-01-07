using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene2 : MonoBehaviour
{

    public Transform enemie;
    public SpriteRenderer enemieSprite;
    public Transform[] position;
    public float speed;
    public bool isRight;
    public Transform playerPosition;
    private int idTarget = 1;
    public float distancia;
    public GameObject alho;


    // Start is called before the first frame update
    void Start()
    {
        enemie.position = position[0].position;
        idTarget = 1;
    }

    // Update is called once per frame
    void Update()
    {

        distancia = Vector2.Distance(transform.position, playerPosition.position);






        if (distancia < 8)
        {
            enemie.position = Vector3.MoveTowards(enemie.position, position[idTarget].position, speed * Time.deltaTime);

            if (enemie.position == position[idTarget].position)
            {
                idTarget += 1;
                if (idTarget == position.Length)
                {
                    idTarget = 0;
                }
            }



            if (position[idTarget].position.x < enemie.position.x && isRight)
            {
                Flip();
            }
            else if (position[idTarget].position.x > enemie.position.x && isRight == false)
            {
                Flip();
            }

        }
        else
        {
            return;
        }
    }

    void Flip()
    {

        isRight = !isRight;
        enemieSprite.flipX = !enemieSprite.flipX;


    }





}
