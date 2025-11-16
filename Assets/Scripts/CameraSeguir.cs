using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.15f;

    // Limites opcionais (pode deixar desativado)
    public bool useLimits = false;
    public float minX, maxX, minY, maxY;

    void LateUpdate()
    {
        if (player == null) return;

        // Posição alvo (mantém o Z da câmera)
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, -10f);

        // Suavização
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Aplicar limites se estiver ligado
        if (useLimits)
        {
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, minX, maxX);
            smoothPosition.y = Mathf.Clamp(smoothPosition.y, minY, maxY);
        }

        // Mover a câmera
        transform.position = smoothPosition;
    }
}