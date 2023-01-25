using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Aviao : MonoBehaviour
{
    public MenuPause menu;

    public GameController gameController;

    private Rigidbody2D rb;
    private int speed = 5;
    public float velocidade;
   
    //Dano
    public Color noHitColor; 
    private SpriteRenderer srPlayer;
    private bool playerInvencivel;
    private int vida = 3;
    public Sprite[] spriteVida;
    public Image barravida;

    public GameObject fumacaRoxa;

    //Audio
    public AudioSource fxPrincipal;
    public AudioClip fxDano;
    public AudioClip fxTiro;
    public AudioClip fxPlaca;
    //Tiro
    public GameObject tiro;
    public bool atirei;
    public float velocidadeTiro;
    private int tiros;
    public int minimoTios;
    public Text txttiros;
    public Transform arma;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        menu = FindObjectOfType(typeof(MenuPause)) as MenuPause;
        srPlayer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();

        tiros = 200;


    }



    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(velocidade, rb.velocity.y);


        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * speed;
            

        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            atirei = true;

        }
        txttiros.text = ("X " + tiros.ToString());

        if (menu.currentState == Gamestate.GAMEPLAY)
        {
            Atirar();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Montanha":
                gameObject.SetActive(false);

                GameObject tempExplosion = Instantiate(fumacaRoxa, transform.position, transform.localRotation);
                Destroy(tempExplosion, 0.5f);
                Invoke("CarregaJogo", 3f);
                break;

            case "Inimigo":
                Vbracao.instance.Shake();
                Destroy(collision.gameObject);
                Hurt(); break;

            case "Placa2":


                SceneManager.LoadScene("QuartoFliper");

                break;


            case "Chave":
                fxPrincipal.PlayOneShot(fxPlaca);
                gameController.ChaveColetada(collision);
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
            tiros--;
            atirei = false;
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
            rb.AddForce(new Vector2(0f, 100));

            fxPrincipal.PlayOneShot(fxDano);
        }



        if (vida < 1)
        {
            gameObject.SetActive(false);

            GameObject tempExplosion = Instantiate(fumacaRoxa, transform.position, transform.localRotation);
            Destroy(tempExplosion, 0.5f);
            Invoke("CarregaJogo", 3f);
        }

        barravida.sprite = spriteVida[vida];
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

    void CarregaJogo()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}



