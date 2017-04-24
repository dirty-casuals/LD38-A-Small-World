using UnityEngine;

public class BallHitSFX : MonoBehaviour {

    [SerializeField]
    private AudioClip sfx;

    private void OnCollisionEnter( Collision collision ) {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if( ball ) {
            AudioManager.PlayEffect( sfx );
        }
    }
}
