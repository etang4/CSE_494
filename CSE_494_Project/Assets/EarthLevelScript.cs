using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class EarthLevelScript : MonoBehaviour {

    public GameObject player;
    public GameObject DialogPanel;
    public string[] textPanels;
    public string[] CollectedMineraltextPanels;
    Text textPanelText;
    int sizeOfTextPanels;
    int currentPanel = 0;
    
	// Use this for initialization
	void Start () {
        textPanelText = DialogPanel.transform.GetChild(1).GetComponent<Text>();
        sizeOfTextPanels = textPanels.Length;
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.HasKey("hasEarthinite"))
        {
            textPanelText.text = CollectedMineraltextPanels[currentPanel];
            //Finished second dialog
            if(currentPanel >= sizeOfTextPanels - 1)
            {
                //Enable trigger for spaceship to load next level
                player.GetComponent<QuestManager>().Spaceship.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
        else
        {
            textPanelText.text = textPanels[currentPanel];
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
            DialogPanel.gameObject.SetActive(false);
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<FirstPersonController>().enabled = true;
            sizeOfTextPanels = CollectedMineraltextPanels.Length;
            currentPanel = 0;
            GameObject.Find("Dexter").GetComponent<DexterAI>().canMove = true;
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
