using UnityEngine;

public class MovimentoAnticorpo : MonoBehaviour
{
    public float velocidade = 10f;
    public float limiteTelaY = 6f;

    void Update()
    {
        transform.position += Vector3.up * velocidade * Time.deltaTime;

        // Destrói o projétil ao sair da tela para não acumular objetos inativos
        if (transform.position.y > limiteTelaY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Inimigo"))
        {
            // +10 pontos por derrotar um vírus com anticorpo
            Object.FindAnyObjectByType<GerenciadorPontos>().AdicionarPontos(10);

            Destroy(outro.gameObject);
            Destroy(gameObject);
        }
    }
}
