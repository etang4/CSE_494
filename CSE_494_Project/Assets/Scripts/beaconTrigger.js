#pragma strict
var beaconCount : int;
var text: UI.Text;
var textDisplay: String;


function Start () {

}

function Update () {

}

function OnTriggerEnter(col: Collider)
{
	if(col.gameObject.tag == "Player")
	{
	col.gameObject.SendMessage("BeaconPickup");
		text.text = textDisplay;
	}
}

function OnTriggerExit(col: Collider)
{
	Destroy(gameObject);
	text.text = "";	
}