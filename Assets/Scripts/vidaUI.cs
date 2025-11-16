using UnityEngine;
using UnityEngine.UI;

public class VidaUI : MonoBehaviour
{
    public Image[] vidas; // arraste Vida1, Vida2, Vida3 aqui

    public void AtualizarVidas(int vidasRestantes)
    {
        vidasRestantes = Mathf.Clamp(vidasRestantes, 0, vidas.Length);

        for (int i = 0; i < vidas.Length; i++)
        {
            vidas[i].enabled = i < vidasRestantes;
        }
    }
}
