using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollider1 : MonoBehaviour
{
	float x, y;
	bool triggered = false;
    // Start is called before the first frame update
	void Start()
	{
		x = GameObject.Find("PathPoint7 (3)").transform.position.x;
		y = GameObject.Find("PathPoint7 (3)").transform.position.y;
	}

    // Update is called once per frame
	void Update()
	{
		if (!triggered) {
			if ((x-1 < transform.position.x && transform.position.x < x+1) && (y-1 < transform.position.y && transform.position.y < y+1)) {
				
				Debug.Log("Triggered 1");
				triggered = true;
			}	
		}
	}

}
