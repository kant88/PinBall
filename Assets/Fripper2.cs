﻿using UnityEngine;
using System.Collections;

public class Fripper2 : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoynt;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HinjiJointコンポーネント取得
		this.myHingeJoynt = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		//画面左を押した時左フリッパーを動かす
		if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2 && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//画面右を押した時右フリッパーを動かす
		if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//指が離された時フリッパーを元に戻す
		if (Input.GetMouseButtonUp(0)) {
			SetAngle (this.defaultAngle);
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoynt.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoynt.spring = jointSpr;
	}
}