using UnityEngine;

[ExecuteInEditMode]
public class Planet : MonoBehaviour {
    [SerializeField]
    private float _radius;
    [SerializeField]
    private float _moveSpeed;

    private Vector3 moveDirection = Vector3.zero;

    public float Radius {
        get { return _radius; }
        set {
            _radius = value;
            UpdateDependentComponents();
        }
    }

    public float MoveSpeed {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    public float Perimeter {
        get { return 2 * Mathf.PI * Radius; }
    }

    public float Volume {
        get { return 4 / 3 * Mathf.PI * Radius * Radius * Radius; }
    }

    private void Start() {
        moveDirection = new Vector3( Random.Range( -1, 1 ), 0, Random.Range( -1, 1 ) );
        moveDirection.Normalize();

        Rigidbody rigidBody = GetComponent<Rigidbody>();
        if( rigidBody ) {
            rigidBody.AddForce( moveDirection * MoveSpeed, ForceMode.Impulse );
        }
    }

    public void SampleOrbit2D( float angle,
                               float distance,
                               out Vector3 position,
                               out Vector3 normal ) {

        // Polar to cartesian coordinates
        float x = Mathf.Cos( angle ) * distance;
        float y = Mathf.Sin( angle ) * distance;

        Vector3 displacement = new Vector3( x, 0, y );
        Vector3 center = transform.position;
        position = center + displacement;
        normal = displacement.normalized;
    }

    private void UpdateDependentComponents() {
        var sphereColider = GetComponent<SphereCollider>();
        if( sphereColider ) {
            sphereColider.radius = Radius;
        }

        var model = transform.FindChild( "Model" );
        if( model ) {
            model.localScale = Vector3.one * Radius * 2;
        }
    }

#if UNITY_EDITOR

    private void Update() {
        if( Application.isPlaying ) {
            return;
        }

        UpdateDependentComponents();
    }
#endif
}
