using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoJogador : MonoBehaviour
{
    public float velocidade = 5f;

    // Variáveis para definir os limites da tela
    public float limiteX = 8.5f;
    public float limiteY = 4.5f;

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

        // Trava a posição do personagem nos eixos X e Y
        float posX = Mathf.Clamp(transform.position.x, -limiteX, limiteX);
        float posY = Mathf.Clamp(transform.position.y, -limiteY, limiteY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}