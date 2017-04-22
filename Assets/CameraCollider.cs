using UnityEngine;

[ExecuteInEditMode]
[RequireComponent( typeof( Camera ) )]
public class CameraCollider : MonoBehaviour {

    [SerializeField]
    private float _planeSize = 100;

    [SerializeField]
    private float _planeThickness = 1;


    void Start() {
        SetupCollisionPlanes();
    }

    private void SetupCollisionPlanes() {
        var camera = GetComponent<Camera>();
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes( camera );

        SetupCollisionPlane( planes[0], "_LeftPlane" );
        SetupCollisionPlane( planes[1], "_RightPlane" );
        SetupCollisionPlane( planes[2], "_DownPlane" );
        SetupCollisionPlane( planes[3], "_UpPlane" );
    }

    private void SetupCollisionPlane( Plane plane, string name ) {
        Transform planeTransform = GetOrAddPlane( name );
        planeTransform.forward = plane.normal;
        planeTransform.localPosition = Vector3.zero;
        planeTransform.localScale = new Vector3( _planeSize, _planeSize, _planeThickness );
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

        boxCollider.center = new Vector3( 0, -0.5f, -1 );

        return child;
    }

#if UNITY_EDITOR

    private void Update() {
        if( !Application.isPlaying ) {
            SetupCollisionPlanes();
        }
    }
#endif
}
