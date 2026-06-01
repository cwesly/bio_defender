using UnityEngine;

public class AutoDestruir : MonoBehaviour
{
    void Start()
    {
        // Destrói o objeto 1 segundo após ser instanciado
        Destroy(gameObject, 1f);
    }
}