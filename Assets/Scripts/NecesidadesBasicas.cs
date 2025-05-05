using UnityEngine;
public class NecesidadesBasicas : MonoBehaviour
{
    public float hunger = 50f;    // 0 = muerto de hambre, 100 = lleno
    public float bladder = 50f;   // 0 = orinándose, 100 = aliviado
    public float energy = 50f;    // 0 = exhausto, 100 = descansado

    // Degrada necesidades con el tiempo
    private void Update() {
        hunger -= 0.1f * Time.deltaTime;
        bladder -= 0.05f * Time.deltaTime;
        energy -= 0.03f * Time.deltaTime;
    }

    // Calcula la prioridad (0 a 1) basada en urgencia
    public float GetPriority() 
    {
        float hungerPriority = 1 - (hunger / 100f); 
        float bladderPriority = 1 - (bladder / 100f);
        float energyPriority = 1 - (energy / 100f);
        
        // Orden de prioridad: Hambre > Baño > Energía
        return Mathf.Max(hungerPriority, bladderPriority * 0.7f, energyPriority * 0.5f);
    }
    public void SatisfacerNecesidades(float comida, float banio, float descanso) 
{
    hunger = Mathf.Clamp(hunger + comida, 0, 100);
    bladder = Mathf.Clamp(bladder + banio, 0, 100);
    energy = Mathf.Clamp(energy + descanso, 0, 100);
    
    Debug.Log($"Necesidades básicas satisfechas! Hambre: {hunger}, Baño: {bladder}, Energía: {energy}");
}
}
