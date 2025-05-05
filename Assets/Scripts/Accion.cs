using UnityEngine;

public class Accion
{
    public string name;       // Nombre de la acción (ej. "Comer")
    public float duration;    // Duración en segundos
    public float elapsedTime; // Tiempo transcurrido
    public bool isDone;       // ¿La acción terminó?

    // Constructor
    public Accion(string name, float duration)
    {
        this.name = name;
        this.duration = duration;
        this.elapsedTime = 0f;
        this.isDone = false;
    }

    // Ejecuta la acción (llamar en cada frame)
    public void Execute()
    {
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= duration)
        {
            isDone = true;
            Debug.Log($"Acción completada: {name}");
        }
        else
        {
            Debug.Log($"Ejecutando: {name} ({elapsedTime:F1}/{duration:F1}s)");
        }
    }

    // Verifica si la acción terminó
    public bool IsDone()
    {
        return isDone;
    }
}
