using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    private Rigidbody2D rbfundo;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rbfundo = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rbfundo.velocity = new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {

       
    }
}
