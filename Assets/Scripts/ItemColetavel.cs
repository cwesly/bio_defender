using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    public float velocidade = 2f;
    public int pontosGanhos = 10;

    void Update()
    {
        // Movimento de descida
        transform.position += Vector3.down * velocidade * Time.deltaTime;

        // Destrói se sair da tela por baixo
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        // Verifica se quem encostou foi o jogador
        if (outro.CompareTag("Player"))
        {
            Debug.Log("Antígeno coletado! +10 pontos.");
            
            // Destrói o item após a coleta
            Destroy(gameObject);
        }
    }
}