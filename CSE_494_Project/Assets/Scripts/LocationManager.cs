using UnityEngine;
using System.Collections;

public class LocationManager : MonoBehaviour {

    public GameObject playerSpaceship;
    public int PreviousLevelIndex;
    public GameObject[] planetCheckpoints; //Mercury - Neptune
    public GameObject DialogPanel;

	// Use this for initialization
	void Awake () {
        PlayerPrefs.SetString("EnteringPlanet", "None");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnteringPlanet()
    {
        if (PlayerPrefs.GetString("EnteringPlanet") == "Mercury")
        {
            Application.LoadLevel(4); 
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Venus")
        {
            Application.LoadLevel(3); 
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Earth")
        {
            Application.LoadLevel(10); 
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Mars")
        {
            Application.LoadLevel(5); 
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Jupiter")
        {
            Application.LoadLevel(6);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Saturn")
        {
            Application.LoadLevel(7);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Urnaus")
        {
            Application.LoadLevel(8);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Neptune")
        {
            Application.LoadLevel(9);
        }
    }

    public void NotEnteringPlanet()
    {
        if (PlayerPrefs.GetString("EnteringPlanet") == "Mercury")
        {
            GameObject Earth = GameObject.Find("Mercury");
            Earth.GetComponent<MercuryTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[0].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Venus")
        {
            GameObject Earth = GameObject.Find("Venus");
            Earth.GetComponent<VenusTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[1].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Earth")
        {
            GameObject Earth = GameObject.Find("Earth");
            Earth.GetComponent<EarthTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[2].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Mars")
        {
            GameObject Earth = GameObject.Find("Mars");
            Earth.GetComponent<MarsTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[3].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Jupiter")
        {
            GameObject Earth = GameObject.Find("Jupiter");
            Earth.GetComponent<JupiterTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[4].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Saturn")
        {
            GameObject Earth = GameObject.Find("Saturn");
            Earth.GetComponent<SaturnTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[5].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Uranus")
        {
            GameObject Earth = GameObject.Find("Uranus");
            Earth.GetComponent<UranusTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[6].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Neptune")
        {
            GameObject Earth = GameObject.Find("Neptune");
            Earth.GetComponent<NeptuneTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[7].transform.position;
            DialogPanel.SetActive(false);
        }
    }
}
