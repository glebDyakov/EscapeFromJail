using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowElixirBuyWindow : MonoBehaviour {
	public GameObject elixirBuyWindow;
	void OnMouseDown () {
		elixirBuyWindow.SetActive (true);
	}
}
