using UnityEngine;
using UnityEngine.InputSystem; 

public class MovimentoJogador : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        float movimentoHorizontal = 0f;
        float movimentoVertical = 0f;

        // Verifica se o teclado existe antes de ler as teclas
        if (Keyboard.current != null)
        {
            // Movimento para cima (W ou Seta para Cima)
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                movimentoVertical = 1f;
            
            // Movimento para baixo (S ou Seta para Baixo)
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                movimentoVertical = -1f;

            // Movimento para esquerda (A ou Seta para Esquerda)
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                movimentoHorizontal = -1f;

            // Movimento para direita (D ou Seta para Direita)
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                movimentoHorizontal = 1f;
        }

        // Aplica a movimentação
        Vector3 direcao = new Vector3(movimentoHorizontal, movimentoVertical, 0);
        transform.position += direcao * velocidade * Time.deltaTime;
    }
}