using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControleFoca : MonoBehaviour
{
  
    public Transform plataforma, pontoA, pontoB;
    public float velocidadePlataforma;
    public Vector3 pontoDestino;
    private GameObject player;


    public float distancia;
    private PlayerController luiz;
    public float maxDistancia;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        plataforma.position = pontoA.position;
        pontoDestino = pontoB.position;
        luiz = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        distancia = Vector2.Distance(transform.position, luiz.transform.position);


        if (distancia < maxDistancia)
        {
            if (plataforma.position == pontoA.position)
            {
                pontoDestino = pontoB.position;
            }

            if (plataforma.position == pontoB.position)
            {
                rb.gravityScale = 2;
            }

            plataforma.position = Vector3.MoveTowards(plataforma.position, pontoDestino, velocidadePlataforma);

        }

    }

   /* public void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
          

              

        }
    }*/

}