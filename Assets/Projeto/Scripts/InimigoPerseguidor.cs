using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPerseguidor : MonoBehaviour
{
    public float distancia;
    public float speed;
    //public Transform playerPosition;
    public Rigidbody2D enemieRb;
    private PlayerController player;

    public int maxDistancia;
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(transform.position, player.transform.position);

        if(distancia < maxDistancia)
        {
            Seguir();
        }

    }


    private void Seguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }


}
