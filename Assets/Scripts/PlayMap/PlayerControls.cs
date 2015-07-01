using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerControls : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
	public MoveToDestination2D PlayerMover;
	public Player PlayerScript;
	public GameObject borderMinus;
	public GameObject borderPlus;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnNewPointerData(PointerEventData eventData){
		if (!PlayerScript.IsDazed) {
			Vector2 newDestination = eventData.position;
			if (newDestination.x > borderPlus.transform.position.x) {
				newDestination.x = borderPlus.transform.position.x;
			} else if (newDestination.x < borderMinus.transform.position.x) {
				newDestination.x = borderMinus.transform.position.x;
			}
			if (newDestination.y > borderPlus.transform.position.y) {
				newDestination.y = borderPlus.transform.position.y;
			} else if (newDestination.y < borderMinus.transform.position.y) {
				newDestination.y = borderMinus.transform.position.y;
			}
		
			PlayerMover.Destination2D = newDestination;
		}
	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		OnNewPointerData (eventData);
	}
	#endregion

	#region IDragHandler implementation
	public void OnDrag(PointerEventData eventData)
	{
		OnNewPointerData (eventData);
	}
	#endregion

	#region IEndDragHandler implementation

	void IEndDragHandler.OnEndDrag (PointerEventData eventData)
	{
		PlayerMover.Active = false;
	}

	#endregion
}
