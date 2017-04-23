using System;
using UnityEngine;

[RequireComponent( typeof( SphereCollider ) )]
public class GravitationalPull : MonoBehaviour {

    [SerializeField]
    private float _gravity = 0.1f;

    [SerializeField]
    private LayerMask _affectedLayers;

    private Planet _planet;
    private SphereCollider _spehereCollider;

    public float Gravity {
        get { return _gravity; }
        set { _gravity = value; }
    }

    private Planet Planet {
        get {
            if( !_planet ) {
                _planet = GetComponentInParent<Planet>();
            }
            return _planet;
        }
    }

    private SphereCollider SphereCollider {
        get {
            if( !_spehereCollider ) {
                _spehereCollider = GetComponent<SphereCollider>();
            }
            return _spehereCollider;
        }
    }

    private void OnTriggerStay( Collider other ) {

        if( !other.attachedRigidbody ) {
            return;
        }

        Vector3 center = transform.position;
        float force = -Gravity;
        float radius = SphereCollider.radius;

        if( Planet ) {
            center = Planet.transform.position;
            force = -Planet.Volume * Gravity;
        }

        int objLayer = other.attachedRigidbody.gameObject.layer;
        bool isAffected = IsAffectedLayer( objLayer );
        if( isAffected ) {
            other.attachedRigidbody.AddExplosionForce( force, Planet.transform.position, radius );
        }
    }

    private bool IsAffectedLayer( int objLayer ) {
        return _affectedLayers == ( _affectedLayers | ( 1 << objLayer ) );
    }
}
