using UnityEngine;
using UnityEngine.UI;

public class HUDAntigenos : MonoBehaviour
{
    // Instância estática permite que SaudeOrganismo desative o HUD no game over
    // sem precisar de FindObjectOfType no momento crítico
    public static HUDAntigenos Instancia { get; private set; }

    [SerializeField] private InventarioJogador inventario;
    [SerializeField] private Image[] slots = new Image[3]; // Arraste os Fill_0, Fill_1, Fill_2 aqui

    private static readonly Color32 corCheia = new Color32(255, 214,  0, 255); // #FFD600
    private static readonly Color32 corVazia  = new Color32( 14,  42, 14, 255); // #0E2A0E

    void Awake()
    {
        Instancia = this;

        // Tenta encontrar automaticamente se não foi atribuído no Inspector
        if (inventario == null)
            inventario = FindAnyObjectByType<InventarioJogador>();

        for (int i = 0; i < slots.Length; i++)
            if (slots[i] == null)
                Debug.LogWarning($"[HUDAntigenos] Slot {i} não atribuído no Inspector.");
    }

    void Update()
    {
        if (inventario == null) return;

        // Atualiza a cor de cada slot conforme a quantidade de antígenos no inventário
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
                slots[i].color = i < inventario.antigenosGuardados ? corCheia : corVazia;
        }
    }
}
