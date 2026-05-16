using UnityEngine;

public class ZonaDeResposta : MonoBehaviour
{
    private GerenciadorPontos gerenciadorPontos;

    void Start()
    {
        gerenciadorPontos = FindAnyObjectByType<GerenciadorPontos>();
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (!outro.CompareTag("Player")) return;

        // Busca pelo root para funcionar independente da hierarquia do jogador
        InventarioJogador inventario = outro.transform.root.GetComponentInChildren<InventarioJogador>();
        if (inventario == null || inventario.antigenosGuardados <= 0) return;
        if (gerenciadorPontos == null) return;

        // 7 pontos por antígeno entregue; zera o inventário para liberar espaço
        int pontos = inventario.antigenosGuardados * 7;
        gerenciadorPontos.AdicionarPontos(pontos);
        inventario.ZerarInventario();
    }
}
