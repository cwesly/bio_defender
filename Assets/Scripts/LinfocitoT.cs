using UnityEngine;

public class LinfocitoT : MonoBehaviour
{
    // Contador compartilhado por todas as instâncias para impor o limite global de 7
    public static int InstanciasAtivas { get; private set; }

    private BoxCollider2D col;
    private SpriteRenderer sr;

    void Awake()
    {
        InstanciasAtivas++;
    }

    void OnDestroy()
    {
        InstanciasAtivas--;
    }

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        // Nasce inativo: sem colisão e 50% transparente para sinalizar que ainda está se preparando
        col.enabled = false;
        Color c = sr.color;
        c.a = 0.5f;
        sr.color = c;

        // Ativa completamente após 3 segundos
        Invoke(nameof(AtivarLinfocito), 3f);
    }

    void AtivarLinfocito()
    {
        col.enabled = true;

        Color c = sr.color;
        c.a = 1f;
        sr.color = c;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        // Ao tocar em qualquer inimigo, ambos são destruídos (troca um por um)
        if (outro.CompareTag("Inimigo") || outro.CompareTag("Virus") || outro.CompareTag("Bacteria"))
        {
            Destroy(outro.gameObject);
            Destroy(gameObject);
        }
    }
}
