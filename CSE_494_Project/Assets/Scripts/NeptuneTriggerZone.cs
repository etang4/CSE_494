using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NeptuneTriggerZone : MonoBehaviour {

    public GameObject playerSpaceship;
    
    public GameObject DialogUI;
    public string CantEnterDialog;
    public string AskDialog;
    public GameObject Checkpoint;
    public bool CollectedAllMinerals;
    Text DialogText;
    Vector3 currentLocation;
    public bool isInTriggerZone;

	// Use this for initialization
	void Start () {
        DialogText = DialogUI.transform.GetChild(1).GetComponent<Text>();
        currentLocation = playerSpaceship.transform.position;
        isInTriggerZone = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isInTriggerZone)
        {
            playerSpaceship.transform.position = currentLocation;
            DialogUI.SetActive(true);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerSpaceship)
        {
            isInTriggerZone = true;
            currentLocation = playerSpaceship.transform.position;
            DialogText.text = AskDialog;
            PlayerPrefs.SetString("EnteringPlanet","Neptune");
        }
    }
}
