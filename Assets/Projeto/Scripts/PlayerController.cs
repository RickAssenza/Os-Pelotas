using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{

    
    
    private Vbracao camerada;

    public MenuPause menu;



    public GameObject portal2;
    public GameObject portalUltimo;



    //Vida
    public Color noHitColor;
    private bool playerInvencivel;
    private SpriteRenderer srPlayer;
    public GameObject fumacaDeath;
    private int vida = 3;
    public Sprite[] spriteVida;
    public Image barravida;

    public EnemieController enemieController;
    private GameController gameController;

    public GameObject tiro;
    public Transform arma;//onde sai o tiro.
    public bool atirei;
    public float velocidadeTiro;
    public int tiros;
    public int minimoTios;
    public Text txttiros;
    
   

    private bool flipx;



    private Animator playerAnimator;

    private Rigidbody2D playerRb;
    public Transform groudcheck;

    private bool isGrounded = false;

    [SerializeField] private float speed;

    [SerializeField] private float touchRun = 0.0f;

    public bool facingRight = true;

    public Transform saidortiro;

    public GameObject fumacaRoxa;

    public GameObject lh;
    public Transform tranformTijolo;
    public Transform tlh;
    
    //pulo
    public bool jump = false;
    public int numberJumps;
    public int maximoJump = 1;
    public float jumpForce;



    //Audio
    public AudioSource fxPrincipal;
    public AudioClip fxTiro;
    public AudioClip fxPuloInimigo;
    public AudioClip fxJump;
    public AudioClip fxPlaca;
    public AudioClip fxDano;
    public AudioClip fxMoeda;



    public GameObject hitPrefab;
    public GameObject hitAddforce;
    public Transform transformAddforce;
    // Start is called before the first frame update
    void Start()
    {

       
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        enemieController = FindObjectOfType(typeof(EnemieController)) as EnemieController;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        srPlayer = GetComponent<SpriteRenderer>();
        menu = FindObjectOfType(typeof(MenuPause)) as MenuPause;
        camerada = FindObjectOfType(typeof(Vbracao)) as Vbracao;
    }

    // Update is called once per frame
    void Update()
    {


        
       
        
        

        SetaMovimentos();



        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            jump = true;
            
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            atirei = true;

        }


        if (menu.currentState == Gamestate.GAMEPLAY)
        {
            Atirar();
        }




        //touchRun = Input.GetAxisRaw("Horizontal");
        touchRun = CrossPlatformInputManager.GetAxisRaw("Horizontal");


       





        
       
    }

    

     void MovePlayerH(float movimentoH)
    {
        playerRb.velocity = new Vector2(movimentoH * speed, playerRb.velocity.y);
        if (movimentoH < 0 && facingRight || (movimentoH > 0 && !facingRight))
        {
            Flip();
        }
    }

    void CarregaJogo()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    private void FixedUpdate()
    {
        MovePlayerH(touchRun);

        if (jump)
        {
            JumpPlayer();
           
        }
    }

    void JumpPlayer()
    {
        if (isGrounded)
        {
            numberJumps = 0;
        }

        if (isGrounded || numberJumps < maximoJump)
        {
            
            
          playerRb.AddForce(new Vector2(0f, jumpForce));
        
            
            isGrounded = false;
            numberJumps++;
            fxPrincipal.PlayOneShot(fxJump);
        }
        jump = false;
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        velocidadeTiro = velocidadeTiro * -1;
    }


        void SetaMovimentos()
    {
        playerAnimator.SetBool("Walk", playerRb.velocity.x != 0 && isGrounded);
        playerAnimator.SetBool("Jump", !isGrounded);
        playerAnimator.SetBool("IsGrounded", isGrounded);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "AddForce":

                //adicionando força ao pulo.
                Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(new Vector2(0f, 300));
                GameObject tempoExplosion = Instantiate(hitAddforce, transform.position, transform.localRotation);
                Destroy(tempoExplosion, 0.5f);
                Destroy(collision.gameObject); break;



            case "Coletavel":
                gameController.Coeltacaodemoedas(collision);
                fxPrincipal.PlayOneShot(fxMoeda);

                break;




            case "Inimigo":

                
                Rigidbody2D rigid = GetComponentInParent<Rigidbody2D>();
                rigid.velocity = new Vector2(rigid.velocity.x, 0f);
                rigid.AddForce(new Vector2(0f, 250));
                Destroy(collision.gameObject);
                GameObject tempExplosion = Instantiate(hitPrefab, transform.position, transform.localRotation);
                Destroy(tempExplosion, 0.5f);

                fxPrincipal.PlayOneShot(fxPuloInimigo); 
                
                break;


            case "Crazy":


                Rigidbody2D rigidi = GetComponentInParent<Rigidbody2D>();
                rigidi.velocity = new Vector2(rigidi.velocity.x, 0f);
                rigidi.AddForce(new Vector2(0f, 250));

                break;



            case "Portal":
                SceneManager.LoadScene("Fase3.5"); break;  
           
            case "Portal2":
                playerRb.transform.position = portal2.transform.position; break;

            case "Portal3":
                SceneManager.LoadScene("QuartoFliper"); break;


            case "Boss":

                Rigidbody2D rigidib = GetComponentInParent<Rigidbody2D>();
                rigidib.velocity = new Vector2(rigidib.velocity.x, 0f);
                rigidib.AddForce(new Vector2(0f, 400));
                Hurt();
                break;

            case "Morte":

                Invoke("CarregaJogo", 0.5f); 
                break;

            case "Chave":
                fxPrincipal.PlayOneShot(fxPlaca);
                gameController.ChaveColetada(collision);
                break;

            case "Placa":

                
                SceneManager.LoadScene("Quarto");
                
                break;

            case "Placa2":


                SceneManager.LoadScene("QuartoFliper");

                break;

            case "Placa3":


                SceneManager.LoadScene("Final");

           
                break;
            
            case "PortalUltimo":
                playerRb.transform.position = portalUltimo.transform.position; break;


        }
    }

   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Plataforma":
                this.transform.parent = collision.transform;
                isGrounded = true;
                break;

            case "Inimigo":
                Vbracao.instance.Shake();
                Destroy(collision.gameObject);
                Hurt(); 
                
                break;

            case "Espinho":
                Hurt();

                break;

            case "Ground":
                isGrounded = true; break;

            case "Foca":

                Rigidbody2D rigidib = GetComponentInParent<Rigidbody2D>();
                rigidib.velocity = new Vector2(rigidib.velocity.x, 0f);
                rigidib.AddForce(new Vector2(0f, 400));
                Hurt();
                break;


            case "Matadouro":
                gameObject.SetActive(false);

                GameObject tempExplosion = Instantiate(fumacaRoxa, transform.position, transform.localRotation);
                Destroy(tempExplosion, 0.5f);
                Invoke("CarregaJogo", 2f);
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Ground":
                
                isGrounded = false;
                break;
        }
    }

    void Hurt()
    {

        if (!playerInvencivel)
        {
            playerInvencivel = true;

            StartCoroutine("Dano");
            vida--;
            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, 150));

            fxPrincipal.PlayOneShot(fxDano);
        }



        if (vida < 1)
        {
            gameObject.SetActive(false);

            GameObject tempExplosion = Instantiate(fumacaRoxa, transform.position, transform.localRotation);
            Destroy(tempExplosion, 0.5f);
            Invoke("CarregaJogo", 2f);
        }

        barravida.sprite = spriteVida[vida];
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {

            case "Plataforma":
                this.transform.parent = null;
                break;
        }
    }


    public void Atirar()
    {
        if (atirei && tiros > minimoTios)
        {
            fxPrincipal.PlayOneShot(fxTiro);
            GameObject temp = Instantiate(tiro);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0f);
            Destroy(temp.gameObject, 1.3f);
            tiros --;
            atirei = false;
        }

        txttiros.text = ("X " + tiros.ToString());
    }

    IEnumerator Dano()
    {
        srPlayer.color = noHitColor;
        yield return new WaitForSeconds(0.1f);

        for (float i = 0; i < 1; i += 0.2f)
        {
            srPlayer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            srPlayer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        srPlayer.color = Color.white;
        playerInvencivel = false;
    }

    public void Vida()
    {
        vida = 3;
        barravida.sprite = spriteVida[vida];
        gameController.score = gameController.score - 10;
        gameController.painelVida.SetActive(false);
    }


}




