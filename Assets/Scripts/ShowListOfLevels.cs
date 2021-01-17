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
			//GameObject levelText = Instantiate (numberOfLayer, new Vector2(-500f, -300f), Quaternion.identity, levelContainsIn.transform);
			//GameObject levelText = Instantiate (numberOfLayer, new Vector2(-500f, -300f), Quaternion.identity);
			GameObject levelText = Instantiate (numberOfLayer, new Vector2(100f, 100f), Quaternion.identity,levelContainsIn.transform);

			levelText.transform.localPosition = new Vector2(-500f  + (220 * level), -300f);

			//levelText.transform.localPosition.y = -300f;

			//levelText.transform.localScale = new Vector2(1f, 1f);
			//levelText.transform.parent = levelContainsIn.transform;
			//levelText.transform.position = new Vector2(-500f, -300f);
			TextMesh levelTextMesh = levelText.GetComponent<TextMesh>();
			//levelText.GetComponent<RectTransform>().anchoredPosition = new Vector2((level - 1) * (level * 5f), 0f);

			//levelText = levelText as Text;
			//levelText.GetComponent<RectTransform>().anchoredPosition = new Vector2((level - 1) * (level * 5f), 0f);
			levelTextMesh.text = "Level: " + level.ToString(); 
		}
	}
}
