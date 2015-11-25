using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceshipSpeed : MonoBehaviour {
    public float speed;
    float speedOfLight;
    float velocity;
    float distanceFromEarth;
    Vector3 currentPosition;
    Vector3 PreviousPosition;
    public GameObject InfoPanel;
    GameObject EarthPrefab;
    Text InfoPanelText;

	// Use this for initialization
	void Start () {
        currentPosition = this.gameObject.transform.position;
        PreviousPosition = currentPosition;
        InfoPanelText = InfoPanel.transform.GetChild(1).GetComponent<Text>();
        EarthPrefab = GameObject.Find("Earth");
    }
	
	// Update is called once per frame
	void Update () {
        //Calculate Distance in miles
        distanceFromEarth = Vector3.Distance(this.gameObject.transform.position, EarthPrefab.transform.position);
        distanceFromEarth *= 9.947f * 0.621f;
        //calculate million miles per hour
        speed = Mathf.Round(this.gameObject.GetComponent<Rigidbody>().velocity.magnitude * .0099470f * 3600f * 0.621f);
        speedOfLight = Mathf.Round(speed / 671f * 10f) / 10f;
        InfoPanelText.text = "Distance from Earth: " + distanceFromEarth + " thousand miles away\nSpeed: " + speed + " million miles per hour\n" + speedOfLight + "x of the speed of light";
    }
}
