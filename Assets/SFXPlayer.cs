using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour {

    public void PlaySFX( AudioClip clip ) {
        AudioManager.PlayEffect( clip );
    }
}
