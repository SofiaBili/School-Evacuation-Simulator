using UnityEngine;

public class AudioPlay : MonoBehaviour{
    public AudioSource audioData;

    void OnEnable()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}