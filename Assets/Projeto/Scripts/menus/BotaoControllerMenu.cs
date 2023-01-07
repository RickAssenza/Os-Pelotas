using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoControllerMenu : MonoBehaviour
{
    public GameObject telaInicial;
    public GameObject linguagem;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panelMusica;
    // Start is called before the first frame update
    void Start()
    {
        panelMusica.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BotaoStory()
    {
        linguagem.SetActive(true);
        panelMusica.SetActive(false);
    }

    public void Proximo1()
    {
        linguagem.SetActive(false);
        telaInicial.SetActive(true);
    }

    public void Proximo2()
    {
       
        telaInicial.SetActive(false);
        panel2.SetActive(true);
    }

    public void Proximo3()
    {
        
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

    public void Proximo4()
    {

       panel3.SetActive(false);
       panel4.SetActive(true);     
    }

    public void Proximo5()
    {

        panel4.SetActive(false);
        panel5.SetActive(true);
    }
}
