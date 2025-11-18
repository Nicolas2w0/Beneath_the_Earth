using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void goWin()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 0;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            goWin();
        }
    }
}
