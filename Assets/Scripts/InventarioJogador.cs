using UnityEngine;

public class InventarioJogador : MonoBehaviour
{
    public int antigenosGuardados = 0;

    // Máximo de 3: limite de design para que o jogador precise ir à Zona de Entrega com frequência
    private const int limiteMaximo = 3;

    // Retorna false se o inventário já estiver cheio (antígeno coletado é descartado)
    public bool AdicionarAntigeno()
    {
        if (antigenosGuardados < limiteMaximo)
        {
            antigenosGuardados++;
            return true;
        }
        return false;
    }

    // Gasta 1 antígeno para habilidades (ex.: implantar Linfócito T)
    public bool ConsumirAntigeno()
    {
        if (antigenosGuardados > 0)
        {
            antigenosGuardados--;
            return true;
        }
        return false;
    }

    public void ZerarInventario()
    {
        antigenosGuardados = 0;
    }
}
