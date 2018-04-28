using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {


	int random;
	float timer;
	public Text timerText;

	// Use this for initialization
	void Start () {
		int[] number = new int[9];
		for(int i = 0; i < number.Length; i++)
		{
			number[i] = i + 1;
		}
		for(int i = 0; i < number.Length; i++)
		{
			random = Random.Range(1,9);
			int temp = number[i];
			number[i] = number[random];
			number[random] = temp;
		}

		for (int i = 0; i < number.Length; i++) {
			int randomColor = Random.Range (1, 4);
			if (randomColor > 2) {
				GameObject.Find ("Button" + (i + 1)).GetComponent<Image> ().color = Color.blue;
			} else if (randomColor > 1) {
				GameObject.Find ("Button" + (i + 1)).GetComponent<Image> ().color = Color.red;
			}
			GameObject.Find("Button"+(i+1)).GetComponentInChildren<Text>().text=(number[i]).ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Timer ();
		
	}

	void Timer (){
		timer += Time.deltaTime;
		timerText.text = timer.ToString ();
	}
}


