using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowListOfLevels : MonoBehaviour {
	[SerializeField]

	public GameObject numberOfLayer;
	public GameObject levelContainsIn;
	void Start () {
		PlayerPrefs.SetInt ("lastAvailableLevel", 10);
		for(float level = 0; level <= PlayerPrefs.GetInt("lastAvailableLevel"); level++){
			GameObject levelText = Instantiate (numberOfLayer, new Vector2(100f, 100f), Quaternion.identity,levelContainsIn.transform);

			levelText.transform.localPosition = new Vector2(-500f  + (220 * level), -300f);

			TextMesh levelTextMesh = levelText.GetComponent<TextMesh>();
			
			levelTextMesh.text = "Level: " + level.ToString(); 
		}
	}
}
