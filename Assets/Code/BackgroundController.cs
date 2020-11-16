using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
	[SerializeField]
	float speed = 2;

	void Update()
	{
		transform.position -= new Vector3(0, Time.deltaTime * speed * speed);
		if (transform.position.y <= -8.5f)
		{
			transform.position = new Vector2(0, 13.0f);
		}
	}
}
