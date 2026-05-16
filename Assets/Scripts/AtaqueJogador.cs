using UnityEngine;
using UnityEngine.InputSystem;

public class AtaqueJogador : MonoBehaviour
{
    public GameObject prefabAnticorpo;
    public GameObject linfocitoPrefab;

    void Update()
    {
        // Espaço: dispara um anticorpo sem custo
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Atirar();
        }

        // Q: implanta um Linfócito T, custa 1 antígeno do inventário
        // O limite de 7 instâncias evita sobrecarga de aliados em tela
        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            InventarioJogador inventario = GetComponent<InventarioJogador>();

            if (inventario != null && LinfocitoT.InstanciasAtivas < 7 && inventario.ConsumirAntigeno())
            {
                Instantiate(linfocitoPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    void Atirar()
    {
        Instantiate(prefabAnticorpo, transform.position, Quaternion.identity);
    }
}
