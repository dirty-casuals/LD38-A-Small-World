using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    [SerializeField]
    AudioClip music;

    [SerializeField]
    float volume = 1.0f;

    [SerializeField]
    float crossFadeTime = 5.0f;

    void Start() {
        AudioManager.PlayMusic( music, volume, crossFadeTime );
    }
}
