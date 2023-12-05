using UnityEngine;

public class CycleJourNuit : MonoBehaviour
{
    public Light sunLight; // Référence à la lumière du soleil
    public float cycleDurationInSeconds = 60f; // Durée d'un cycle jour-nuit en secondes

    void Update()
    {
        float t = Mathf.PingPong(Time.time / cycleDurationInSeconds, 1f);
        float intensity = Mathf.Lerp(0.2f, 1.5f, t);
        sunLight.intensity = intensity;
    }
}