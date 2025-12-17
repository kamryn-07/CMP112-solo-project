using UnityEngine;
using UnityEngine.InputSystem;

public class OrbController : MonoBehaviour
{

    // public references
    public AudioSource collectSound;
    public ParticleSystem collectParticles;
    public GameObject orb;

    // private references
    GameObject interactablesManager;
    GameObject player;
    InteractablesController interactablesController;

    // variable initialisation

        // objects/components
    MeshRenderer orbMeshRenderer;

        // regular data
    float timeElapsed = 0f;
    bool isCollected = false;

    void Start()
    {

        // reference initialisation
        interactablesManager = GameObject.Find("InteractablesManager");
        player = GameObject.Find("Player");

        // component initialisation
        orbMeshRenderer = orb.GetComponent<MeshRenderer>();
        interactablesController = interactablesManager.GetComponent<InteractablesController>();

    }

    void Update()
    {

        if (!isCollected)
        {
            // move the orb up and down slowly, scaled with deltatime
            transform.position += new Vector3(0, Mathf.Sin(timeElapsed) / 500f, 0);
        }
        else
        {
            // move orb up until out of view, then destroy
            transform.position += new Vector3(0, timeElapsed / 100f, 0);
            if (transform.position.y > 1000f)
            {
                Destroy(orb);
            }
        }

        timeElapsed += Time.deltaTime;

    }
    private void OnCollisionEnter(Collision collision)
    {

        // make sure the player is colliding with the orb
        if (!(collision.gameObject == player)) return;

        // make sure the orb may only be collected once
        if (isCollected) return;
        isCollected = true;

        // fire particles/sounds and other effects on collection
        collectParticles.Play();
        collectSound.Play();
        orbMeshRenderer.enabled = false;
        interactablesController.orbPickup();

    }

}
