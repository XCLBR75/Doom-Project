using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    public Image healthIndicator;
    public GameObject pistol;
    public GameObject shotGun;

    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;

    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;

    private static CanvasManager _instance;
    public static CanvasManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void UpdateHealth(int healthValue)
    {
        health.text = healthValue.ToString() + "%";
        UpdateHealthIndicator(healthValue);
    }

    public void UpdateArmor(int armorValue)
    {
        armor.text = armorValue.ToString() + "%";
    }

    public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }

    public void UpdateHealthIndicator(int healthValue)
    {
        if ( healthValue >= 66)
        {
            healthIndicator.sprite = health1;
        }
        else if (healthValue < 66 && healthValue >= 33)
        {
            healthIndicator.sprite = health2;
        }
        else if (healthValue < 33 && healthValue > 0)
        {
            healthIndicator.sprite = health3;
        }
        else if (healthValue == 0)
        {
            healthIndicator.sprite = health4;
        }
    }

    public void UpdateKeys(string keyColor)
    {
        if (keyColor == "red")
        {
            redKey.SetActive(true);
        }
        if (keyColor == "green")
        {
            greenKey.SetActive(true);
        }
        if (keyColor == "blue")
        {
            blueKey.SetActive(true);
        }
    }

    public void UpdatePistol()
    {
        shotGun.SetActive(false);
        pistol.SetActive(true);
    }

    public void UpdateShotGun()
    {
        pistol.SetActive(false);
        shotGun.SetActive(true);
    }

    public void ClearKeys()
    {
        redKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);
    }
}
