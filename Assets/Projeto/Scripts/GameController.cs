using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject painelVida;
    private int totalscore;
    public Text txtmoedas;
    public int qtdMoedas;
    public int score;

    public GameController instance;

  
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        totalscore = PlayerPrefs.GetInt("qtdChaves");

        score = PlayerPrefs.GetInt("Moedas");

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("qtdChaves"));

        if(PlayerPrefs.GetInt("qtdChaves") > 7)
        {
            Debug.Log("FUNCIONOU KRL!");
        }

        txtmoedas.text = score.ToString();
        
       

        //DontDestroyOnLoad(this.gameObject);
    }

    public void Coeltacaodemoedas(Collider2D collision)
    {
        PlayerPrefs.SetInt("Moedas", score);
        Destroy(collision.gameObject);
        score += 1;


        if (score > 9)
        {
            painelVida.SetActive(true);
        }
        
    }

    public void ChaveColetada(Collider2D collision)
    {
        totalscore++;
        Destroy(collision.gameObject);
        PlayerPrefs.SetInt("qtdChaves", totalscore);
    }

    
}
