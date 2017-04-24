using UnityEngine;

public class AsteroidGenerator : MonoBehaviour {

    [SerializeField]
    private Planet asteroidPrefab;

    [SerializeField]
    int minAsteroids = 1;

    [SerializeField]
    int maxAsteroids = 3;

    [SerializeField]
    float minAsteroidRadius = 1;

    [SerializeField]
    float maxAsteroidRadius = 3;

    public void CreateAsteroids() {
        var myRenderer = GetComponentInChildren<MeshRenderer>();
        int numAsteroids = Random.Range( minAsteroids, maxAsteroids );
        for( int i = 0; i < numAsteroids; i++ ) {
            var asteroid = Instantiate<Planet>( asteroidPrefab );
            var displacement = new Vector3( Random.Range( -3, 3 ), 0, Random.Range( -3, 3 ) );
            asteroid.transform.position = transform.position + displacement;
            asteroid.transform.rotation = Quaternion.Euler( Random.Range( 0, 360 ), Random.Range( 0, 360 ), Random.Range( 0, 360 ) );
            asteroid.Radius = Random.Range( minAsteroidRadius, maxAsteroidRadius );

            var renderer = asteroid.GetComponentInChildren<MeshRenderer>();
            renderer.sharedMaterials = myRenderer.sharedMaterials;

            var rigidBody = asteroid.GetComponent<Rigidbody>();
            rigidBody.AddExplosionForce( Random.Range( 50, 500 ), transform.position, 100 );
        }
    }
}
