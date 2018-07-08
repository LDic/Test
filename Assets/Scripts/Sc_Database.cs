using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Database
{
	private static float boostGauge = 0f;
	public static float BoostGauge
	{
		get {return boostGauge;}
		set
		{
			boostGauge = value;
			if(boostGauge >= 5) {boostGauge = 5f;}
		}
	}
}
