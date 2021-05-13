using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSettings : MonoBehaviour {

	void Start () {
		if (!PlayerPrefs.HasKey ("AudioOn")) {
			PlayerPrefs.SetString ("AudioOn", "Yes");
		}
		if (!PlayerPrefs.HasKey ("CountOfChargedBatteries")) {
			PlayerPrefs.SetInt ("CountOfChargedBatteries", 0);
		}
		if (!PlayerPrefs.HasKey ("FirstSlotOfTrap")) {
			PlayerPrefs.SetString ("FirstSlotOfTrap", "dinamit");
		}
		if (!PlayerPrefs.HasKey ("SecondSlotOfTrap")) {
			PlayerPrefs.SetString ("SecondSlotOfTrap", "apple");
		}
		if (!PlayerPrefs.HasKey ("ThirdSlotOfTrap")) {
			PlayerPrefs.SetString ("ThirdSlotOfTrap", "flag");
		}
		if (!PlayerPrefs.HasKey ("FourthSlotOfTrap")) {
			PlayerPrefs.SetString ("FourthSlotOfTrap", "ball");
		}
		if (!PlayerPrefs.HasKey ("lastAvailableLevel")) {
			PlayerPrefs.SetInt ("lastAvailableLevel", 1);
		}
		if (!PlayerPrefs.HasKey ("TextCoinsAll")) {
			PlayerPrefs.SetInt ("TextCoinsAll", 0);
		}
		if (!PlayerPrefs.HasKey ("ElixirsCount")) {
			PlayerPrefs.SetInt ("ElixirsCount", 0);
		}

		PlayerPrefs.SetInt ("TextCoinsInLevel", 0);		

		print (PlayerPrefs.GetString ("AudioOn"));
	}
}
