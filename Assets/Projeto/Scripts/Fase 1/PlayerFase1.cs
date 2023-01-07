using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerFase1 : MonoBehaviour
{
    //Vida
    private int vida = 3;
    public Sprite[] spriteVida;
    public Image barravida;

    public EnemieController enemieController;

    public GameObject tiro;
    public Transform arma;//onde sai o tiro.
    private bool atirei;
    public float velocidadeTiro;
    private int tiros;
    public int minimoTios;
    public Text txttiros;
    private int score;


    private bool flipx;



    private Animator playerAnimator;

    private Rigidbody2D playerRb;
    public Transform groudcheck;

    private bool isGrounded = false;

    [SerializeField] private float speed;

    [SerializeField] private float touchRun = 0.0f;

    public bool facingRight = true;

    public Transform saidortiro;
    //pulo
    public bool jump = false;
    public int numberJumps;
    public int maximoJump = 1;
    public float jumpForce;

    public GameObject hitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        enemieController = FindObjectOfType(typeof(EnemieController)) as EnemieController;
        tiros = 5;
    }

    // Update is called once per frame
    void Update()
    {

        SetaMovimentos();


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }



        Atirar();

        isGrounded = Physics2D.Linecast(transform.position, groudcheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerAnimator.SetBool("IsGrounded", isGrounded);


        touchRun = Input.GetAxisRaw("Horizontal");
        atirei = Input.GetButtonDown("Fire1");

        txttiros.text = ("X " + tiros.ToString());
        barravida.sprite = spriteVida[vida];

        if (vida < 1)
        {
            gameObject.SetActive(false);
            Invoke("CarregaJogo", 2f);
        }



        



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
        playerAnimator.SetBool("Walk", touchRun != 0 && isGrounded);
        playerAnimator.SetBool("Jump", !isGrounded);

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

                Destroy(collision.gameObject);

                GameObject tempExplosion = Instantiate(hitPrefab, transform.position, transform.localRotation);
                Destroy(tempExplosion, 0.5f);

                break;

            case "Inimigo":

                Rigidbody2D rigid = GetComponentInParent<Rigidbody2D>();
                rigid.velocity = new Vector2(rigid.velocity.x, 0f);
                rigid.AddForce(new Vector2(0f, 250));
                Destroy(collision.gameObject); break;


            case "Gravidade":

                GetComponent<SpriteRenderer>().color = Color.blue;

                break;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Gravidade":
                GetComponent<SpriteRenderer>().color = Color.white; break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Plataforma":
                this.transform.parent = collision.transform;

                break;

            case "Inimigo":

                Destroy(collision.gameObject);
                vida--; break;

        }
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


    private void Atirar()
    {
        if (atirei && tiros > minimoTios)
        {
            GameObject temp = Instantiate(tiro);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0f);
            Destroy(temp.gameObject, 1.3f);
            tiros--;
        }
    }
}
