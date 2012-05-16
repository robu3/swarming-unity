using UnityEngine;
using System.Collections;

public class GrabberController : MonoBehaviour {
	public Vector3 dragVector;
	public GameObject cursorObject;
	public Vector3 cursorPosition;
	public Vector3 prevCursorPosition;

	private static GrabberController instance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// track cursor position
		prevCursorPosition = cursorPosition;
		cursorPosition = GetMousePositionYZero();

		// reset drag vector
		dragVector = Vector3.zero;

		if (Input.GetMouseButtonDown(0))
		{
			// attempt to find cursor object
			cursorObject = GetCursorObject();			
		}
		// listen for mouse down events
		else if (Input.GetMouseButton(0))
		{
			// holding
			dragVector = cursorPosition - prevCursorPosition;
		}
	}

	/// <summary>
	/// Singleton instance
	/// </summary>
	public static GrabberController Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject container = new GameObject();
				container.name = "GrabberController";
				instance = container.AddComponent<GrabberController>();			
			}
			
			return instance;
		}
	}

	private GameObject GetCursorObject()
	{
		// get mouse position data
		Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
		
		// get the object (if any) immediately under the cursor
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		
		return hit.collider != null ? hit.collider.gameObject : null;
	}

	public static Vector3 GetMousePositionYZero()
	{
		if (Camera.mainCamera != null)
		{
			Vector3 pos = Camera.mainCamera.ScreenToWorldPoint(new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y, 
				Camera.mainCamera.transform.position.y
			));
			return new Vector3(pos.x, 0f, pos.z);
		}
		else {
			return Vector3.zero;
		}
	}
}
