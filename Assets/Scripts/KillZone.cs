using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) // Solo destruye si tiene la etiqueta "Obstacle"
        {
            string objectName = other.gameObject.name;

            // Intentar destruir el objeto
            Destroy(other.gameObject);

            // Mensaje de depuración después de solicitar la destrucción
            Debug.Log($"Se elimino el objeto: {objectName}");
        }
    }

}