using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    [Header("Configurações Base")]
    public float velocidade = 3f;
    public float limiteTelaY = -6f;
    public int danoAoOrganismo = 10;

    [Header("Movimento Zigue-Zague")]
    public float amplitude = 2f; // Largura do zigue-zague
    public float frequencia = 2f; // Velocidade do zigue-zague

    private SaudeOrganismo scriptSaude;
    private float posicaoXInicial;

    void Start()
    {
        scriptSaude = FindAnyObjectByType<SaudeOrganismo>();
        posicaoXInicial = transform.position.x; // Guarda o X inicial para usar como eixo do seno
    }

    void Update()
    {
        // Calcula a nova posição no eixo X usando a função Seno
        float novoX = posicaoXInicial + Mathf.Sin(Time.time * frequencia) * amplitude;
        
        // Aplica o movimento: X em zigue-zague, Y descendo
        transform.position = new Vector3(novoX, transform.position.y - (velocidade * Time.deltaTime), transform.position.z);

        if (transform.position.y < limiteTelaY)
        {
            if (scriptSaude != null)
                scriptSaude.TomarDano(danoAoOrganismo);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            if (scriptSaude != null)
                scriptSaude.TomarDano(6);

            // Busca o script de movimento no jogador colidido e aplica o efeito sticky
            MovimentoJogador scriptJogador = outro.GetComponent<MovimentoJogador>();
            if (scriptJogador != null)
            {
                scriptJogador.AplicarLentidao(2f);
            }

            Destroy(gameObject);
        }
    }
}