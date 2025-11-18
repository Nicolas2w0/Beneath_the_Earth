using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager GameManager;
    private int coin = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coin++;
            GameManager.AddPoints(10);
            Destroy(gameObject);
            PlayerAudio som = collision.GetComponent<PlayerAudio>();
            som.PlaySFX(som.coinSound);
        }
    }
}
