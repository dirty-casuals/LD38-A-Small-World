using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

    [SerializeField]
    private string _nextScene;

    // Update is called once per frame
    void Update() {
        if( Input.anyKey || Input.GetMouseButtonDown( 0 ) ) {
            LoadNextScene();
        }
    }

    private void LoadNextScene() {        
        SceneManager.LoadScene( _nextScene );
    }
}
