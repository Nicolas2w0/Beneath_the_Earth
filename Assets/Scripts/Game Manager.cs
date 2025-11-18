using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pontos = 0;
    public int vidas = 3;
    public TextMeshProUGUI textPontos;

    public VidaUI vidaUI;

    public void goMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0;
    }
    public void AddPoints(int qtd)
    {
        pontos = pontos + qtd;

        if (pontos <= 0)
        {
            pontos = 0;
        }

        textPontos.text = "Pontos: " + pontos;
    }

    public void LostLifes(int vida)
    {
        vidas = vidas - vida;

        if (vidaUI != null)
            vidaUI.AtualizarVidas(vidas);

        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().RestartPosition();

        if (vidas <= 0)
        {
            goMenu();
        }
    }
}