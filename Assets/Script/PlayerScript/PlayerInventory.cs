using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    public bool hasRed, hasGreen, hasBlue;
    public static bool hasShotGun;

    private void Start()
    {
        CanvasManager.Instance.ClearKeys();
    }
}
