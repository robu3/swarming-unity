using UnityEngine;
using System.Collections;

public class ObjectGrabberBehavior : MonoBehaviour {
	public float dragFactor = 1f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// respond to changes in the GrabberController
		// specifically drag vector
		if (GrabberController.Instance.dragVector != Vector3.zero)
		{
			GameObject obj = GrabberController.Instance.cursorObject;
			if (obj != null)
			{
				Rigidbody rb = obj.rigidbody;
				if (rb != null)
				{
					// move the object in the direction of the drag
					// could affect velocity instead
					//rb.velocity = GrabberController.Instance.dragVector * dragFactor;
					rb.velocity = Vector3.zero;
					rb.transform.position = GrabberController.Instance.cursorPosition;
				}
			}
		}
	}
}

