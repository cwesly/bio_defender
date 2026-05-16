using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    public float velocidade = 2f;

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
            InventarioJogador inventario = outro.GetComponent<InventarioJogador>();

            // AdicionarAntigeno retorna false se o inventário estiver cheio (limite 3);
            // nesse caso o item NÃO é destruído e continua na tela
            if (inventario != null && inventario.AdicionarAntigeno())
            {
                Destroy(gameObject);
            }
        }
    }
}
