using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public void LoadScene( string name ) {
        SceneManager.LoadScene( name );
    }
}
