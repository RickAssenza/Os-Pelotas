using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalscore;
    public Text txtmoedas;
    public int qtdMoedas;
    private int score;

    public GameController instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        totalscore = PlayerPrefs.GetInt("qtdChaves");
        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("qtdChaves"));

        if(PlayerPrefs.GetInt("qtdChaves") > 7)
        {
            Debug.Log("FUNCIONOU KRL!");
        }


        //DontDestroyOnLoad(this.gameObject);
    }

    public void Coeltacaodemoedas(Collider2D collision)
    {
        Destroy(collision.gameObject);
        qtdMoedas += 1;     
        txtmoedas.text = ("X " + qtdMoedas.ToString());

    }

    public void ChaveColetada(Collider2D collision)
    {
        totalscore++;
        Destroy(collision.gameObject);
        PlayerPrefs.SetInt("qtdChaves", totalscore);
    }
}
