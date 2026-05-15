using UnityEngine;

public class InventarioJogador : MonoBehaviour
{
    public int antigenosGuardados = 0;
    private const int limiteMaximo = 3;

    public bool AdicionarAntigeno()
    {
        if (antigenosGuardados < limiteMaximo)
        {
            antigenosGuardados++;
            return true;
        }
        return false;
    }

    public void ZerarInventario()
    {
        antigenosGuardados = 0;
    }
}
