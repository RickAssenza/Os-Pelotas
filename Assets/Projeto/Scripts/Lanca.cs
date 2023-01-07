using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanca : MonoBehaviour
{
    public Vector2 intervalo;
    private Animator anim;
    
    // Start is called before the first frame update
    private void awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    
    IEnumerator Start()
    {

       
        
            yield return new WaitForSeconds(Random.Range(intervalo.x, intervalo.y));
            anim.enabled = true;
        

    }

}
