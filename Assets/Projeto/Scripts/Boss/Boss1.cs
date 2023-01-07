using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public GameObject hitPrefab;
    public float maxDistancia;
    public float distancia;
    private PlayerController player;


    public GameObject tiro;
    public Transform arma;
    public float velocidadeTiro;
    private float timer;

    public int vida = 36;

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
        if (timer > 3f && distancia < maxDistancia)
        {
            timer = 0;
            Shoot();
        }


        if (vida < 1)
        {
            Destroy(this.gameObject);
            GameObject tempExplosion = Instantiate(hitPrefab, transform.position, transform.localRotation);
            Destroy(tempExplosion, 0.5f);
        }
    }

    public void Shoot()
    {
        GameObject temp = Instantiate(tiro);
        temp.transform.position = arma.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0f);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Bala":
                vida--;
                break;

        }

    }

}
