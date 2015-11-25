using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceshipObjective : MonoBehaviour {

    public Text objectiveText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("hasNeptunerite") == 1)
        {
            objectiveText.text = "We got all the rare minerals! Let's head back to Earth";
        }
        else if (PlayerPrefs.GetInt("hasUranusite") == 1)
        {
            objectiveText.text = "You think this was far? Time to head to Neptune, the last planet in the solar system";
        }
        else if (PlayerPrefs.GetInt("hasSaturnite") == 1)
        {
            objectiveText.text = "Time to head to the ice planets. Let's go to Uranus first!";
        }
        else if (PlayerPrefs.GetInt("hasJupiterite") == 1)
        {
            objectiveText.text = "Let's head off to beautiful Saturn, the sixth planet in our solar system";
        }
        else if (PlayerPrefs.GetInt("hasMarsite") == 1)
        {
            objectiveText.text = "Let's head to the largest planet in the solar system, Jupiter";
        }
        else if (PlayerPrefs.GetInt("hasMercurite") == 1)
        {
            objectiveText.text = "Let's head to Mars the fourth planet in our solar system. It's behind Earth!";
        }
        else if (PlayerPrefs.GetInt("hasVenusite") == 1)
        {
            objectiveText.text = "Let's head to Mercury, the closest planet to the sun!";
        }
        else// if (PlayerPrefs.GetInt("hasEarth") == 1)
        {
            objectiveText.text = "Let's head to Venus, the closest planet to Earth! It's the second planet in the solar system";
        }
    }
}
