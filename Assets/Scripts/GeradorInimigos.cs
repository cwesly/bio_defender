using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject prefabVirus;
    public GameObject prefabAntigeno;
    public GameObject prefabBacteria;

    [Header("Configurações de Geração")]
    public float tempoDeEspera = 2f;    
    public float limiteX = 8.5f;        

    [Range(0f, 1f)]
    public float chanceDeAntigeno = 0.2f; // 20% de chance de ser um item positivo

    [Range(0f, 1f)]
    public float chanceDeBacteria = 0.3f; // 30% de chance de o inimigo ser uma Bactéria

    void Start()
    {
        InvokeRepeating("Gerar", 1f, tempoDeEspera);
    }

    void Gerar()
    {
        float posicaoXAleatoria = Random.Range(-limiteX, limiteX);
        Vector3 posicaoGeracao = new Vector3(posicaoXAleatoria, transform.position.y, 0);

        if (Random.value < chanceDeAntigeno)
        {
            // Gera um Antígeno
            Instantiate(prefabAntigeno, posicaoGeracao, Quaternion.identity);
        }
        else
        {
            // É um inimigo. Decide se é Bactéria ou Vírus
            if (Random.value < chanceDeBacteria)
            {
                Instantiate(prefabBacteria, posicaoGeracao, Quaternion.identity);
            }
            else
            {
                Instantiate(prefabVirus, posicaoGeracao, Quaternion.identity);
            }
        }
    }
}