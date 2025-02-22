using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConveyorBelt;

public class BeltItem : MonoBehaviour
{
    public ItemType itemType;
    public ColorType itemColor;
    public int currentWaypoint;
    public ConveyorBelt belt;

    #region enums
    public enum ItemType
    {
        Button,
        Syringe
    }
    public enum ColorType
    {
        None,
        Red,
        Blue,
        Yellow,
        Green
    }
    #endregion enums
}
