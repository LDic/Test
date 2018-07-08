using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class Sc_MainButton : MonoBehaviour
{

	private bool isClicked;

	void Start()
	{
		isClicked = false;
		Debug.Log("test");
	}

	void Update()
	{
		if(isClicked)
		{
			StartCoroutine(Delay());
		}
	}

	public void StartGame()
	{
		isClicked = true;
	}
	float time = 0f;
	public IEnumerator Delay()
	{
		time += Time.deltaTime;
		Debug.Log(Time.deltaTime);
		if (time > 1.0) { EditorSceneManager.LoadScene("BasicModeScene"); }
		yield return null;
	}
}
