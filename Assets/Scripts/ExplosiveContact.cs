using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveContact : MonoBehaviour {

    [SerializeField]
    private float _impactForce = 10f;

    private void OnCollisionEnter( Collision collision ) {
        if( collision.rigidbody ) {
            Vector3 forceDirection = collision.transform.position - transform.position;
            forceDirection.Normalize();

            collision.rigidbody.AddForce( forceDirection * _impactForce, ForceMode.Impulse );
        }
    }
}
