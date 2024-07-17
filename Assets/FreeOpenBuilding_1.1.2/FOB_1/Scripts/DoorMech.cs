using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMech : MonoBehaviour 
{

	[SerializeField] Vector3 OpenRotation = new Vector3(0f,90f,0f), CloseRotation;

	[SerializeField] float rotSpeed = 1f;

	[SerializeField] bool doorBool;

		
	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == ("Player") && Input.GetKeyDown(KeyCode.E))
		{
			if (!doorBool)
				doorBool = true;
			else
				doorBool = false;
		}
	}

	void Update()
	{
		if (doorBool)
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (OpenRotation), rotSpeed * Time.deltaTime);
		else
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (CloseRotation), rotSpeed * Time.deltaTime);	
	}

}

