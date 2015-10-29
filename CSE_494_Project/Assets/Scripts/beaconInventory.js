#pragma strict
static var beaconCount : int = 0;

function Start () {
	beaconCount = 0;
}

function BeaconPickup() {
	beaconCount++;
}