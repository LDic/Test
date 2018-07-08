using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_UIBoost : MonoBehaviour
{
	private Text boostGaugeText;
	private Image boostGaugeIcon;
	// Update is called once per frame
	private void Start()
	{
		boostGaugeText = transform.Find("BoostGaugeText").GetComponent<Text>();
		boostGaugeIcon = transform.Find("BoostGaugeIcon").GetComponent<Image>();
	}

	void OnGUI ()
	{
		boostGaugeText.text = Sc_Database.BoostGauge.ToString();
		boostGaugeIcon.fillAmount = Sc_Database.BoostGauge*0.2f;
	}
}
