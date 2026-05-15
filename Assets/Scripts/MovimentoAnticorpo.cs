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

    // Essa função é ativada automaticamente quando o tiro encosta em outro colisor
    void OnTriggerEnter2D(Collider2D outro)
    {
        // Verifica se o objeto em que bateu tem a etiqueta "Inimigo"
        if (outro.CompareTag("Inimigo"))
        {
            // Destrói o objeto em que bateu (o Vírus)
            Destroy(outro.gameObject);
            
            // Destrói o próprio tiro (o Anticorpo)
            Destroy(gameObject);
        }
    }
}