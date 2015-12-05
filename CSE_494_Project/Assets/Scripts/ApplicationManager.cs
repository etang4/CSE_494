using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {
	
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

	public void Quit () 
	{
		Application.Quit();
	}
}
