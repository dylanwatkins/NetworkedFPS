using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	public float distanceToSee;
	RaycastHit whatIHit;
	GameObject player;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);
		
	if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
	{	
		if(Input.GetKeyDown (KeyCode.E))
		{
			Debug.Log ("I picked up a" + whatIHit.collider.gameObject.name);
			if (whatIHit.collider.tag == "KeyCards")
			{
				if (whatIHit.collider.gameObject.GetComponent<KeyCard>().whatKeyAmI == KeyCard.Keycards.redKey)
				{
					player.GetComponent<Inventory>().hasRedKey = true;
					Destroy(whatIHit.collider.gameObject); 
				}
			}
				if(Input.GetKeyDown (KeyCode.E))
				{
					//Debug.Log ("I picked up a" + whatIHit.collider.gameObject.name);
					if (whatIHit.collider.tag == "Doors")
					{
						if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.redDoor)
						{
							if (player.GetComponent<Inventory>().hasRedKey == true)
							{
								player.GetComponent<Inventory>().hasRedKey = false;
								Destroy(whatIHit.collider.gameObject); 
							}
							else
							{
								Debug.Log ("Find The Red Key");
							}
						}
					}
				}
		}
			
	}
	}
}