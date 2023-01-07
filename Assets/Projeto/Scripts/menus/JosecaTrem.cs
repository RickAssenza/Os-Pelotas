using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class JosecaTrem : MonoBehaviour
{
    

    private Animator playerAnimator;

    private Rigidbody2D playerRb;

    public GameObject posicao1;
    public GameObject posicao2;
    public GameObject posicao3;
    public GameObject posicao4;
    public GameObject posicao5;

    [SerializeField] private float speed;

    [SerializeField] private float touchRun = 0.0f;


    public GameObject painel1;
    public GameObject painel2;
    public GameObject painel3;
    public GameObject painel4;
    public GameObject painel5;
    public GameObject painel6;
    public GameObject painelseisemeio;

    public GameController gameController;



    // Start is called before the first frame update
    void Start()
    {
       
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType(typeof(GameController)) as GameController;


        switch (PlayerPrefs.GetInt("Spawn"))
        {
            case 2:
                playerRb.transform.position = posicao1.transform.position;
                break;
            case 3:
                playerRb.transform.position = posicao2.transform.position;
                break;
            case 4:
                playerRb.transform.position = posicao3.transform.position;
                break;
            case 5:
                playerRb.transform.position = posicao4.transform.position;
                break;
            case 6:
                playerRb.transform.position = posicao5.transform.position;   
                break;
            case 7:
                playerRb.transform.position = posicao1.transform.position;
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


        touchRun = CrossPlatformInputManager.GetAxisRaw("Vertical"); ;

        if(touchRun < 0)
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

        }
    }

   private void EsconderPainel1()
    {
        painel1.SetActive(false);
    }










}

