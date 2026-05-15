using UnityEngine;

public class ZonaDeResposta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (!outro.CompareTag("Player")) return;

        InventarioJogador inventario = outro.GetComponent<InventarioJogador>();
        if (inventario == null || inventario.antigenosGuardados <= 0) return;

        int pontos = inventario.antigenosGuardados * 10;
        Object.FindAnyObjectByType<GerenciadorPontos>().AdicionarPontos(pontos);
        inventario.ZerarInventario();
    }
}
