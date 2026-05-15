using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoJogador : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidade = 8f; // Aumentei um pouco para melhorar o "feel" do jogo

    [Header("Limites da Tela")]
    public float limiteX = 8.2f;
    public float limiteY = 4.5f;

    void Update()
    {
        float movimentoHorizontal = 0f;
        float movimentoVertical = 0f;

        // Verifica se há um teclado conectado
        if (Keyboard.current != null)
        {
            // Movimentação Vertical (W / S / Setas)
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                movimentoVertical = 1f;
            
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                movimentoVertical = -1f;

            // Movimentação Horizontal (A / D / Setas)
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                movimentoHorizontal = -1f;

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                movimentoHorizontal = 1f;
        }

        // Aplica o movimento
        Vector3 direcao = new Vector3(movimentoHorizontal, movimentoVertical, 0);
        transform.position += direcao * velocidade * Time.deltaTime;

        // Trava a posição do personagem nos eixos X e Y para ele não sair da visão da câmera
        float posX = Mathf.Clamp(transform.position.x, -limiteX, limiteX);
        float posY = Mathf.Clamp(transform.position.y, -limiteY, limiteY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}