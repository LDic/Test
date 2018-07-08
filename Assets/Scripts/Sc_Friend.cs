using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Friend : MonoBehaviour
{
	private bool canTouch;
	private float delayTime;
	// Use this for initialization
	void Start ()
	{
		canTouch = true;
		delayTime = 0.75f;
		//GetComponent<Rigidbody>().velocity = new Vector3(3f, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Rigidbody>().velocity = new Vector3(3f, GetComponent<Rigidbody>().velocity.y);
		transform.rotation = new Quaternion();
		if(Input.GetMouseButtonDown(0))
		{
			if(GetOverlappedMeshes().Length > 0)
			{
				if(canTouch == true)
				{
					WhenTouched(GetOverlappedMeshes());
					//GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
				}
			}
			else
			{
				if(Sc_Database.BoostGauge >= 5)
				{
					ActivateBoost();
				}
				else if(canTouch == true) {WhenTouched();}
			}
		}

		transform.Find("PracticalArea").transform.rotation = new Quaternion(0f, 0f, -0.5f, 1f);
	}

	private Collider [] GetOverlappedMeshes()
	{
		Collider[] overlappedComponents = Physics.OverlapSphere(gameObject.transform.position, 0.35f);
		int count = 0;
		for(int i = 0; i < overlappedComponents.GetLength(0); i++) { if(overlappedComponents[i].CompareTag("Land")) { count++; } }
		Collider[] overlappedMeshes = new Collider[count];
		count = 0;
		for(int i = 0; i < overlappedComponents.GetLength(0); i++)
		{
			if(overlappedComponents[i].CompareTag("Land")) { overlappedMeshes[count] = overlappedComponents[i]; count++; }
		}

		return overlappedMeshes;
	}

	private void WhenTouched()
	{
		canTouch = false; delayTime = 0.75f;
		StartCoroutine(DelayCanTouch());
		Sc_Database.BoostGauge += 1f;
		Debug.Log(Sc_Database.BoostGauge);
	}
	private void WhenTouched(Collider [] overlappedMeshes)
	{
		canTouch = false; delayTime = 0.75f;
		StartCoroutine(DelayCanTouch());
		Sc_Database.BoostGauge += 1f;
		Debug.Log(Sc_Database.BoostGauge);
	}

	private void ActivateBoost()
	{
		Sc_Database.BoostGauge = 0f;
	}

	IEnumerator DelayCanTouch()
	{
		while(delayTime > 0)
		{
			delayTime -= Time.deltaTime;
			yield return null;
		}
		delayTime = 0.75f; canTouch = true;
		Debug.Log("End Delay");
		StopCoroutine(DelayCanTouch());
	}
}
