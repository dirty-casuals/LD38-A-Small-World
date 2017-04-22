using UnityEngine;

public class CollisionForce : MonoBehaviour {

    [SerializeField]
    private float _additionalForce = 1;

    [SerializeField]
    private float _proportionalForce = 0;

    private void OnCollisionEnter( Collision collision ) {
        var rigidBody = GetComponent<Rigidbody>();
        if( rigidBody ) {

            Vector3 force = collision.impulse;
            Vector3 forceDirection = force.normalized;            
            float addedForce = _additionalForce + _proportionalForce * force.magnitude;

            rigidBody.AddForce( forceDirection * addedForce );
        }        
    }
}
