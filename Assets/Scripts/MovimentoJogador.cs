using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoJogador : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidade = 8f;

    [Header("Limites da Tela")]
    public float limiteX = 8.2f;
    public float limiteY = 4.5f;

    private float velocidadeOriginal;
    private bool sobEfeitoLentidao = false;

    void Start()
    {
        // Salva a velocidade original para restaurá-la depois
        velocidadeOriginal = velocidade;
    }

    void Update()
    {
        float movimentoHorizontal = 0f;
        float movimentoVertical = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                movimentoVertical = 1f;
            
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                movimentoVertical = -1f;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                movimentoHorizontal = -1f;

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                movimentoHorizontal = 1f;
        }

        Vector3 direcao = new Vector3(movimentoHorizontal, movimentoVertical, 0);
        transform.position += direcao * velocidade * Time.deltaTime;

        float posX = Mathf.Clamp(transform.position.x, -limiteX, limiteX);
        float posY = Mathf.Clamp(transform.position.y, -limiteY, limiteY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }

    // Método chamado pelo inimigo para aplicar a lentidão
    public void AplicarLentidao(float duracao)
    {
        if (!sobEfeitoLentidao)
        {
            StartCoroutine(EfeitoLentidaoCoroutine(duracao));
        }
    }

    private IEnumerator EfeitoLentidaoCoroutine(float duracao)
    {
        sobEfeitoLentidao = true;
        velocidade = velocidadeOriginal / 2f; // Reduz a velocidade pela metade
        
        yield return new WaitForSeconds(duracao); // Aguarda o tempo acabar
        
        velocidade = velocidadeOriginal; // Restaura a velocidade
        sobEfeitoLentidao = false;
    }
}