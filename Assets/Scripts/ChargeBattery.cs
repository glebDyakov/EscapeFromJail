using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class ChargeBattery : MonoBehaviour {
	float doOnceTimeStamp = 0;
	public List<Image> batteries;
	public int cursorOfBatteries = 0;
	Coroutine chargetion;
	public Sprite chargedBatterySprite;
	public Text leftTime;
	float mytime;
	
	void Start () {

		for(int batteryIndex = 0; batteryIndex < PlayerPrefs.GetInt("CountOfChargedBatteries"); batteryIndex++){
			//batteries[batteryIndex].sprite = chargedBatterySprite;
			batteries[batteryIndex].fillAmount = 1f;
		}

		StartCoroutine (Second());
		mytime = Time.timeSinceLevelLoad;
		//chargetion = StartCoroutine (Charge());
	
		DateTime lastTimestampPlay = DateTime.ParseExact(PlayerPrefs.GetString("LastTimestampPlay"), "dd:MM:yyyy|HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
		TimeSpan differense = DateTime.Now.Subtract(lastTimestampPlay);
		int countElapsedMinutes = 0;
		if(differense.Days > 0){
			countElapsedMinutes += differense.Days * 24 * 60;
		}
		if(differense.Hours > 0){
			countElapsedMinutes += differense.Hours * 60;
		}
		if(differense.Minutes > 0){
			countElapsedMinutes += differense.Minutes;
		}
		int countElapsedBatterys = countElapsedMinutes / 10;
		if(countElapsedBatterys >= 6) {
			countElapsedBatterys = 6;
			cursorOfBatteries = 6;
		} else if(countElapsedBatterys <= 5) {
			cursorOfBatteries = countElapsedBatterys;
		}

		 cursorOfBatteries += PlayerPrefs.GetInt ("CountOfChargedBatteries");

		if(cursorOfBatteries >= 6){
			cursorOfBatteries = 6;
		}
		
		for(int batteryIndex = 0; batteryIndex < cursorOfBatteries; batteryIndex++){
			//batteries[batteryIndex].sprite = chargedBatterySprite;
			batteries[batteryIndex].fillAmount = 1f;
		}
		
		PlayerPrefs.SetInt ("CountOfChargedBatteries", cursorOfBatteries);
		print("countElapsedMinutes: " + countElapsedMinutes.ToString());
		print("cursorOfBatteries: " + cursorOfBatteries.ToString());
		print("countElapsedBatterys: " + countElapsedBatterys.ToString());
		print("countElapsedBatterys: " + countElapsedBatterys.ToString());
	}

	IEnumerator Second(){
		bool can = true;
		while (cursorOfBatteries < batteries.Count) {
			mytime = mytime >= 600f ? 0f : mytime + 1f;
			
			if(mytime % 120.0f == 0.0f){
				if(Time.timeSinceLevelLoad > doOnceTimeStamp + 5){
					doOnceTimeStamp = Time.timeSinceLevelLoad;
					batteries[cursorOfBatteries].fillAmount += 1f / 5f;
				}
				if (mytime % 600.0f == 0.0f) {
					if(Time.timeSinceLevelLoad > doOnceTimeStamp + 5){
						doOnceTimeStamp = Time.timeSinceLevelLoad;
					//if(cursorOfBatteries % 2 == 0){
						
						batteries[cursorOfBatteries].sprite = chargedBatterySprite;
						cursorOfBatteries++;
						PlayerPrefs.SetInt ("CountOfChargedBatteries", cursorOfBatteries);
					//}
					}

					if (cursorOfBatteries == batteries.Count) {
						print ("Всё заряжено полностью");
					}
					/*
					if (can) {
						cursorOfBatteries++;

					}
					*/

				}
			}
			can = !can;
			yield return new WaitForSeconds (1.0f);
		}
	}


	void Update(){
		if(cursorOfBatteries < 6
			//PlayerPrefs.GetInt("CountOfChargedBatteries") < 6
			){
			
			string zero = Mathf.Floor((Mathf.Ceil(mytime / 60f) * 60f) - mytime).ToString().Length == 1 ? "0" : "";
			leftTime.text = Mathf.Floor((600f - mytime) / 60f).ToString() + ":" + zero + Mathf.Floor((Mathf.Ceil(mytime / 60f) * 60f) - mytime);
		}
	}
	/*
	IEnumerator Charge(){
		while (cursorOfBatteries < batteries.Count) {
			batteries[cursorOfBatteries].sprite = chargedBatterySprite;
			PlayerPrefs.SetInt ("CountOfChargedBatteries", cursorOfBatteries);

			if (cursorOfBatteries == batteries.Count) {
				print ("Всё заряжено полностью");
				StopCoroutine (chargetion);

			}
			cursorOfBatteries++;
			//mytime = mytime >= 600f ? 0f : Time.timeSinceLevelLoad;
			yield return new WaitForSeconds(600f);
		}
	}
	*/
}
