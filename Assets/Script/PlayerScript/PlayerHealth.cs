using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    private int health;

    public int maxArmor;
    private int armor;

    public GameObject overPanel;
    void Start()
    {
        health = maxHealth;
        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(30);
            Debug.Log("Player has been damaged");
        }
    }

    public void DamagePlayer(int damage)
    {
        AudioController.instance.PlayHurt();
        if (armor > 0)
        {
            if (armor >= damage)
            {
                armor -= damage;
            }
            else if (armor < damage)
            {
                int remainingDamage;
                remainingDamage = damage - armor;
                armor = 0;
                health -= remainingDamage;
            }
        }
        else
        {
            health -= damage;
        }

        if (health <= 0)
        {
            overPanel.SetActive(true);
        }

        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }

    public void GiveHealth(int amount, GameObject pickup)
    {
        if (health < maxHealth)
        {
            AudioController.instance.PlayHealth();
            health += amount;
            Destroy(pickup);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        CanvasManager.Instance.UpdateHealth(health);
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if (armor < maxArmor)
        {
            AudioController.instance.PlayArmor();
            armor += amount;
            Destroy(pickup);
        }

        if (armor > maxArmor)
        {
            armor = maxArmor;
        }

        CanvasManager.Instance.UpdateArmor(armor);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetArmor()
    {
        return armor;
    }

}
