﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{





	void Update()
	{
		transform.position += new Vector3(0, 0.1f, 0);
	}
}