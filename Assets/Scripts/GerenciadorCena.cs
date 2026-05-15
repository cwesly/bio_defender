using UnityEngine;
using UnityEngine.SceneManagement; // Essencial para trocar de cenas

public class GerenciadorCena : MonoBehaviour
{
    public void ReiniciarPartida()
    {
        // Reseta o tempo do jogo (caso tenha sido pausado)
        Time.timeScale = 1f;
        
        // Recarrega a cena que está aberta no momento
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrParaMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal"); // Nome da sua futura cena de menu
    }

    public void SairDoJogo()
    {
        Debug.Log("O jogador saiu do jogo.");
        Application.Quit();
    }
}