using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    public float velocidade = 2f;
    public int pontosGanhos = 10;
    public int curaQuantidade = 5;

    void Update()
    {
        transform.position += Vector3.down * velocidade * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            Object.FindFirstObjectByType<GerenciadorPontos>().AdicionarPontos(pontosGanhos);
            Object.FindFirstObjectByType<SaudeOrganismo>().TomarDano(-curaQuantidade);

            Debug.Log("Antígeno coletado!");
            Destroy(gameObject);
        }
    }
}