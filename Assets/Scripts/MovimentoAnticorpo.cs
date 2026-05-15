using UnityEngine;

public class MovimentoAnticorpo : MonoBehaviour
{
    public float velocidade = 10f;
    public float limiteTelaY = 6f;

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
            Object.FindAnyObjectByType<GerenciadorPontos>().AdicionarPontos(5);
            
            Destroy(outro.gameObject);
            Destroy(gameObject);
        }
    }
}