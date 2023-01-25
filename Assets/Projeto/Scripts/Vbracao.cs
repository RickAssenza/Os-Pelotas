using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vbracao : MonoBehaviour
{
    public static Vbracao instance;
    
    
    public Animator animador;



    private void Awake()
    {
        if(instance == null)
          instance = this;
    }





    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
        animador.Play("CamerasHake");
    }
}
