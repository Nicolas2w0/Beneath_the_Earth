using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.15f;

    public bool useLimits = false;
    public float minX, maxX, minY, maxY;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, -10f);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        if (useLimits)
        {
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, minX, maxX);
            smoothPosition.y = Mathf.Clamp(smoothPosition.y, minY, maxY);
        }

        transform.position = smoothPosition;
    }
}