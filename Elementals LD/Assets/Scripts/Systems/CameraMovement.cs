using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] Transform playerOne;
    [SerializeField] Transform playerTwo;
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3((playerOne.transform.position.x + playerTwo.transform.position.x) / 2, transform.position.y, transform.position.z), 10f);
	}
}
