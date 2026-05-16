using UnityEngine;
using TMPro;

public class GerenciadorPontos : MonoBehaviour
{
    public TextMeshProUGUI textoPontosUI;
    private int pontuacaoAtual = 0;

    void Start()
    {
        AtualizarInterface();
    }

    public void AdicionarPontos(int quantidade)
    {
        pontuacaoAtual += quantidade;
        AtualizarInterface();
    }

    void AtualizarInterface()
    {
        textoPontosUI.text = "Pontos: " + pontuacaoAtual;
    }
}
