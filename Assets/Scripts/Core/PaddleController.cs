using System;
using UnityEngine;

[ExecuteInEditMode]
public class PaddleController : MonoBehaviour {
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Planet _planet;

    [SerializeField]
    private float _orbitDistance;

    [SerializeField]
    private float _orbitAngle;

    [SerializeField]
    private Vector2 _orbitArc;

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
        private set {
            _orbitAngle = Mathf.Repeat( value, 360 );
            _orbitAngle = ClampAngle( _orbitAngle, _orbitArc.x, _orbitArc.y );
        }
    }

    private static float ClampAngle( float angle, float min, float max ) {
        if( angle < 90 || angle > 270 ) {       // if angle in the critic region...
            if( angle > 180 ) angle -= 360;  // convert all angles to -180..+180
            if( max > 180 ) max -= 360;
            if( min > 180 ) min -= 360;
        }
        angle = Mathf.Clamp( angle, min, max );
        if( angle < 0 ) angle += 360;  // if angle negative, convert to 0..360
        return angle;
    }

    public float OrbitDistance {
        get { return _orbitDistance; }
        set { _orbitDistance = value; }
    }

    private void FixedUpdate() {

        float anglePerSecond = Speed / Planet.Perimeter * Direction * Mathf.Rad2Deg;
        float deltaAngle = Time.fixedDeltaTime * anglePerSecond;

        OrbitAngle += deltaAngle;

        UpdatePositionAndRotation();
    }

#if UNITY_EDITOR

    private void Update() {
        if( !Application.isPlaying ) {
            UpdatePositionAndRotation();
        }
    }

#endif

    private void UpdatePositionAndRotation() {
        if( !Planet ) {
            return;
        }

        Vector3 targetPosition, targetFacing;
        Planet.SampleOrbit2D( OrbitAngle * Mathf.Deg2Rad, OrbitDistance + Planet.Radius,
                              out targetPosition, out targetFacing );

        transform.forward = targetFacing;
        transform.position = targetPosition;
    }
}
