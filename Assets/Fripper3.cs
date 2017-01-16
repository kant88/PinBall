using UnityEngine;
using System.Collections;

public class Fripper3 : MonoBehaviour {
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

		bool flicked = false; // フリックされたかどうか

		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.touches [i].position.x < Screen.width / 2 && tag == "LeftFripperTag") {
				SetAngle (this.flickAngle);
				flicked = true;
			}
			if (Input.touches [i].position.x >= Screen.width / 2 && tag == "RightFripperTag") {
				SetAngle (this.flickAngle);
				flicked = true;
			}
		}

		if( flicked == false ) {
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