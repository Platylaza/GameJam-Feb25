using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BeltItem;

public class PlayerManager : MonoBehaviour
{
    [Header("Main:")]
    public BeltItem[] items;

    [Header("Config:")]
    public KeyCode interactKey = KeyCode.Space;
    public float interactionDistance;

    [Header("Testing:")]
    public Transform interactionZone;

    [Header("Referenced Scripts:")]
    public PlayerMovement playerMovement;

    private void Start()
    {
        if (playerMovement == null)
            playerMovement = GetComponent<PlayerMovement>();

        items = FindObjectsByType<BeltItem>(FindObjectsSortMode.InstanceID);
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            // If there are items
            if (items.Length > 0)
            {
                BeltItem closestItem = null;
                float closestDistance = 1000;

                // Get closest item
                foreach (BeltItem item in items)
                {
                    float itemDistance = Vector2.Distance(item.transform.position, transform.position);
                    if ( itemDistance < closestDistance)
                    {
                        closestItem = item;
                        closestDistance = itemDistance;
                    }
                }

                // If the closest item is within interaction range
                if (closestItem != null && closestDistance <= interactionDistance)
                {
                    Debug.Log($"Interacted with {closestItem.gameObject.name}!");
                }
            }
        }

        if (interactionZone.gameObject.activeInHierarchy)
            interactionZone.localScale = new Vector3(interactionDistance / transform.localScale.x, interactionDistance / transform.localScale.y, 1) * 1.75f;
    }
}
