using UnityEngine;

public class Inimigos : MonoBehaviour
{
    [SerializeField] private int dano = 1; 
    private Animator anim;
    [SerializeField] private float distanciaDeAtaque = 1f; 
    private Transform player;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerCodes>().transform;
    }
    void Update()
    {
        float distancia = Vector2.Distance(transform.position, FindObjectOfType<PlayerCodes>().transform.position);
        if (distancia < distanciaDeAtaque)
        {
            anim.SetBool("IsAttack", true);
            CausarDano();
        }
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
}
