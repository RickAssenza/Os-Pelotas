using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject panelatirar;
    public GameObject panelInimigo;
    public Text txtAtirar;
    public Text txtInimigo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Atirar":

                panelatirar.SetActive(true);
                
                if(PlayerPrefs.GetInt("Idioma") == 1)
                {
                    txtAtirar.text = ("Aperte qualquer lugar da tela para atirar");
                }

                if (PlayerPrefs.GetInt("Idioma") == 2)
                {
                    txtAtirar.text = ("Press anywhere on the screen to shoot");
                }

                if (PlayerPrefs.GetInt("Idioma") == 3)
                {
                    txtAtirar.text = ("Presiona en cualquier parte de la pantalla para disparar");
                }

                break;

            case "IniTutorial":

                panelInimigo.SetActive(true);
               
                if (PlayerPrefs.GetInt("Idioma") == 1)
                {
                    txtInimigo.text = ("Pule em cima do inimgo para elimina-lo");
                }

                if (PlayerPrefs.GetInt("Idioma") == 2)
                {
                    txtInimigo.text = ("Jump on the enemy to eliminate him");
                }

                if (PlayerPrefs.GetInt("Idioma") == 3)
                {
                   txtInimigo.text = ("salta encima del enemigo para eliminarlo");
                }
                break;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            switch (collision.gameObject.tag)
            {
                case "Atirar":
                    panelatirar.SetActive(false); break;

                case "IniTutorial":
                    panelInimigo.SetActive(false); break;
            }
        }
    }
}
