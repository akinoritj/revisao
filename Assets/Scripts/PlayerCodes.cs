using UnityEngine;
using UnityEngine.Animations;

public class PlayerCodes : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    [SerializeField] private int dano;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    private bool noChao = true;
    [SerializeField] private int vida = 5;
    [SerializeField] private GameObject canvasMorte;
    private Animator anim;

    void Start()
    {
        dano = 1;
        velocidade = 5f;
        forcaPulo = 5f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canvasMorte.SetActive(false);
    }

    void Update()
    {
        anim.SetBool("Run", moveInput != 0f);
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0f)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1f, 1f);
        }

        if (noChao && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Pulo");
            anim.SetBool("noChao", false);
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            noChao = false;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * velocidade, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = true;
            anim.SetBool("noChao", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = false;
            anim.SetBool("noChao", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Morte"))
        {
            ReceberDano(vida);
        }
    }

    public void ReceberDano(int dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            vida = 0;
            canvasMorte.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Ataque()
    {
        anim.SetTrigger("Ataque");
    }
}