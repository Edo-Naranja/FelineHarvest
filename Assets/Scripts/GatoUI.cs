using UnityEngine;
using TMPro;

public class GatoUI : MonoBehaviour 
{
    [SerializeField] private Gato gato;
    [SerializeField] private TextMeshProUGUI estadoTexto;

    
    void Update()
    {
        estadoTexto.text = gato.ObtenerEstadoComoTexto();
    }
    public void Alimentar()
    {
        // Ejemplo desde otro script
        gato.Alimentar(30f); // Aumenta hambre en 30
    }
    public void Banio()
    {
        // Ejemplo desde otro script
        gato.IrBanio(30f); // Aumenta hambre en 30
    }
    public void Dormir()
    {
        // Ejemplo desde otro script
        gato.Dormir(30f); // Aumenta hambre en 30
    }
    public void Acariciar()
    {
        gato.Acariciar(30f);
    }
    public void Jugar()
    {
        gato.Jugar(30f);
    }
    public void Defender()
    {
        gato.Defender(30f);
    }
}