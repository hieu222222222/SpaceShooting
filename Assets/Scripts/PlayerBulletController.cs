using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {

		speed = 6f;
	}

	// Update is called once per frame
	void Update () {
		Vector2 _Pos = transform.position;
		_Pos = new Vector2 (_Pos.x, _Pos.y + speed * Time.deltaTime);
		transform.position = _Pos;
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));
		if (transform.position.y > max.y)
			Destroy (gameObject);
	}
}
