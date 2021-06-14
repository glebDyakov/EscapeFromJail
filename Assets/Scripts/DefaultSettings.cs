using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DefaultSettings : MonoBehaviour {

	void Start () {
		if (!PlayerPrefs.HasKey ("AudioOn")) {
			PlayerPrefs.SetString ("AudioOn", "Yes");
		}
		if (!PlayerPrefs.HasKey ("GameMode")) {
			PlayerPrefs.SetString ("GameMode", "Survival");
		}
		if (!PlayerPrefs.HasKey ("CountOfChargedBatteries")) {
			PlayerPrefs.SetInt ("CountOfChargedBatteries", 0);
		}
		if (!PlayerPrefs.HasKey ("CountAmmo")) {
			PlayerPrefs.SetInt ("CountAmmo", 2);
		}
		if (!PlayerPrefs.HasKey ("CountNaruchniki")) {
			PlayerPrefs.SetInt ("CountNaruchniki", 0);
		}
		if (!PlayerPrefs.HasKey ("CountSvist")) {
			PlayerPrefs.SetInt ("CountSvist", 0);
		}
		if (!PlayerPrefs.HasKey ("CountShootgunAmmo")) {
			PlayerPrefs.SetInt ("CountShootgunAmmo", 1);
		}
		if (!PlayerPrefs.HasKey ("ForceOfShootgun")) {
			PlayerPrefs.SetFloat ("ForceOfShootgun", 0.33f);
		}
		if (!PlayerPrefs.HasKey ("CountStickAmmo")) {
			PlayerPrefs.SetInt ("CountStickAmmo", 1);
		}
		if (!PlayerPrefs.HasKey ("ForceOfNaruchniki")) {
			PlayerPrefs.SetFloat ("ForceOfNaruchniki", 0.2f);
		}
		if (!PlayerPrefs.HasKey ("ForceOfSvist")) {
			PlayerPrefs.SetFloat ("ForceOfSvist", 0.2f);
		}
		if (!PlayerPrefs.HasKey ("ForceOfShield")) {
			PlayerPrefs.SetFloat ("ForceOfShield", 0.2f);
		}
		if (!PlayerPrefs.HasKey ("ForceOfDirty")) {
			PlayerPrefs.SetFloat ("ForceOfDirty", 0.2f);
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
		if (!PlayerPrefs.HasKey ("DoubleCoinsEnabled")) {
			PlayerPrefs.SetInt ("DoubleCoinsEnabled", 0);
		}
		if (!PlayerPrefs.HasKey ("ShieldEnabled")) {
			PlayerPrefs.SetInt ("ShieldEnabled", 0);
		}
		if (!PlayerPrefs.HasKey ("DirtyEnabled")) {
			PlayerPrefs.SetInt ("DirtyEnabled", 0);
		}
		if (!PlayerPrefs.HasKey ("FourthSlotOfTrap")) {
			PlayerPrefs.SetString ("FourthSlotOfTrap", "ball");
		}
		if (!PlayerPrefs.HasKey ("lastAvailableLevel")) {
			PlayerPrefs.SetInt ("lastAvailableLevel", 1);
		}
		if (!PlayerPrefs.HasKey ("TextCoinsAll")) {
			PlayerPrefs.SetInt ("TextCoinsAll", 5000);

		}
		if (!PlayerPrefs.HasKey ("ElixirsCount")) {
			PlayerPrefs.SetInt ("ElixirsCount", 0);
		}
		if (!PlayerPrefs.HasKey ("LastTimestampPlay")) {
			PlayerPrefs.SetString ("LastTimestampPlay", DateTime.Now.ToString("dd:MM:yyyy|HH:mm:ss"));
		}

		PlayerPrefs.SetInt ("TextCoinsInLevel", 0);		

		print (PlayerPrefs.GetString ("AudioOn"));
	}
}
