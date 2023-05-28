using UnityEngine;

public class AudioStop : MonoBehaviour{
    public AudioSource audioData;

    void OnEnable()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Stop();
    }
}