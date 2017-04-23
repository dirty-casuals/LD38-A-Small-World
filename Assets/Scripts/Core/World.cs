using UnityEngine;
using UnityEngine.Events;

public class World : Planet {

    private UnityEvent onPlanetHit = new UnityEvent();
    private Lives lives;

    private void Awake() {
        lives = GetComponent<Lives>();
    }

    private void OnCollisionEnter( Collision other ) {
        if( other.transform.GetComponent<Ball>() ) {
            onPlanetHit.Invoke();
        }
    }

    public void AddHitListener( UnityAction call ) {
        onPlanetHit.AddListener( call );
    }

    public void AddOutOfLivesListener( UnityAction<int, World> call ) {
        lives.AddOutOfLivesListener( call );
    }

    public void AddLivesChangedListener( UnityAction<int> call ) {
        lives.AddLivesChangedListener( call );
    }
}
