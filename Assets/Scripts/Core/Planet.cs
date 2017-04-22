using UnityEngine;

[ExecuteInEditMode]
public class Planet : MonoBehaviour {
    [SerializeField]
    private float _radius;
    [SerializeField]
    private float _moveSpeed;

    private int moveDirection = 1;

    public float Radius {
        get { return _radius; }
        set { _radius = value; }
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
        moveDirection = Random.Range(0, 2) * 2 - 1;
    }

    private void FixedUpdate()
    {
        float currentZ = transform.position.z;
        float currentX = transform.position.x;
        float nextZ = currentZ + (moveDirection * _moveSpeed);
        float nextX = currentX + (moveDirection * _moveSpeed);

        transform.position = new Vector3(nextX,
                                         transform.position.y,
                                         nextZ);
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

#if UNITY_EDITOR

    private void Update() {
        if( Application.isPlaying ) {
            return;
        }

        var sphereColider = GetComponent<SphereCollider>();
        if( sphereColider ) {
            sphereColider.radius = Radius;
        }

        var model = transform.FindChild( "Model" );
        if( model ) {
            model.localScale = Vector3.one * Radius * 2;
        }

    }
#endif
}
