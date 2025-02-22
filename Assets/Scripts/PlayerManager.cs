using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BeltItem;

public class PlayerManager : MonoBehaviour
{
    [Header("Main:")]
    public List<BeltItem> itemsInRange = new();

    [Header("Config:")]
    public KeyCode interactKey = KeyCode.Space;

    [Header("Referenced Scripts:")]
    public PlayerMovement playerMovement;

    private void Start()
    {
        if (playerMovement == null)
            playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            // If there is an item in range
            if (itemsInRange.Count > 0)
            {
                BeltItem closestItem = itemsInRange[0];
                float closestDistance = Vector2.Distance(itemsInRange[0].transform.position, transform.position);

                foreach (BeltItem item in itemsInRange)
                {
                    float itemDistance = Vector2.Distance(item.transform.position, transform.position);
                    if (itemDistance < closestDistance)
                    {
                        closestItem = item;
                        closestDistance = itemDistance;
                    }
                }
            }
        }
    }
}
