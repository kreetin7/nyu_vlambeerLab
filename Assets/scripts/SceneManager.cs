using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//USAGE: put this on an empty object entitled "SceneManager" 
//Intent: reload the scene each time you press R key
public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			

		}
	}
}
