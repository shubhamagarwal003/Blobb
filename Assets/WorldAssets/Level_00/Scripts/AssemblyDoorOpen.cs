﻿using UnityEngine;
using System.Collections;

public class AssemblyDoorOpen : MonoBehaviour {
	public bool open=false;
	bool close=false;
	public bool lockIt;
	public bool openOnTrigger=true;
	public bool locked = false;
	public bool down=false;
	Vector3 startPos;
	Vector3 upPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		if (down == false) {
			upPos = transform.position + new Vector3 (0, 4.0f, 0);
		} else {
			upPos = transform.position + new Vector3 (0, -4.0f, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (locked == false) {
			if (open == true) {
				transform.position = Vector3.Lerp(transform.position,upPos , Time.deltaTime);

			}
		}

		if (close == true) {
			transform.position = Vector3.Lerp(transform.position,startPos , Time.deltaTime);
			if(lockIt==true)
			{
				locked=true;
			}
		}
	}

	void OnTriggerEnter(Collider enter)
	{
		if (openOnTrigger == true) 
		{
			if (enter.gameObject.name.Contains("Blobb")) 
			{
				//print ("enter");
				//print (enter.name);
				//open=true;
				//close=false;
			}
		}
	}

	void OnTriggerExit(Collider exit)
	{
		if (openOnTrigger == true) 
		{
			if (exit.gameObject.name.Contains("Blobb")) 
			{
				//print ("exit");
				open=false;
				//close=true;
			}
		}
	}

	void openDoor(){

		if(!locked)
		{
			open=true;
			close=false;
		}
		else
		{
			locked = false;
		}

	}

	void closeDoor(){
		open=false;
		close=true;
	}
}
