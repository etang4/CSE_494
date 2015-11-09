using UnityEngine;
using System.Collections;

public class DexterAI : MonoBehaviour {

    public GameObject[] targetPath;
    public bool canMove;
    public GameObject player;
    public int moveSpeed;
    public int rotationSpeed;
    public float distanceFromPlayer;
    public float distanceFromTarget;
    int currentTarget;

	// Use this for initialization
	void Start () {
        currentTarget = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            //If Dexter too far from Player. Stop and look at player.
            if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) > distanceFromPlayer)
            {
                this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation,
                    Quaternion.LookRotation(player.transform.position - this.gameObject.transform.position), rotationSpeed * Time.deltaTime);
            }
            //if Dexter is at the target and the player is not.Stop and look at player.
            else if (Vector3.Distance(this.gameObject.transform.position, targetPath[currentTarget].transform.position) < 0.5f &&
                Vector3.Distance(player.transform.position, targetPath[currentTarget].transform.position) > distanceFromTarget)
            {
                this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, 
                    Quaternion.LookRotation(player.transform.position - this.gameObject.transform.position), rotationSpeed * Time.deltaTime);
            }
            else if(Vector3.Distance(player.transform.position, targetPath[currentTarget].transform.position) < distanceFromTarget)
            {
                currentTarget++;
            }
            //Otherwise go to next target
            else
            {
                this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation,
                    Quaternion.LookRotation(targetPath[currentTarget].transform.position - this.gameObject.transform.position), rotationSpeed * Time.deltaTime);
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetPath[currentTarget].transform.position, step);
                //Check if player is at the target
                
            }
        }

	}

    public void AllowDexterToMove()
    {
        canMove = true;
    }
}
