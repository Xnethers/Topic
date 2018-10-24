using UnityEngine;

public class ItemPickup : MonoBehaviour {

	public Item item;	// Item to put in the inventory if picked up

	
	/*
	 private Inventory _bag;


	// When the player interacts with the item
	/*
	public override void Interact()
	{
		base.Interact();

		PickUp();
	}
	*/

	// Pick up the item
	public void PickUp ()
	{
		Debug.Log("Picking up " + item.name);
		Inventory.instance.AddItem(item);	// Add to inventory	
		Destroy(gameObject);
	}

	public void Destroyitem()
	{
		Destroy(gameObject);	// Destroy item from scene
	}

}
