using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
	public GameObject PlayerBullet;
	public GameObject PlayerBulletPosition01;
	public GameObject PlayerBulletPosition02;
	public GameObject PlayerBulletPosition03;
	public float _speed;
	// Use this for initialization
	void Start () {
		
	}
	void Move(Vector2 d)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));
		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;
		max.y = max.y - 0.285f;
		min.y = min.y + 0.285f;
		Vector2 pos = transform.position;
		pos += d * _speed * Time.deltaTime;
		pos.x = Mathf.Clamp (pos.x,min.x,max.x);
		pos.y = Mathf.Clamp (pos.y,min.y,max.y);
		transform.position = pos;
	}
	// Update is called once per frame
	void Update () {
		
			

		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		Vector2 direction = new Vector2 (x,y).normalized;
		Move(direction);
		if(Input.GetKeyDown("space"))
		{
		GameObject bullet01 = (GameObject)Instantiate (PlayerBullet);
		bullet01.transform.position = PlayerBulletPosition01.transform.position;
		GameObject bullet02 = (GameObject)Instantiate (PlayerBullet);
		bullet02.transform.position = PlayerBulletPosition02.transform.position;
		GameObject bullet03 = (GameObject)Instantiate (PlayerBullet);
		bullet03.transform.position = PlayerBulletPosition03.transform.position;
		}
	}
}
