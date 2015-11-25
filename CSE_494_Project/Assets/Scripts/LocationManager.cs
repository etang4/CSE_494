using UnityEngine;
using System.Collections;

public class LocationManager : MonoBehaviour {

    public GameObject playerSpaceship;
    public int PreviousLevelIndex;
    public GameObject[] planetCheckpoints; //Mercury - Neptune
    public GameObject DialogPanel;
    public GameObject FastTravelDialogPanel;
    public GameObject SpeedDialogPanel;
    Vector3 currentLocation;

    // Use this for initialization
    void Awake () {
        //DEBUG
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetString("EnteringPlanet", "None");
        //PlayerPrefs.SetInt("hasMercurite", 1);
        //PlayerPrefs.SetInt("hasVenusite", 1);
        //PlayerPrefs.SetInt("hasEarthinite", 1);
        //PlayerPrefs.SetInt("hasMarsite", 1);
        //PlayerPrefs.SetInt("hasJupiterite", 1);
        //PlayerPrefs.SetInt("hasSaturnite", 1);
        //PlayerPrefs.SetInt("hasUranusite", 1);
        //PlayerPrefs.SetInt("hasNeptunerite", 1);
    }

    void Start()
    {
        //Display Speed Dialog Once
        if (PlayerPrefs.GetString("EnteringPlanet") == "None")
        {
            SpeedDialogPanel.SetActive(true);
        }

        //Check if all the minerals are gathered. If so, ask if player wants to go to Earth.
        if (PlayerPrefs.GetInt("hasMercurite") == 1 &&
                PlayerPrefs.GetInt("hasVenusite") == 1 &&
                PlayerPrefs.GetInt("hasEarthinite") == 1 &&
                PlayerPrefs.GetInt("hasMarsite") == 1 &&
                PlayerPrefs.GetInt("hasJupiterite") == 1 &&
                PlayerPrefs.GetInt("hasSaturnite") == 1 &&
                PlayerPrefs.GetInt("hasUranusite") == 1 &&
                PlayerPrefs.GetInt("hasNeptunerite") == 1)
        {
            currentLocation = planetCheckpoints[7].transform.position;
            FastTravelDialogPanel.SetActive(true);
        }
            //Determine where to load the spacship
            if (PlayerPrefs.GetString("EnteringPlanet") == "Mercury")
        {
            playerSpaceship.transform.position = planetCheckpoints[0].transform.position;
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Venus")
        {
            playerSpaceship.transform.position = planetCheckpoints[1].transform.position;
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Earth")
        {
            playerSpaceship.transform.position = planetCheckpoints[2].transform.position;
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Mars")
        {
            playerSpaceship.transform.position = planetCheckpoints[3].transform.position;
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Jupiter")
        {
            playerSpaceship.transform.position = planetCheckpoints[4].transform.position;
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Saturn")
        {
            playerSpaceship.transform.position = planetCheckpoints[5].transform.position;
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Uranus")
        {
            playerSpaceship.transform.position = planetCheckpoints[6].transform.position;
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Neptune")
        {
            playerSpaceship.transform.position = planetCheckpoints[7].transform.position;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("hasMercurite") == 1 &&
                    PlayerPrefs.GetInt("hasVenusite") == 1 &&
                    PlayerPrefs.GetInt("hasEarthinite") == 1 &&
                    PlayerPrefs.GetInt("hasMarsite") == 1 &&
                    PlayerPrefs.GetInt("hasJupiterite") == 1 &&
                    PlayerPrefs.GetInt("hasSaturnite") == 1 &&
                    PlayerPrefs.GetInt("hasUranusite") == 1 &&
                    PlayerPrefs.GetInt("hasNeptunerite") == 1)
        {
            playerSpaceship.transform.position = currentLocation;
        }
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
        if (PlayerPrefs.GetString("EnteringPlanet") == "Uranus")
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
            GameObject planet = GameObject.Find("Mercury");
            planet.GetComponent<MercuryTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[0].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Venus")
        {
            GameObject planet = GameObject.Find("Venus");
            planet.GetComponent<VenusTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[1].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Earth")
        {
            GameObject planet = GameObject.Find("Earth");
            planet.GetComponent<EarthTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[2].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Mars")
        {
            GameObject planet = GameObject.Find("Mars");
            planet.GetComponent<MarsTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[3].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Jupiter")
        {
            GameObject planet = GameObject.Find("Jupiter");
            planet.GetComponent<JupiterTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[4].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Saturn")
        {
            GameObject planet = GameObject.Find("Saturn");
            planet.GetComponent<SaturnTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[5].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Uranus")
        {
            GameObject planet = GameObject.Find("Uranus");
            planet.GetComponent<UranusTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[6].transform.position;
            DialogPanel.SetActive(false);
        }
        if (PlayerPrefs.GetString("EnteringPlanet") == "Neptune")
        {
            GameObject planet = GameObject.Find("Neptune");
            planet.GetComponent<NeptuneTriggerZone>().isInTriggerZone = false;
            playerSpaceship.transform.position = planetCheckpoints[7].transform.position;
            DialogPanel.SetActive(false);
        }
    }

    public void FastTravelToEarth()
    {
        Application.LoadLevel(10);
    }
}
