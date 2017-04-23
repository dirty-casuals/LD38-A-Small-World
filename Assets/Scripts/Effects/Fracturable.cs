using System.Collections;
using UnityEngine;

public class Fracturable : MonoBehaviour {

    [SerializeField]
    private float _force = 100;

    [SerializeField]
    private GameObject _shards;

    [SerializeField]
    private float _shardLive = 5;

    [SerializeField]
    private AnimationCurve _scaleOverLifetime =
        new AnimationCurve( new Keyframe( 0, 1 ),
                            new Keyframe( 1, 0 ) );

    void OnDestroy() {
        Explode();
    }

    public void Explode() {
        var meshRenderer = GetComponent<MeshRenderer>();
        GameObject shards = Instantiate( _shards );
        Destroy( shards, _shardLive );
        shards.transform.position = transform.position;
        shards.transform.rotation = transform.rotation;
        shards.transform.localScale = transform.lossyScale;

        foreach( Transform child in shards.transform ) {
            var shardRenderer = child.GetComponent<MeshRenderer>();
            var shardRigidbody = child.GetComponent<Rigidbody>();
            var shardBehaviour = child.gameObject.AddComponent<ShardBehaviour>();

            if( !shardRigidbody ) {
                shardRigidbody = child.gameObject.AddComponent<Rigidbody>();
            }

            shardRenderer.sharedMaterials = meshRenderer.sharedMaterials;            
            shardRigidbody.AddExplosionForce( _force, shards.transform.position, 100 );
            shardBehaviour.Animate( _shardLive, _scaleOverLifetime );
        }
    }

    private class ShardBehaviour : MonoBehaviour {

        public void Animate( float duration, AnimationCurve scaleOverLifetime ) {
            StartCoroutine( ShardAnimation( duration, scaleOverLifetime ) );
        }

        private IEnumerator ShardAnimation( float duration, AnimationCurve scaleOverLifetime ) {
            float startTime = Time.time;
            float originalScale = transform.localScale.x;
            while( ( Time.time - startTime ) < duration ) {
                yield return null;

                float time = Time.time - startTime;
                float normalizedTime = time / duration;

                float scale = scaleOverLifetime.Evaluate( normalizedTime );
                transform.localScale = Vector3.one * scale * originalScale;
            }
        }
    }
}
