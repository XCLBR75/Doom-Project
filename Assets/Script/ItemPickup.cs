using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isHealth;
    public bool isArmor;
    public bool isAmmo;

    public bool isShotGun;
    public int amount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isHealth)
            {
                other.GetComponent<PlayerHealth>().GiveHealth(amount, this.gameObject);
            }

            if (isArmor)
            {
                other.GetComponent<PlayerHealth>().GiveArmor(amount, this.gameObject);
            }

            if (isAmmo)
            {
                other.GetComponentInChildren<Gun>().GiveAmmo(amount, this.gameObject);
            }
            if (isShotGun)
            {
                PlayerInventory.hasShotGun = true;
                Destroy(gameObject, AudioController.instance.PlayGunPickUp());
            }
        }
    }



}
