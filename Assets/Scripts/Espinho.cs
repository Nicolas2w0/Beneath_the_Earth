using UnityEngine;

public class Espinho : MonoBehaviour
{
    public GameManager GameManager;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.LostLifes(1);
        }
    }
}
