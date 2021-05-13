using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChargeBattery : MonoBehaviour {
	public List<Image> batteries;
	public int cursorOfBatteries = 0;
	Coroutine chargetion;
	public Sprite chargedBatterySprite;
	public Text leftTime;
	float mytime;
	// Use this for initialization
	void Start () {
		StartCoroutine (Second());
		mytime = Time.timeSinceLevelLoad;
		//chargetion = StartCoroutine (Charge());
	}

	IEnumerator Second(){
		bool can = true;
		while (cursorOfBatteries < batteries.Count) {
			mytime = mytime >= 600f ? 0f : mytime + 1f;
			if (mytime % 600.0f == 0.0f) {
				//if(cursorOfBatteries % 2 == 0){
					cursorOfBatteries++;
					//batteries[cursorOfBatteries].sprite = chargedBatterySprite;
					PlayerPrefs.SetInt ("CountOfChargedBatteries", cursorOfBatteries);
				//}


				if (cursorOfBatteries == batteries.Count) {
					print ("Всё заряжено полностью");
				}
				/*
				if (can) {
					cursorOfBatteries++;

				}
				*/

			}
			can = !can;
			yield return new WaitForSeconds (1.0f);
		}
	}


	void Update(){
		//leftTime.text = Mathf.Floor((600f - Time.timeSinceLevelLoad) / 60f).ToString() + ":" + (Mathf.Floor(600f - Time.timeSinceLevelLoad) / 60f).ToString().Substring(1,1);

		string zero = Mathf.Floor((Mathf.Ceil(mytime / 60f) * 60f) - mytime).ToString().Length == 1 ? "0" : "";
		//leftTime.text = Mathf.Floor((600f - Time.timeSinceLevelLoad) / 60f).ToString() + ":" + zero + Mathf.Floor((Mathf.Ceil(Time.timeSinceLevelLoad / 60f) * 60f) - Time.timeSinceLevelLoad);
		leftTime.text = Mathf.Floor((600f - mytime) / 60f).ToString() + ":" + zero + Mathf.Floor((Mathf.Ceil(mytime / 60f) * 60f) - mytime);
		Debug.Log (mytime);
		//leftTime.text = Mathf.Floor((600f - Time.timeSinceLevelLoad) / 60f).ToString() + ":" +  (60f - (Mathf.Ceil(Mathf.Ceil(600f - Time.timeSinceLevelLoad)  / 60f  ) * 60f)).ToString();
		//leftTime.text = Mathf.Floor((600f - Time.timeSinceLevelLoad) / 60f).ToString() + ":" +  (((Mathf.Ceil(Mathf.Ceil(Time.timeSinceLevelLoad / 60f)  * 60f  ) * 60f) * 60f) - (Mathf.Floor(Mathf.Floor(Time.timeSinceLevelLoad / 60f)  * 60f  ) * 60f)).ToString();
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
