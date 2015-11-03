using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//General Manager of every planet quest
public class QuestManager : MonoBehaviour {

    public GameObject MineralInScene; //The rare mineral in this level
    public GameObject Dexter; //The dexter prefab in this level
    public GameObject Spaceship; //The spaceship in this level
    public GameObject[] beaconsInScene; //The beacons in this level
    public string[] InterestingFact; //Interesting fact corresponding to beacon[] index
    public GameObject NPCPanel;
    public GameObject QuestPanel;
    public GameObject InterestingFactPanel;
    public GameObject NPCZone;
    public int NextLevelIndexToLoad;

    //GUIText assigned at Start()
    Text NPCPanelText;
    Text QuestPanelText;
    Text InterestingFactPanelText;
    
    void Awake()
    {
        //NEEDED FOR DEBUGGING
        PlayerPrefs.DeleteAll();
    }
    // Use this for initialization
    void Start () {
        //Black Magic
        NPCPanelText = NPCPanel.transform.GetChild(1).GetComponent<Text>();
        QuestPanelText = QuestPanel.transform.GetChild(1).GetComponent<Text>();
        InterestingFactPanelText = InterestingFactPanel.transform.GetChild(1).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Called when the mineral in the scene is not found (aka extracted).
    void readyToLeavePlanet()
    {
        //enable trigger zone around plane.
    }

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < beaconsInScene.Length; i++){
            //Checks for beacon
            if (other.gameObject == beaconsInScene[i])
            {
                other.gameObject.SetActive(false);
                //Displays corresponding interesting fact
                InterestingFactPanelText.text = InterestingFact[i];
                InterestingFactPanel.SetActive(true);
                //Reduce the number of beacon remaining
                QuestPanelText.GetComponent<QuestDialog>().NumOfBeaconRemaining--;
                //Determine what text to display in quest objective.
                if (QuestPanelText.GetComponent<QuestDialog>().NumOfBeaconRemaining == 0)
                {
                    QuestPanelText.GetComponent<QuestDialog>().NeedToCollectMineral = true;
                    QuestPanelText.GetComponent<QuestDialog>().SearchingForBeacons = false;
                }
                break;
            }
        }

        //CHECKS FOR MINERALS
        //TODO: Needs the other planet's minerals
        if (other.gameObject.name == "Earthinite")
        {
            PlayerPrefs.SetInt("hasEarthinite", 1);
            other.gameObject.SetActive(false);
            QuestPanelText.GetComponent<QuestDialog>().NeedToCollectMineral = false;
            QuestPanelText.GetComponent<QuestDialog>().NeedToTalkToNPC = true;
            checkIfHasAllMinerals();
            //ONLY FOR EARTH to allow second talk with Dr. Nelson
            NPCZone.GetComponent<BoxCollider>().enabled = true;
        }

        if (other.gameObject == Spaceship)
        {
            Application.LoadLevel(NextLevelIndexToLoad);
        }
    }

    //Checks whether the player has all the minerals if so.
    //Pop a message up to fast-travel back to Earth.
    void checkIfHasAllMinerals()
    {
        //TODO: add all the minerals in this if statement.
        if (PlayerPrefs.HasKey("hasEarthinite"))
        {
            //prompt player if they want to return to earth.
        }
    }
}
