﻿#pragma strict

var Text : UI.Text;
var textDisplay: String;
//var mineral: GameObject;

private var range: float = 10.0f;

private var t : Transform;
private var player:  Transform;
private var minFlag: boolean = false;

function Awake()
{
	t = this.transform;
	player = GameObject.FindGameObjectWithTag ("Player").transform;
}
	

function OnMouseDown ()
{
	if (Distance () <= 10) {
		if(beaconInventory.beaconCount == 3)
		{
			Destroy (gameObject); 
			minFlag = true;
			Text.text = textDisplay;
			Text.enabled = false;		
		}
	}
}

function Distance()
{
	return Vector3.Distance (t.position, player.position);
}

	

