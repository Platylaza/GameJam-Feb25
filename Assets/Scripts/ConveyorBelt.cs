using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BeltItem;

public class ConveyorBelt : MonoBehaviour
{
    [Header("Main:")]
    public List<BeltItem> items = new();
    public List<Transform> waypoints = new();

    [Header("Config:")]
    public float speed = 10;

    [Header("Layout:")]
    public ConveyorBelt otherBelt;
    public Transform itemsHolder;
    public Transform waypointsHolder;

    [ContextMenu("AssignVariables();")]
    public void AssignVariables()
    {
        // If no items were assigned in inspector, add them from the itemsHolder obj
        if (items.Count == 0)
            for (int i = 0; i < itemsHolder.childCount; i++)
            {
                BeltItem item = itemsHolder.GetChild(i).GetComponent<BeltItem>();
                items.Add(item);
                item.belt = this;
            }

        // If no waypoints were assigned in inspector, add them from the waypointsHolder obj
        if (waypoints.Count == 0)
            for (int i = 0; i < waypointsHolder.childCount; i++)
                waypoints.Add(waypointsHolder.GetChild(i));
    }

    // FixedUpdate() runs 50 times per second
    private void FixedUpdate()
    {
        // Move the items across the conveyor belt
        foreach (BeltItem item in items)
        {
            if (item.transform.position == waypoints[item.currentWaypoint].transform.position)
            {
                MoveItem(item);
                break;
            }
            else
                item.transform.position = Vector2.MoveTowards(item.transform.position, waypoints[item.currentWaypoint].transform.position, speed);
        }
    }

    private void MoveItem(BeltItem item)
    {
        if (item.currentWaypoint < waypoints.Count - 1)
        {
            // If it should still be moving
            item.currentWaypoint++;
        }
        else
        {
            // If it needs to go to the other belt
            items.Remove(item);
            otherBelt.ReceiveItem(item.gameObject);
        }
    }
    private void ReceiveItem(GameObject itemObj)
    {
        BeltItem item = itemObj.GetComponent<BeltItem>();

        items.Add(item);

        item.transform.position = waypoints[0].position;
        item.currentWaypoint = 0;

        item.transform.parent = itemsHolder;
    }

}
