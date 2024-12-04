using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public bool isRedKey, isBlueKey, isGreenKey;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioController.instance.PlayKeyGrab();
            if (isRedKey)
            {
                other.GetComponent<PlayerInventory>().hasRed = true;
                CanvasManager.Instance.UpdateKeys("red");
            }
            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().hasBlue = true;
                CanvasManager.Instance.UpdateKeys("blue");
            }
            if (isGreenKey)
            {
                other.GetComponent<PlayerInventory>().hasGreen = true;
                CanvasManager.Instance.UpdateKeys("green");
            }

            Destroy(gameObject);
        }
    }
}
