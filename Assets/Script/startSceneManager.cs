using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void stage1Button(){
		SceneManager.LoadScene ("Main");
	}
	public void stage2Button(){
		SceneManager.LoadScene ("Main2");
	}
}
