using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    [SerializeField]
    AudioClip music;

    [SerializeField]
    float crossFadeTime = 5.0f;

    void Start() {
        AudioManager.PlayMusic( music, crossFadeTime );
    }
}
