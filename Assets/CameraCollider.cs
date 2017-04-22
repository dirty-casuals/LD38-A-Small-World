using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Camera ) )]
public class CameraCollider : Collider {

    BoxCollider _upCollider;
    BoxCollider _downCollider;
    BoxCollider _leftCollider;
    BoxCollider _rightCollider;

    // Use this for initialization
    void Start() {
        var camera = GetComponent<Camera>();        
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes( camera );

        Transform leftPlane = GetOrAddPlane( "LeftPlane" );
        leftPlane.forward = planes[0].normal;
    }

    private Transform GetOrAddPlane( string name ) {
        Transform child = transform.FindChild( name );
        if( !child ) {
            GameObject obj = new GameObject( name );
            child = obj.transform;
            child.SetParent( transform );

        }

        var boxCollider = child.GetComponent<BoxCollider>();
        if( !boxCollider ) {
            boxCollider = child.gameObject.AddComponent<BoxCollider>();
        }

        return child;
    }

    // Update is called once per frame
    void Update() {

    }
}
