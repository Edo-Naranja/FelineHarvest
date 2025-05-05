using UnityEngine;

public class SistemaEmociones : MonoBehaviour
{
    public float valence = 0f; // -1 (negativo) a +1 (positivo)
    public float arousal = 0.5f; // 0 (calmado) a 1 (excitado)

    public void UpdateEmotions(NecesidadesBasicas basic, NecesidadesSecundarias secondary)
    {
        // Valencia: Combinación de necesidades y eventos
        valence = Mathf.Clamp(
            (basic.hunger / 100f - 0.5f) + 
            (secondary.affection / 100f - 0.5f), 
            -1f, 1f
        );

        // Activación: Más alta si hay amenazas o necesidades urgentes
        arousal = Mathf.Clamp(
            (1 - basic.energy / 100f) + 
            (1 - secondary.territoryDefense / 100f) * 0.5f, 
            0f, 1f
        );
    }

    public string GetDominantEmotion(NecesidadesSecundarias secondary)
    {
        if (valence > 0.7f) return "Alegría";
        if (valence < -0.5f && arousal > 0.6f) return "Enojo";
        if (valence < -0.3f && arousal < 0.4f) return "Tristeza";
        if (arousal > 0.7f && valence < 0f) return "Ansiedad";
        if (secondary.territoryDefense < 20f) return "Miedo";
        return "Neutral";
    }
    
}
