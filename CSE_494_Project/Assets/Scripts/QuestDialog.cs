using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestDialog : MonoBehaviour {

    public bool SearchingForBeacons;
    public bool NeedToTalkToNPC;
    public bool NeedToCollectMineral;
    public int NumOfBeaconRemaining;
    public string BeaconSuffix;
    public string NPCToTalkTo;
    public string MineralSuffix;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //booleans are updated outside this script under quest manager
        if (SearchingForBeacons)
        {
            this.GetComponent<Text>().text = "You have " + NumOfBeaconRemaining + " " + BeaconSuffix;
        }
        else if (NeedToCollectMineral)
        {
            this.GetComponent<Text>().text = MineralSuffix;
        }
        //Also the same text for leaving the planet
        else if (NeedToTalkToNPC)
        {
            this.GetComponent<Text>().text = NPCToTalkTo;
        }
        else
        {
            //Do nothing.
        }
	}
}
