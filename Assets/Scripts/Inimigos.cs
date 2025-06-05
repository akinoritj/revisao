using System;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    [SerializeField] private int dano = 1;
    [SerializeField] private float distanciaDeAtaque;
    [SerializeField] private float velocidade;
    [SerializeField] private float distanciaPersegue;
    [SerializeField] private float forcaPulo;
    [SerializeField] private LayerMask layerChao;
    [SerializeField] private Transform sensorChao;
    private bool noChao;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform player;
    void Start()
    {
        forcaPulo = 7f;
        noChao = true;
        velocidade = 2f;
        distanciaPersegue = 8f;
        distanciaDeAtaque = 1.5f;
        anim = GetComponent<Animator>();
        player = FindFirstObjectByType<PlayerCodes>().transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distancia = Vector2.Distance(transform.position, player.position);

        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        float distanciaAltura = player.position.y - transform.position.y;
        float distanciaHorizontal = Math.Abs(player.position.x - transform.position.x);
        bool temChao = Physics2D.OverlapCircle(sensorChao.position, 1f, layerChao);

        if (distancia < distanciaPersegue && distancia > distanciaDeAtaque && temChao)
        {
            if (distanciaAltura > 1f && distanciaHorizontal > 1f && noChao)
            {
                rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
                noChao = false;
            }
        }

        if (distancia < distanciaPersegue && distancia > distanciaDeAtaque)
        {
            Vector2 direcao = (player.position - transform.position).normalized;
            transform.position += (Vector3)direcao * velocidade * Time.deltaTime;
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        anim.SetBool("IsAttack", distancia < distanciaDeAtaque);
    }

    public void CausarDano()
    {
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Player"));
        if (playerCol != null)
        {
            PlayerCodes player = playerCol.GetComponent<PlayerCodes>();
            if (player != null)
            {
                player.ReceberDano(dano);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = false;
        }
    }
}