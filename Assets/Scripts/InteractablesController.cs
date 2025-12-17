using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractablesController : MonoBehaviour
{

    // constants / public vars
    const string text = "???: ";
    const string endText = "???: exit";
    public int orbsToCollect;

    // public references
    public GameObject winpad;
    public TextMeshProUGUI orbText;

    // variable initialisation

        // regular data
    int orbsCollected = 0;

    void Start()
    {

        // initialise orb text
        orbText.text = text + orbsCollected.ToString() + "/" + orbsToCollect.ToString();

    }

    // function fired by orbs when collected
    public void orbPickup()
    {

        orbsCollected++;

        // update text depending on if all orbs are collected, or in progress
        if (orbsCollected >= orbsToCollect)
        {
            orbText.text = endText;
            winpad.SetActive(true);
        }
        else
        {
            orbText.text = text + orbsCollected.ToString() + "/" + orbsToCollect.ToString();
        }

    }

}
