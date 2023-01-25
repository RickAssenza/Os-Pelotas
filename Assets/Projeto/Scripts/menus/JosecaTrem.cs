using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class JosecaTrem : MonoBehaviour
{
    
    
    private int mundo2;

    private Animator playerAnimator;

    private Rigidbody2D playerRb;

    public GameObject posicao1;
    public GameObject posicao2;
    public GameObject posicao3;
    public GameObject posicao4;
    public GameObject posicao5;
    public GameObject posicao6;
    public GameObject posicaoH1;
    public GameObject posicaoH2;
    public GameObject posicaoH3;
    public GameObject posicaoH4;
    public GameObject posicaoH5;
    public GameObject posicaoH6;


    [SerializeField] private float speed;

    [SerializeField] private float touchRun = 0.0f;


    public GameObject painel1;
    public GameObject painel2;
    public GameObject painel3;
    public GameObject painel4;
    public GameObject painel5;
    public GameObject painel6;
    public GameObject painelseisemeio;
    public GameObject painel7;
    public GameObject painel8;
    public GameObject painel9;
    public GameObject painel10;
    public GameObject painel11;
    public GameObject painel12;
    public GameObject paineldozeemeio;
    public GameObject painelHome;
    public GameObject paineHome1;


    public GameController gameController;



    // Start is called before the first frame update
    void Start()
    {
        mundo2 = PlayerPrefs.GetInt("Troca");
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType(typeof(GameController)) as GameController;


        switch (PlayerPrefs.GetInt("Spawn"))
        {
            case 2:
                playerRb.transform.position = posicao2.transform.position;
                break;
            case 3:
                playerRb.transform.position = posicao3.transform.position;
                break;
            case 4:
                playerRb.transform.position = posicao4.transform.position;
                break;
            case 5:
                playerRb.transform.position = posicao5.transform.position;
                break;
            case 6:
                playerRb.transform.position = posicao6.transform.position;    
                break;
            case 7:
                playerRb.transform.position = posicao1.transform.position;
                break;
            case 14:
                playerRb.transform.position = posicaoH1.transform.position;
                break;
            case 16:
                playerRb.transform.position = posicaoH2.transform.position;
                break;
            case 11:
                playerRb.transform.position = posicaoH3.transform.position;
                break;
            case 13:
                playerRb.transform.position = posicaoH4.transform.position;
                break;
            case 17:
                playerRb.transform.position = posicaoH5.transform.position;
                break;
            case 12:
                playerRb.transform.position = posicaoH6.transform.position;
                break;

        }







        /* if (PlayerPrefs.GetInt("Spawn") == 2)
        {
            playerRb.transform.position = posicao1.transform.position;
        }

        if (PlayerPrefs.GetInt("Spawn") == 3)
        {
            playerRb.transform.position = posicao2.transform.position;
        }
       
        if (PlayerPrefs.GetInt("Spawn") == 4)
        {
            playerRb.transform.position = posicao3.transform.position;
        }
       
        if (PlayerPrefs.GetInt("Spawn") == 5)
        {
            playerRb.transform.position = posicao4.transform.position;
        }
        
        if (PlayerPrefs.GetInt("Spawn") == 6)
        {
            playerRb.transform.position = posicao5.transform.position;
        }

        if (PlayerPrefs.GetInt("Spawn") == 7)
        {
            playerRb.transform.position = posicao1.transform.position;
        }

        //Debug.Log(PlayerPrefs.GetInt("Spawn"));*/


    }

    // Update is called once per frame
    void Update()
    {
        
        //playerAnimator.SetBool("IsGrouded", isGrounded);


        touchRun = CrossPlatformInputManager.GetAxisRaw("Vertical");
       

        if (touchRun < 0)
        {
            playerAnimator.SetBool("Ré", true);
            playerAnimator.SetBool("1marcha", false);
        }
        else if(touchRun >= 0)
        {
            playerAnimator.SetBool("1marcha", true);
            playerAnimator.SetBool("Ré", false);
        }

        // SetaMovimentos();

        
    }

    void MovePlayerH(float movimentoH)
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, movimentoH * speed);
        
    }

    private void FixedUpdate()
    {
        MovePlayerH(touchRun);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "fASE1":
                
                painel1.SetActive(true);
                
                break;


            case "Fase2":
                
                painel2.SetActive(true);
                
                break;

            case "Fase3":
                
                painel3.SetActive(true);
                
                break;

            case "Fase4":
                
                painel4.SetActive(true);
                
                break;

            case "Fase5":
                
                painel5.SetActive(true);
                
                break;

            case "Fase6":
                
                if (PlayerPrefs.GetInt("qtdChaves") >= 5 )
                {
                    painel6.SetActive(true);
                }
                else
                {
                    painelseisemeio.SetActive(true);
                }
                
                break;

            case "Fase7":
                painel7.SetActive(true);
                break;

            case "Fase8":
                painel8.SetActive(true);
                break;
            
            case "Fase9":
                painel9.SetActive(true);
                break;

            case "Fase10":
                painel10.SetActive(true);
                break;
            
            case "Fase11":
                painel11.SetActive(true);
                break;

            case "Fase12":
                if (PlayerPrefs.GetInt("qtdChaves") >= 10)
                {
                    painel12.SetActive(true);
                }
                else
                {
                    paineldozeemeio.SetActive(true);
                }
                break;

            case "Trocador":

                mundo2 = 1;
                PlayerPrefs.SetInt("Troca", mundo2);

                paineHome1.SetActive(true);
                break;
            
            case "Trocador1":
                if (PlayerPrefs.GetInt("Troca", mundo2) == 1)
                {
                    painelHome.SetActive(true);
                }

                break;



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "fASE1":
                painel1.SetActive(false);
                break;

            case "Fase2":
                painel2.SetActive(false);
                break;

            case "Fase3":
                painel3.SetActive(false);
                break;

            case "Fase4":
                painel4.SetActive(false);
                break;

            case "Fase5":
                painel5.SetActive(false);
                break;

            case "Fase6":
                painel6.SetActive(false);
                painelseisemeio.SetActive(false);
                break;

            case "Fase7":
                painel7.SetActive(false);
                break;

            case "Fase8":
                painel8.SetActive(false);
                break;

            case "Fase9":
                painel9.SetActive(false);
                break;

            case "Fase10":
                painel10.SetActive(false);
                break;



            case "Fase11":
                painel11.SetActive(false);
                break;

            case "Fase12":
                if (PlayerPrefs.GetInt("qtdChaves") >= 10)
                {
                    painel12.SetActive(false);
                }
                else
                {
                    paineldozeemeio.SetActive(false);
                }
                break;


            case "Trocador":
                
                paineHome1.SetActive(false);
                break;
            
            case "Trocador1":
                if(PlayerPrefs.GetInt("Troca", mundo2) == 1)
                {
                    painelHome.SetActive(false);
                }
                
                break;

        }
    }

   private void EsconderPainel1()
    {
        painel1.SetActive(false);
    }










}

