using UnityEngine;
using UnityEngine.InputSystem;

public class AtaqueJogador : MonoBehaviour
{
    // Variável para guardar o molde do tiro
    public GameObject prefabAnticorpo;

    void Update()
    {
        // Verifica se o teclado existe e se a barra de espaço foi apertada nesta exata frame
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Atirar();
        }
    }

    void Atirar()
    {
        // Cria uma cópia do prefab na exata posição do Macrófago
        Instantiate(prefabAnticorpo, transform.position, Quaternion.identity);
    }
}