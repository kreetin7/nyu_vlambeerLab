﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
//using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;

// MAZE PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you have extra time, complete the "extra tasks" to do at the very bottom

// STEP 1: ======================================================================================
// put this script on a Sphere... it will move around, and drop a path of floor tiles behind it

public class Pathmaker : MonoBehaviour {

// STEP 2: ============================================================================================
// translate the pseudocode below

//	DECLARE CLASS MEMBER VARIABLES:
//	Declare a private integer called counter that starts at 0; 		// counter var will track how many floor tiles I've instantiated
	public int counter = 0; 
//	Declare a public Transform called floorPrefab, assign the prefab in inspector;
	public Transform [] floorPrefab;
//	Declare a public Transform called pathmakerSpherePrefab, assign the prefab in inspector; 		// you'll have to make a "pathmakerSphere" prefab later
	public Transform pathMakerSpherePrefab;

	public static int GlobalTileCount = 0;

	
	

	private void Start()
	{
		

		GlobalTileCount = 0;


	}
	

	void Update () {
//		If counter is less than 50, then:
		float n2 = Random.Range(0.7f, 0.85f);
		
		if (counter < 50 && GlobalTileCount < 50)
		{

			Vector3 spawnPos = transform.position;
 
//			Generate a random number from 0.0f to 1.0f;
			float n = Random.Range(0.0f, 1.0f);
//			If random number is less than 0.25f, then rotate myself 90 degrees;
			if (n < 0.05f)
			{
				transform.eulerAngles += new Vector3(0,Random.Range(45,90),0);
			}
//				... Else if number is 0.25f-0.5f, then rotate myself -90 degrees;
			else if (n > n2 && n < 0.9f)
			{
				transform.eulerAngles += new Vector3(0,Random.Range(-90,-45),0);
			}
			
//				... Else if number is 0.99f-1.0f, then instantiate a pathmakerSpherePrefab clone at my current position;
			else if (n > 0.8f && n < 1.0f)
			{
				Instantiate(pathMakerSpherePrefab, spawnPos, Quaternion.Euler(0f,0f,0f));
			}
			
			
//			// end elseIf

//			Instantiate a floorPrefab clone at current position;
			
			int randomIndex =
				Random.Range(0, floorPrefab.Length); 
			Instantiate(floorPrefab[randomIndex], spawnPos, Quaternion.Euler(0f,0f,0f));
			GlobalTileCount += 1;
			
			
//			Move forward ("forward", as in, the direction I'm currently facing) by 5 units;
			transform.Translate(0,0,5);
//			Increment counter;
			counter += 1; 
		}

//		Else:
	else
		{
			Destroy(this.gameObject);
		}
	

		
//			Destroy my game object; 		// self destruct if I've made enough tiles already
	}

} // end of class scope

// MORE STEPS BELOW!!!........




// STEP 3: =====================================================================================
// implement, test, and stabilize the system

//	IMPLEMENT AND TEST:
//	- save your scene!!! the code could potentially be infinite / exponential, and crash Unity
//	- put Pathmaker.cs on a sphere, configure all the prefabs in the Inspector, and test it to make sure it works
//	STABILIZE: 
//	- code it so that all the Pathmakers can only spawn a grand total of 500 tiles in the entire world; how would you do that?
//	- (hint: declare a "public static int" and have each Pathmaker check this "globalTileCount", somewhere in your code? if there are already enough tiles, then maybe the Pathmaker could Destroy my game object



// STEP 4: ======================================================================================
// tune your values...

// a. how long should a pathmaker live? etc.
// b. how would you tune the probabilities to generate lots of long hallways? does it work?
// c. tweak all the probabilities that you want... what % chance is there for a pathmaker to make a pathmaker? is that too high or too low?



// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable



// STEP 6:  =====================================================================================
// art pass, usability pass

// - move the game camera to a position high in the world, and then point it down, so we can see your world get generated
// - CHANGE THE DEFAULT UNITY COLORS, PLEASE, I'M BEGGING YOU
// - add more detail to your original floorTile placeholder -- and let it randomly pick one of 3 different floorTile models, etc. so for example, it could randomly pick a "normal" floor tile, or a cactus, or a rock, or a skull
//		- MODEL 3 DIFFERENT TILES IN MAYA! DON'T STOP USING MAYA OR YOU'LL FORGET IT ALL
//		- add a simple in-game restart button; let us press [R] to reload the scene and see a new level generation
// - with Text UI, name your proc generation system ("AwesomeGen", "RobertGen", etc.) and display Text UI that tells us we can press [R]



// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)
