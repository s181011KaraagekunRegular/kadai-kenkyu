using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{
	public GameObject Bullet;
	public Transform shortPoint;


	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		transform.position += new Vector3(0.1f * x, 0, 0);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(Bullet, transform.position, Quaternion.identity);
		}
	}
}