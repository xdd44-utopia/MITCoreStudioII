using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronizeController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		GameObject instance;
		if (transform.position.z < 60) {
			instance = Instantiate(gameObject, transform.parent);
			instance.transform.position = transform.position + new Vector3(0, 0, 100);
		}
		else {
			instance = Instantiate(gameObject, transform.parent);
			instance.transform.position = transform.position - new Vector3(0, 0, 100);
		}
		instance.GetComponent<SynchronizeController>().enabled = false;
	}
}
