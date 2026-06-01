using UnityEngine;

public class MovimentoAnticorpo : MonoBehaviour
{
    public float velocidade = 20f;
    public float limiteTelaY = 6f;
    
    // Variável para receber o efeito visual
    public GameObject prefabExplosao;

    void Update()
    {
        transform.position += Vector3.up * velocidade * Time.deltaTime;

        if (transform.position.y > limiteTelaY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Inimigo"))
        {
            // 1. Gera a explosão na exata posição do inimigo
            if (prefabExplosao != null)
            {
                Instantiate(prefabExplosao, outro.transform.position, Quaternion.identity);
            }

            // 2. Adiciona os pontos
            Object.FindFirstObjectByType<GerenciadorPontos>().AdicionarPontos(5);
            
            // 3. Destrói o inimigo e o anticorpo
            Destroy(outro.gameObject);
            Destroy(gameObject);
        }
    }
}