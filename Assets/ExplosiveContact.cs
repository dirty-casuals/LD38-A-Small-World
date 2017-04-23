using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveContact : MonoBehaviour {

    [SerializeField]
    private float _impactForce = 10f;

    private void OnCollisionEnter( Collision collision ) {
        if( collision.rigidbody ) {
            collision.rigidbody.AddForce( collision.impulse.normalized * _impactForce, ForceMode.Impulse );
        }
    }
}
