using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeTiro : MonoBehaviour
{
    public GameObject tiro;
    public Transform arma;
    public float velocidadeTiro;
    private float timer;
    public float intervalo;

    public float minDistancia;
    public float distancia;
    private PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {



        distancia = Vector2.Distance(transform.position, player.transform.position);
        timer += Time.deltaTime;
        if (timer > intervalo && distancia > minDistancia)
        {
            timer = 0;
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject temp = Instantiate(tiro);
        temp.transform.position = arma.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0f);

    }
}
