using UnityEngine;

public class Gato : MonoBehaviour
{
    [SerializeField] public NecesidadesBasicas basicNeeds;
    [SerializeField] private NecesidadesSecundarias secondaryNeeds;
    [SerializeField] private SistemaEmociones emotions;
    private Accion currentAction;

    private void Start() {
        if (basicNeeds == null || secondaryNeeds == null || emotions == null) {
            Debug.LogError("¡Asigna los componentes en el Inspector!");
            enabled = false; // Desactiva el script si falta algo
        }
    }

    private void Update() {
        emotions.UpdateEmotions(basicNeeds, secondaryNeeds);

        if (currentAction == null || currentAction.IsDone()) {
            currentAction = DecideNextAction();
            if (currentAction != null) {
                Debug.Log($"Nueva acción: {currentAction.name}");
            }
        }
        
        currentAction?.Execute();
    }

    private Accion DecideNextAction() {
        float basicPriority = basicNeeds.GetPriority();
        float secondaryPriority = secondaryNeeds.GetPriority();

        // Prioridad básica
        if (basicNeeds.hunger < 20f) return new Accion("Comer", 5f);
        if (basicNeeds.bladder < 15f) return new Accion("Ir al baño", 3f);
        if (basicNeeds.energy < 10f) return new Accion("Dormir", 10f);

        // Prioridad secundaria
        if (secondaryNeeds.affection < 30f) return new Accion("Buscar afecto", 4f);
        if (secondaryNeeds.play < 25f) return new Accion("Jugar", 6f);
        if (secondaryNeeds.territoryDefense < 20f) return new Accion("Defender territorio", 8f);

        // Emociones
        string emotion = emotions.GetDominantEmotion(secondaryNeeds);
        if (emotion == "Enojo") return new Accion("Gritar", 2f);
        if (emotion == "Tristeza") return new Accion("Llorar", 3f);

        return new Accion("Descansar", 1f);
    }
    public void MostrarEstado()
    {
    string emocion = emotions.GetDominantEmotion(secondaryNeeds);
    string estado = $"Estado actual:\n" +
                   $"Hambre: {basicNeeds.hunger:F1}\n" +
                   $"Baño: {basicNeeds.bladder:F1}\n" +
                   $"Energía: {basicNeeds.energy:F1}\n" +
                   $"Afecto: {secondaryNeeds.affection:F1}\n" +
                   $"Juego: {secondaryNeeds.play:F1}\n" +
                   $"Territorio: {secondaryNeeds.territoryDefense:F1}\n" +
                   $"Emoción: {emocion}";
    
    Debug.Log(estado);
    }

// Ejemplo de uso para satisfacer necesidades
public void Alimentar(float cantidad)
{
    basicNeeds.SatisfacerNecesidades(cantidad, 0, 0);
    MostrarEstado();
}
public void IrBanio(float cantidad)
{
    basicNeeds.SatisfacerNecesidades(0, cantidad, 0);
    MostrarEstado();
}
public void Dormir(float cantidad)
{
    basicNeeds.SatisfacerNecesidades(0, 0, cantidad);
    MostrarEstado();
}
public void Acariciar(float cantidad)
{
    secondaryNeeds.SatisfacerNecesidades(cantidad, 0, 0);
    MostrarEstado();
}
public void Jugar(float cantidad)
{
    secondaryNeeds.SatisfacerNecesidades(0,cantidad, 0);
    MostrarEstado();
}
public void Defender(float cantidad)
{
    secondaryNeeds.SatisfacerNecesidades(0,0,cantidad);
    MostrarEstado();
}

public string ObtenerEstadoComoTexto()
{
    string emocion = emotions.GetDominantEmotion(secondaryNeeds);
    return $"<b>Estado del Gato</b>\n" +
           $"🍗 Hambre: {basicNeeds.hunger:F1}\n" +
           $"🚽 Baño: {basicNeeds.bladder:F1}\n" +
           $"🛌 Energía: {basicNeeds.energy:F1}\n" +
           $"❤️ Afecto: {secondaryNeeds.affection:F1}\n" +
           $"🎾 Juego: {secondaryNeeds.play:F1}\n" +
           $"🛡️ Territorio: {secondaryNeeds.territoryDefense:F1}\n" +
           $"<color=#ff66ff>Emoción: {emocion}</color>";
}


}