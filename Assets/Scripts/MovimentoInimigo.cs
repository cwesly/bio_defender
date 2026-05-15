using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public float velocidade = 3f;
    public float limiteTelaY = -6f;
    public int danoAoOrganismo = 10;

    private SaudeOrganismo scriptSaude;

    void Start()
    {
        // Encontra o script de saúde que está no objeto SistemaDeJogo
        scriptSaude = GameObject.Find("SistemaDeJogo").GetComponent<SaudeOrganismo>();
    }

    void Update()
    {
        transform.position += Vector3.down * velocidade * Time.deltaTime;

        if (transform.position.y < limiteTelaY)
        {
            // Se o vírus passar, o organismo toma dano
            scriptSaude.TomarDano(danoAoOrganismo);
            Destroy(gameObject);
        }
    }

    // Se o vírus tocar no Macrófago (Player)
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player")) 
        {
            scriptSaude.TomarDano(5); // Tocar no player tira menos vida ou causa efeito Sticky
            Destroy(gameObject);
        }
    }
}