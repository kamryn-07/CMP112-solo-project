using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinpadController : MonoBehaviour
{

    // constants
    const float WAIT_TIME = 0.25f;
    const string SCENE_NAME = "EndScene";

    // public references
    public AudioSource winSound;
    public GameObject blackscreen;

    // private references
    RawImage blackscreenImage;
    GameObject player;

    // variable initialisation

        // regular data
    bool isWin = false;

    void Start()
    {

        // initialise references
        player = GameObject.Find("Player");

        // initialise components
        blackscreenImage = blackscreen.GetComponent<RawImage>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        // make sure the player is colliding with the orb
        if (!(collision.gameObject == player) || isWin) return;

        isWin = true;

        // fire effects and scene switch
        winSound.Play();
        blackscreenImage.enabled = true;
        StartCoroutine(SwitchScene());

    }

    // function to switch scene after specified wait time
    private IEnumerator SwitchScene()
    {

        yield return new WaitForSeconds(WAIT_TIME);
        SceneManager.LoadScene(SCENE_NAME);

    }

}
