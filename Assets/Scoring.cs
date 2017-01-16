using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
	private GameObject scoreText;
	int point = 0;
	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.GetComponent<Text> ().text = this.point.ToString() + "point";
	}
	 
	void OnCollisionEnter(Collision other){
		if (other.transform.tag == "SmallStarTag") {
			this.point += 10;
		} else if (other.transform.tag == "LargeStarTag") {
			this.point += 50;
		} else if (other.transform.tag == "SmallCloudTag") {
			this.point += 20;
		} else if (other.transform.tag == "LargeCloudTag") {
			this.point += 100;
		}
	}
}