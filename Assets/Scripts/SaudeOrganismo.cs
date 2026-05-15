using UnityEngine;
using UnityEngine.UI;

public class SaudeOrganismo : MonoBehaviour
{
    public int saudeMaxima = 100;
    public int saudeAtual;
    public Slider barraDeVidaUI;
    
    public GameObject painelGameOver;

    void Start()
    {
        saudeAtual = saudeMaxima;
        AtualizarInterface();
    }

    public void TomarDano(int quantidade)
    {
        saudeAtual -= quantidade;
        saudeAtual = Mathf.Clamp(saudeAtual, 0, saudeMaxima);
        AtualizarInterface();

        if (saudeAtual <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Ativa o painel de Game Over
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);
        }

        // Pausa o jogo
        Time.timeScale = 0f;
    }

    void AtualizarInterface()
    {
        if (barraDeVidaUI != null) barraDeVidaUI.value = saudeAtual;
    }
}