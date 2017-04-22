using UnityEngine;
using UnityEngine.Events;

public class Planet : MonoBehaviour {
    [SerializeField]
    private float _radius;

    private UnityEvent onPlanetHit = new UnityEvent();

    public float Radius {
        get { return _radius; }
        set { _radius = value; }
    }

    public float Permieter {
        get { return 2 * Mathf.PI * Radius; }
    }
    

    private void OnCollisionEnter(Collision other) {
        onPlanetHit.Invoke();
    }

    public void AddHitListener(UnityAction call) {
        onPlanetHit.AddListener(call);
    }

    public void SampleOrbit2D( float angle,
                               float distance,
                               out Vector3 position,
                               out Vector3 normal ) {

        angle = angle * Mathf.Deg2Rad;

        // Polar to cartesian coordinates
        float x = Mathf.Cos( angle ) * distance;
        float y = Mathf.Sin( angle ) * distance;

        Vector3 dispalcement = new Vector3( x, 0, y );
        Vector3 center = transform.position;
        position = center + dispalcement;
        normal = dispalcement.normalized;
    }
}
