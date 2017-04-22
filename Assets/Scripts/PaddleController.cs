using UnityEngine;

public class PaddleController : MonoBehaviour {
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Planet _planet;

    [SerializeField]
    private float _orbitAngle;

    [SerializeField]
    private float _orbitDistance;

    [SerializeField, Range( -1, 1 )]
    private float _direction = 0;

    public float Speed {
        get { return _speed; }
        set { _speed = value; }
    }

    public float Direction {
        get { return _direction; }
        set { _direction = Mathf.Clamp( value, -1, 1 ); }
    }

    public Planet Planet {
        get { return _planet; }
        set { _planet = value; }
    }

    public float OrbitAngle {
        get { return _orbitAngle; }
        private set { _orbitAngle = value; }
    }

    public float OrbitDistance {
        get { return _orbitDistance; }
        set { _orbitDistance = value; }
    }

    private void FixedUpdate() {

        float anglePerSecond = Speed / Planet.Permieter * Direction * Mathf.Rad2Deg;
        float deltaAngle = Time.fixedDeltaTime * anglePerSecond;

        OrbitAngle += deltaAngle;        

        Vector3 targetPosition, targetFacing;
        Planet.SampleOrbit2D( OrbitAngle * Mathf.Deg2Rad, OrbitDistance,
                              out targetPosition, out targetFacing );

        transform.forward = targetFacing;
        transform.position = targetPosition;
    }
}
