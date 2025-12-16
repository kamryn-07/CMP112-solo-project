using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    // constants / public vars
    float WAIT_TIME = 7.5f;
    string SCENE_NAME = "GameScene";
    public bool started = false;

    // public references
    public AudioSource startSound;
    public Canvas menuCanvas;
    public GameObject stage;

    // variable initialisation

        // objects/components
    InputAction enter;

    void Start()
    {

        // action initialisation
        enter = InputSystem.actions.FindAction("Enter");

    }

    void Update()
    {
        
        // check if enter is pressed and debounce is unactive, then begin game start sequence
        if (enter.IsPressed() && !started)
        {
            started = true;
            menuCanvas.enabled = false;
            stage.SetActive(false);
            startSound.Play();
            StartCoroutine(SwitchScene());
        }

    }

    // function to switch scene after specified wait time
    private IEnumerator SwitchScene()
    {

        yield return new WaitForSeconds(WAIT_TIME);
        SceneManager.LoadScene(SCENE_NAME);

    }

}
