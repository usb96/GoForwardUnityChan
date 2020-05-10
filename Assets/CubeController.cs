using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	//キューブの移動速度
	private float speed = -12;

	//消滅位置
	private float deadLine = -10;

	//衝突時の効果音
	public AudioClip cubeSound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		//キューブを移動させる
		transform.Translate(this.speed * Time.deltaTime, 0, 0);

		//画面外に出たら破棄する
		if (transform.position.x < this.deadLine)
		{
			Destroy(gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
		//地面またはCubeに触れたときに、効果音の音量を0.3にする
		if (other.gameObject.tag == "GroundTag" || other.gameObject.tag == "CubeTag")
		{
			GetComponent<AudioSource>().volume = 0.3f;
			GetComponent<AudioSource>().PlayOneShot(cubeSound);
		}
	}
}
