using UnityEngine;

public class Rotate : MonoBehaviour {

    [SerializeField]
    Vector3 _rotation;

    void Update() {
        transform.Rotate( _rotation * Time.deltaTime );
    }
}
