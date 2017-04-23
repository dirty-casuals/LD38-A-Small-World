using UnityEngine;

[ExecuteInEditMode]
[RequireComponent( typeof( Camera ) )]
public class CameraCollider : MonoBehaviour {

    [SerializeField]
    private float _planeSize = 100;

    [SerializeField]
    private float _planeThickness = 1;

    [SerializeField]
    private bool _isTrigger;

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
        boxCollider.isTrigger = _isTrigger;

        var delegator = child.GetComponent<CollisionEventDelegator>();
        if( !delegator ) {
            delegator = child.gameObject.AddComponent<CollisionEventDelegator>();
        }

        delegator.DelegateObject = gameObject;

        return child;
    }

#if UNITY_EDITOR

    private void Update() {
        if( !Application.isPlaying ) {
            SetupCollisionPlanes();
        }
    }

#endif

    private class CollisionEventDelegator : MonoBehaviour {
        private GameObject _delegateObject;

        public GameObject DelegateObject {
            get { return _delegateObject; }
            set { _delegateObject = value; }
        }

        private void OnCollisionEnter( Collision collision ) {
            _delegateObject.SendMessage( "OnCollisionEnter",
                                         collision,
                                         SendMessageOptions.DontRequireReceiver );
        }

        private void OnCollisionExit( Collision collision ) {
            _delegateObject.SendMessage( "OnCollisionExit",
                                         collision,
                                         SendMessageOptions.DontRequireReceiver );
        }

        private void OnTriggerEnter( Collider collider ) {
            _delegateObject.SendMessage( "OnTriggerEnter",
                                         collider,
                                         SendMessageOptions.DontRequireReceiver );
        }

        private void OnTriggerExit( Collider collider ) {
            _delegateObject.SendMessage( "OnTriggerExit",
                                         collider,
                                         SendMessageOptions.DontRequireReceiver );
        }

        private void OnTriggerStay( Collider collider ) {
            _delegateObject.SendMessage( "OnTriggerStay",
                                         collider,
                                         SendMessageOptions.DontRequireReceiver );
        }
    }
}
