using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager2 : MonoBehaviour
{
	
	int random;
	//	タイマーを数え表示させるためのもの
	float timer;
	public Text timerText;
	//	押すべきボタンの配列中身
	int clickButtonCount=0;
	//押すべきボタンの中身を入れておくもの
	int[] toClickButtonNumber;
	//	何回までボタンを押せるのか
	int whiteCount = 2;
	int blueCount = 3;
	int redCount = 4;
	// 選んだ色
	string selectColor;
	bool clickOk = false;
	int counter = 0;
	//AudioSource
	AudioSource audioSource;
	public AudioClip goodSound;
	public AudioClip badSound;


	void Start(){
		int[] number = new int[9];
		toClickButtonNumber = new int[9];
//		ランダムに数字を配列に格納
		for (int i = 0; i < number.Length; i++) {
			number [i] = Random.Range (1, 100);
//			Debug.Log (number [i]);
		}

//		バブルソート
		// 最後の要素を除いて、すべての要素を並べ替える
		for(int i=0;i<number.Length-1;i++){

			// 下から上に順番に比較します
			for(int j=number.Length-1;j>i;j--){

				// 上の方が大きいときは互いに入れ替える
				if(number[j]<number[j-1]){
					int t=number[j];
					number[j]=number[j-1];
					number[j-1]=t;
				}
			}
		}
			
		for (int i = 0; i < number.Length; i++) {
//			押すべきボタンに、昇順の値が格納される
			toClickButtonNumber [i] = number [i];
		}
//		中身を入れ替える
		for (int i = 0; i < number.Length; i++) {
			random = Random.Range (0, 9);
			int temp = number [i];
			number [i] = number [random];
			number [random] = temp;

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
			GameObject.Find ("Button" + (i + 1)).GetComponentInChildren<Text> ().text = number [i].ToString ();
			int buttonNumber = number [i];
			string buttonColor = selectColor;
			//各ボタンに引数(ボタンの番号と色)を渡す
			GameObject.Find ("Button" + (i + 1)).GetComponent<Button> ().onClick.AddListener (() => CountButton (buttonNumber));
			GameObject.Find ("Button" + (i + 1)).GetComponent<Button> ().onClick.AddListener (() => ColorButton (buttonColor));
		}
		audioSource = this.gameObject.GetComponent<AudioSource> ();

	}
	// Update is called once per frames
	void Update ()
	{
		Timer ();

	}
	//	タイマー
	void Timer ()
	{
		timer += Time.deltaTime;
		timerText.text = timer.ToString ();
	}

	public void CountButton (int k)
	{
		if (k == toClickButtonNumber[clickButtonCount]) {
			Debug.Log (k);
			audioSource.clip = goodSound;
			audioSource.Play ();
			clickOk = true;
		} else {
			audioSource.clip = badSound;
			audioSource.Play ();
		}
	}

	public void ColorButton (string s)
	{
		//空じゃなかったら色を出力
		if (clickOk == true) {
			counter++;
			//押したボタンが何色かどうか
			if (s == "red") {
				//それぞれのボタンの押すべき回数を超えたか
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
			if (clickButtonCount > 8) {
//				押すべきボタンの中身をリセットする
				toClickButtonNumber [8] = 0;
				Debug.Log ("Finish!! Your Time is" + timer);
			}
		}
	}






}