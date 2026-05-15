using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject prefabVirus;
    public GameObject prefabAntigeno;

    [Header("Configurações de Geração")]
    public float tempoDeEspera = 2f;    // Intervalo em segundos
    public float limiteX = 8.5f;        // Largura da tela para o sorteio

    [Range(0f, 1f)]
    public float chanceDeAntigeno = 0.2f; // 0.2 significa 20% de chance

    void Start()
    {
        // Inicia a geração repetitiva
        InvokeRepeating("Gerar", 1f, tempoDeEspera);
    }

    void Gerar()
    {
        // 1. Sorteia a posição X dentro do limite definido
        float posicaoXAleatoria = Random.Range(-limiteX, limiteX);
        Vector3 posicaoGeracao = new Vector3(posicaoXAleatoria, transform.position.y, 0);

        // 2. Decide o que gerar com base na probabilidade
        // Random.value retorna um número entre 0.0 e 1.0
        if (Random.value < chanceDeAntigeno)
        {
            // Gera um Antígeno (item positivo)
            Instantiate(prefabAntigeno, posicaoGeracao, Quaternion.identity);
        }
        else
        {
            // Gera um Vírus (inimigo)
            Instantiate(prefabVirus, posicaoGeracao, Quaternion.identity);
        }
    }
}