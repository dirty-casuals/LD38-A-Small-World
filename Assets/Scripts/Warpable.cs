using UnityEngine;

public class Warpable : MonoBehaviour {

    private Vector3 minPoint;
    private Vector3 maxPoint;

    void Start() {
        Ray minRay = Camera.main.ViewportPointToRay( new Vector3( 0, 0 ) );
        Ray maxRay = Camera.main.ViewportPointToRay( new Vector3( 1, 1 ) );
        Plane plane = new Plane( Vector3.up, 0 );

        minPoint = Vector3.one * float.NegativeInfinity;
        maxPoint = Vector3.one * float.PositiveInfinity;

        float minDist;
        float maxDist;
        if( plane.Raycast( minRay, out minDist ) ) {
            minPoint = minRay.GetPoint( minDist );
        }

        if( plane.Raycast( maxRay, out maxDist ) ) {
            maxPoint = maxRay.GetPoint( maxDist );
        }
    }

    private void Update() {
        Vector3 position = transform.position;
        if( position.x < minPoint.x ) {
            position.x = maxPoint.x;
        }

        if( position.x > maxPoint.x ) {
            position.x = minPoint.x;
        }

        if( position.z < minPoint.z ) {
            position.z = maxPoint.z;
        }

        if( position.z > maxPoint.z ) {
            position.z = minPoint.z;
        }

        transform.position = position;
    }
}
