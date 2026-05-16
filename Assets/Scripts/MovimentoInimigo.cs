using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public float velocidade = 3f;
    public float limiteTelaY = -6f;

    // Dano ao deixar o vírus passar pela tela inteira (penalidade maior por descuido)
    public int danoAoOrganismo = 10;

    private SaudeOrganismo scriptSaude;

    void Start()
    {
        scriptSaude = FindFirstObjectByType<SaudeOrganismo>();
    }

    void Update()
    {
        transform.position += Vector3.down * velocidade * Time.deltaTime;

        if (transform.position.y < limiteTelaY)
        {
            if (scriptSaude != null)
                scriptSaude.TomarDano(danoAoOrganismo);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        // Encostar no Macrófago causa dano menor (6) do que deixar passar (10)
        if (outro.CompareTag("Player"))
        {
            if (scriptSaude != null)
                scriptSaude.TomarDano(6);
            Destroy(gameObject);
        }
    }
}
