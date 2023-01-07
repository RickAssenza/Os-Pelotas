using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject tiro;
    public Transform arma;
    public float velocidadeTiro;
    private float timer;
    public float intervalo;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


        timer += Time.deltaTime;
        if (timer > intervalo)
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
