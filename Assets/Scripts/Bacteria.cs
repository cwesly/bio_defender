using UnityEngine;

public class Bacteria : MonoBehaviour
{
    public int pontosDeVida = 2;
    public float velocidade = 2f;
    public float limiteTelaY = -6f;
    public int danoAoOrganismo = 15;

    private SaudeOrganismo scriptSaude;

    void Start()
    {
        scriptSaude = FindAnyObjectByType<SaudeOrganismo>();
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
        if (outro.CompareTag("Anticorpo")) 
        {
            pontosDeVida--;
            Destroy(outro.gameObject); // Destrói o projétil

            if (pontosDeVida <= 0)
            {
                Destroy(gameObject); // Destrói a bactéria
            }
        }
        else if (outro.CompareTag("Player"))
        {
            if (scriptSaude != null)
                scriptSaude.TomarDano(10);
            Destroy(gameObject);
        }
    }
}