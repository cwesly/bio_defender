using UnityEngine;
using UnityEngine.UI; // ESSENCIAL: Permite controlar elementos de interface

public class SaudeOrganismo : MonoBehaviour
{
    public int saudeMaxima = 100;
    public int saudeAtual;

    // Referência para o componente Slider da tela
    public Slider barraDeVidaUI;

    void Start()
    {
        saudeAtual = saudeMaxima;
        AtualizarInterface();
    }

    public void TomarDano(int quantidade)
    {
        saudeAtual -= quantidade;
        
        // Garante que a vida nunca fique menor que 0 ou maior que o máximo
        saudeAtual = Mathf.Clamp(saudeAtual, 0, saudeMaxima);
        
        AtualizarInterface();

        if (saudeAtual <= 0)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0; // Pausa o jogo
        }
    }

    void AtualizarInterface()
    {
        // Se a barra foi arrastada para o script, atualiza o valor dela
        if (barraDeVidaUI != null)
        {
            barraDeVidaUI.value = saudeAtual;
        }
    }
}