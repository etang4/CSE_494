using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MercuryTriggerZone : MonoBehaviour {

    public GameObject playerSpaceship;
    
    public GameObject DialogUI;
    public GameObject NoDialogUI;
    public string CantEnterDialog;
    public string AskDialog;
    public GameObject Checkpoint;
    Text DialogText;
    Text NoDialogText;
    Vector3 currentLocation;
    public bool isInTriggerZone;

	// Use this for initialization
	void Start () {
        DialogText = DialogUI.transform.GetChild(1).GetComponent<Text>();
        NoDialogText = NoDialogUI.transform.GetChild(1).GetComponent<Text>();
        currentLocation = playerSpaceship.transform.position;
        isInTriggerZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTriggerZone)
        {
            playerSpaceship.transform.position = currentLocation;
            if (PlayerPrefs.GetInt("hasVenusite") == 1)
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
            if (PlayerPrefs.GetInt("hasVenusite") == 1)
            {
                DialogText.text = AskDialog;
            }
            else
            {
                NoDialogText.text = CantEnterDialog;
            }
            PlayerPrefs.SetString("EnteringPlanet","Mercury");
        }
    }
}
