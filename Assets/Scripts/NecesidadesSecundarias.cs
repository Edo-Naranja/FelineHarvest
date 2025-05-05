using UnityEngine;

public class NecesidadesSecundarias : MonoBehaviour
{
    public float affection = 70f;     // 0 = deprimido, 100 = amado
    public float play = 60f;          // 0 = aburrido, 100 = divertido
    public float territoryDefense = 30f; // 0 = invadido, 100 = seguro

    private void Update()
     {
        affection -= 0.02f * Time.deltaTime;
        play -= 0.04f * Time.deltaTime;
        territoryDefense -= 0.01f * Time.deltaTime;
    }

    public float GetPriority() {
        float affectionPriority = 1 - (affection / 100f);
        float playPriority = 1 - (play / 100f);
        float territoryPriority = 1 - (territoryDefense / 100f);
        
        // Afecto > Jugar > Defender territorio (pero con pesos menores que necesidades básicas)
        return Mathf.Max(affectionPriority * 0.6f, playPriority * 0.4f, territoryPriority * 0.3f);
    }
    public void SatisfacerNecesidades(float afecto, float diversion, float seguridad)
{
    affection = Mathf.Clamp(affection + afecto, 0, 100);
    play = Mathf.Clamp(play + diversion, 0, 100);
    territoryDefense = Mathf.Clamp(territoryDefense + seguridad, 0, 100);
    
    Debug.Log($"Necesidades secundarias satisfechas! Afecto: {affection}, Juego: {play}, Territorio: {territoryDefense}");
}
}