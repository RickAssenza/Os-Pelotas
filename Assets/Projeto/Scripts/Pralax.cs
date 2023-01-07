using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pralax : MonoBehaviour
{
    private float lenght;
    private float startpos;

    private Transform cam;

    public float paralaxeffect;



    // Start is called before the first frame update
    void Start()
    {

        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;




    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * paralaxeffect;

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
