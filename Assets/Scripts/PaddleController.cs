using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Planet _planet;

    [SerializeField]
    private float _orbitAngle;

    [SerializeField]
    private float _orbitDistance;

    public enum MoveDirection
    {
        Left = -1,
        None = 0,        
        Right = 1,
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public MoveDirection Direction
    {
        get; set;
    }

    public Planet Planet
    {
        get { return _planet; }
        set { _planet = value; }
    }

    public float OrbitAngle
    {
        get { return _orbitAngle; }
        private set { _orbitAngle = value; }
    }

    public float OrbitDistance
    {
        get { return _orbitDistance; }
        set { _orbitDistance = value; }
    }

    private void FixedUpdate()
    {
        int direction = (int) Direction;
        float anglePerSecond = Speed / Planet.Permieter * direction;
        float deltaAngle = Time.fixedDeltaTime * anglePerSecond;

        OrbitAngle += deltaAngle;

        Vector3 targetPosition, targetFacing;
        Planet.SampleOrbit2D( OrbitAngle, OrbitDistance, 
                              out targetPosition, out targetFacing );

        transform.forward = targetFacing;
        transform.position = targetPosition;
    }
}
