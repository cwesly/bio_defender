using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorCena : MonoBehaviour
{
    public void ReiniciarPartida()
    {
        // Restaura o tempo antes de recarregar; sem isso a cena recarrega pausada
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
