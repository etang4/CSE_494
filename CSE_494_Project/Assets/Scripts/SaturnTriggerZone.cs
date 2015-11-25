using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaturnTriggerZone : MonoBehaviour {

    public GameObject playerSpaceship;
    
    public GameObject DialogUI;
    public string CantEnterDialog;
    public string AskDialog;
    public GameObject Checkpoint;
    public bool CollectedAllMinerals;
    Text DialogText;
    Vector3 currentLocation;
    public bool isInTriggerZone;
    public GameObject NoDialogUI;
    Text NoDialogText;

    // Use this for initialization
    void Start () {
        DialogText = DialogUI.transform.GetChild(1).GetComponent<Text>();
        NoDialogText = NoDialogUI.transform.GetChild(1).GetComponent<Text>();
        currentLocation = playerSpaceship.transform.position;
        isInTriggerZone = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isInTriggerZone)
        {
            playerSpaceship.transform.position = currentLocation;
            if (PlayerPrefs.GetInt("hasMercurite") == 1 &&
                PlayerPrefs.GetInt("hasVenusite") == 1 &&
                PlayerPrefs.GetInt("hasEarthinite") == 1 &&
                PlayerPrefs.GetInt("hasMarsite") == 1 &&
                PlayerPrefs.GetInt("hasJupiterite") == 1)
            {
                DialogUI.SetActive(true);
            }
            else
            {
                NoDialogUI.SetActive(true);
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerSpaceship)
        {
            isInTriggerZone = true;
            currentLocation = playerSpaceship.transform.position;
            if (PlayerPrefs.GetInt("hasMercurite") == 1 &&
                PlayerPrefs.GetInt("hasVenusite") == 1 &&
                PlayerPrefs.GetInt("hasEarthinite") == 1 &&
                PlayerPrefs.GetInt("hasMarsite") == 1 &&
                PlayerPrefs.GetInt("hasJupiterite") == 1)
            {
                DialogText.text = AskDialog;
            }
            else
            {
                NoDialogText.text = CantEnterDialog;
            }
            PlayerPrefs.SetString("EnteringPlanet","Saturn");
        }
    }
}
