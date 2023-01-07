using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public static NewBehaviourScript _instanciaFade;

    public Image iamgeFade;

    public Color _corInicial;
    public Color _corFinal;
    public float duracaoFade;

    public bool isFade;
    private float tempo;
    // Start is called before the first frame update


    private void Awake()
    {
        _instanciaFade = this;
    }

    IEnumerator InicioFade()
    {
        isFade = true;
        tempo = 0f;

        while (tempo <= duracaoFade)
        {
            iamgeFade.color = Color.Lerp(_corInicial, _corFinal, tempo / duracaoFade);
            tempo = tempo + Time.deltaTime;
            yield return null;
        }
       
        isFade = false;

    }

    void Start()
    {
        StartCoroutine(InicioFade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
