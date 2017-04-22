using UnityEngine;
using UnityEngine.Events;

public class World : Planet {

    private UnityEvent onPlanetHit = new UnityEvent();

    private void OnCollisionEnter(Collision other) {
        onPlanetHit.Invoke();
    }

    public void AddHitListener(UnityAction call) {
        onPlanetHit.AddListener(call);
    }
}
