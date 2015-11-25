using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class EarthLevelScript : MonoBehaviour {

    public GameObject player;
    public GameObject DialogPanel;
    public GameObject QuestPanel;
    public GameObject QuestButton;
    public GameObject InfoPanel;
    public GameObject InfoButton;
    public string[] NPCTextPanels;
    public string[] textPanels;
    public string[] NPCCollectedMineraltextPanels;
    public string[] CollectedMineraltextPanels;
    public bool backOnEarth;
    Text textPanelText;
    Text NPCTalkingTitle;
    int sizeOfTextPanels;
    int currentPanel = 0;
    
	// Use this for initialization
	void Start () {
        textPanelText = DialogPanel.transform.GetChild(1).GetComponent<Text>();
        NPCTalkingTitle = DialogPanel.transform.GetChild(0).GetComponent<Text>();
        sizeOfTextPanels = textPanels.Length;
        PlayerPrefs.SetString("EnteringPlanet", "None");
    }
	
	// Update is called once per frame
	void Update () {
        if (backOnEarth)
        {
            textPanelText.text = textPanels[currentPanel];
            NPCTalkingTitle.text = NPCTextPanels[currentPanel];
        }
        else
        {
            if (PlayerPrefs.HasKey("hasEarthinite"))
            {
                textPanelText.text = CollectedMineraltextPanels[currentPanel];
                NPCTalkingTitle.text = NPCCollectedMineraltextPanels[currentPanel];
                //Finished second dialog
                if (currentPanel >= sizeOfTextPanels - 1)
                {
                    //Enable trigger for spaceship to load next level
                    player.GetComponent<QuestManager>().Spaceship.GetComponent<CapsuleCollider>().enabled = true;
                }
            }
            else
            {
                textPanelText.text = textPanels[currentPanel];
                NPCTalkingTitle.text = NPCTextPanels[currentPanel];
            }
        }
	}

    public void ClickedNextButton()
    {
        if(currentPanel < sizeOfTextPanels - 1)
        {
            currentPanel++;
        }
        else
        {
            if (backOnEarth)
            {
                //Fade out?
                Application.LoadLevel(0);
            }
            else
            {
                DialogPanel.gameObject.SetActive(false);
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<FirstPersonController>().enabled = true;
                sizeOfTextPanels = CollectedMineraltextPanels.Length;
                currentPanel = 0;
                //First time talking to Dr. Nelson
                if (!PlayerPrefs.HasKey("hasEarthinite"))
                {
                    GameObject.Find("Dexter").GetComponent<DexterAI>().canMove = true;
                    QuestPanel.gameObject.SetActive(true);
                    QuestButton.gameObject.SetActive(true);
                    InfoPanel.gameObject.SetActive(true);
                    InfoButton.gameObject.SetActive(true);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DialogPanel.gameObject.SetActive(true);
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
