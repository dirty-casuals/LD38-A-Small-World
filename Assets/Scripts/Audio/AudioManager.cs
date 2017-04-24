using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    private AudioSource musicSource1;

    [SerializeField]
    private AudioSource musicSource2;

    [SerializeField]
    private float crossFade = 0;

    private static AudioManager _instance;
    private static AudioManager instance {
        get {
            if( !_instance ) {
                _instance = FindObjectOfType<AudioManager>();
            }
            if( !_instance ) {
                var audioManagerObject = new GameObject();
                DontDestroyOnLoad( audioManagerObject );
                _instance = audioManagerObject.AddComponent<AudioManager>();
            }
            return _instance;
        }
    }

    void Awake() {
        if( !musicSource1 ) {
            musicSource1 = gameObject.AddComponent<AudioSource>();
        }

        if( !musicSource2 ) {
            musicSource2 = gameObject.AddComponent<AudioSource>();
        }

        musicSource1.loop = true;
        musicSource2.loop = true;
    }


    public static void PlayMusic( AudioClip clip, float fadeTime ) {
        instance.CrossFade( clip, fadeTime );
    }

    private void CrossFade( AudioClip clip, float duration ) {
        StartCoroutine( CrossFader( clip, duration ) );
    }

    private IEnumerator CrossFader( AudioClip clip, float duration ) {

        if( !musicSource1.isPlaying ) {
            musicSource1.clip = clip;
            musicSource1.Play();
            yield break;
        }

        if( musicSource1.clip == clip ) {
            yield break;
        }

        musicSource1.volume = 1;
        musicSource2.volume = 0;
        musicSource2.clip = clip;
        musicSource2.Play();

        for( float time = duration; time > 0; time -= Time.deltaTime ) {
            float fade = time / duration;
            musicSource1.volume = fade;
            musicSource2.volume = 1 - fade;
            yield return null;
        }

        AudioSource temp = musicSource1;
        musicSource1 = musicSource2;
        musicSource2 = temp;
        musicSource1.volume = 1;
        musicSource2.volume = 0;
        musicSource2.Stop();
    }

    // Update is called once per frame
    void Update() {

    }
}
