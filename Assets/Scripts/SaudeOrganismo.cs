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
        if (painelGameOver != null)
            painelGameOver.SetActive(true);

        // Usa a instância estática para evitar FindObjectOfType no momento crítico do game over
        if (HUDAntigenos.Instancia != null)
            HUDAntigenos.Instancia.gameObject.SetActive(false);

        // Pausa o jogo; GerenciadorCena.ReiniciarPartida() restaura para 1 ao reiniciar
        Time.timeScale = 0f;
    }

    void AtualizarInterface()
    {
        if (barraDeVidaUI != null) barraDeVidaUI.value = saudeAtual;
    }
}
