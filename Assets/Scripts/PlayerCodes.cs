using UnityEngine;

public class PlayerCodes : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float forcaPulo = 5f;
    private bool noChao = true;
    private bool vida;
    [SerializeField] private GameObject canvasMorte;

    void Start()
    {
        vida = true;
        rb = GetComponent<Rigidbody2D>();
        canvasMorte.SetActive(false);
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0f)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1f, 1f);
        }

        if(noChao && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            noChao = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * velocidade, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            noChao = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            noChao = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Morte"))
        {
            vida = false;
            Time.timeScale = 0f;
            canvasMorte.SetActive(true);
        }
    }
}