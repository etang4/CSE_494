using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    public int levelIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel()
    {
        Application.LoadLevel(levelIndex);
    }
}
