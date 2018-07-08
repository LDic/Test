using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_UIButton : MonoBehaviour
{
	public void PauseGame()
	{
		Time.timeScale = 0f;
		transform.Find("ResumeButton").gameObject.SetActive(true);
		transform.Find("PauseButton").gameObject.SetActive(false);
	}
	public void ResumeGame()
	{
		Time.timeScale = 1f;
		transform.Find("PauseButton").gameObject.SetActive(true);
		transform.Find("ResumeButton").gameObject.SetActive(false);
	}
}
