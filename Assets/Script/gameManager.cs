using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {


	int random;
//	タイマーを数え表示させるためのもの
	float timer;
	public Text timerText;
//	何回までボタンを押せるのか
	int whiteCount=2;
	int blueCount=3;
	int redCount=4;
//	押さないといけないボタンの番号
	int clickButtonCount=1;
	string selectColor;
	int[] clickNumber; 
	bool clickOk=false;
	// Use this for initialization
	int counter=0;
	AudioSource audioSource;
	public AudioClip goodSound;
	public AudioClip badSound;

	void Start () {
		int[] number = new int[9];
		clickNumber = new int[9];
//		int型の配列に１〜９の番号を格納
		for(int i = 0; i < number.Length; i++){
			number[i] = i + 1;
		}
//		i番目とランダムの箱の内容を入れ替える
		for(int i = 0; i < number.Length; i++){
			random = Random.Range(1,9);
			int temp = number[i];
			number[i] = number[random];
			number[random] = temp;

		}
//		色と番号を格納していく
		for (int i = 0; i < number.Length; i++) {
			int randomColor = Random.Range (1, 4);
			if (randomColor > 2) {
				GameObject.Find ("Button" + (i + 1)).GetComponent<Image> ().color = Color.blue;
				selectColor = "blue";
			} else if (randomColor > 1) {
				GameObject.Find ("Button" + (i + 1)).GetComponent<Image> ().color = Color.red;
				selectColor = "red";
			} else {
				GameObject.Find ("Button" + (i + 1)).GetComponent<Image> ().color = Color.white;
				selectColor = "white";
			}
			GameObject.Find("Button"+(i+1)).GetComponentInChildren<Text>().text=number[i].ToString();
			int buttonNumber = number [i];
			string buttonColor = selectColor;
			GameObject.Find("Button"+(i+1)).GetComponent<Button>().onClick.AddListener(() => CountButton(buttonNumber));
			GameObject.Find("Button"+(i+1)).GetComponent<Button>().onClick.AddListener(() => ColorButton(buttonColor));
		}
		audioSource = this.gameObject.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frames
	void Update () {
		Timer ();
	}
//	タイマー
	void Timer (){
		timer += Time.deltaTime;
		timerText.text = timer.ToString ();
	}

	public void CountButton (int k){
		if (k == clickButtonCount) {
			Debug.Log (k);
			audioSource.clip = goodSound;
			audioSource.Play ();
			clickOk = true;
		} else {
			audioSource.clip = badSound;
			audioSource.Play ();
		}
	}
	public void ColorButton(string s){
//		空じゃなかったら色を出力
		if (s != "") {
			if (clickOk == true) {
				counter++;
//				押したボタンが何色かどうか
				if (s == "red") {
//					それぞれのボタンの押すべき回数を超えたか
					if (counter >= redCount) {
						counter = 0;
						clickButtonCount++;
					}
				}
				if (s == "blue") {
					if (counter >= blueCount) {
						counter = 0;
						clickButtonCount++;
					}
				}
				if (s == "white") {
					if (counter >= whiteCount) {
						counter = 0;
						clickButtonCount++;
					}
				}
				clickOk = false;
				if (clickButtonCount > 9) {
					Debug.Log ("Finish!! Your Time is" + timer);
				}
			}
		}
	}

}


