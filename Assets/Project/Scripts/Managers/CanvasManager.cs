using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    public Image healthIndicator;
    public Sprite health1; // максимальное здоровье
    public Sprite health2;
    public Sprite health3;
    public Sprite health4; // мёртв

    public GameObject redKey;
    public GameObject greenKey;
    public GameObject blueKey;

    private static CanvasManager _instace;
    public static CanvasManager Instace {  get { return _instace; } }

    private void Awake()
    {
        if(_instace != null && _instace != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instace = this;
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
        if(healthValue >= 66)
        {
            healthIndicator.sprite = health1;
        }

        if(healthValue < 66 && healthValue >= 33)
        {
            healthIndicator.sprite = health2;
        }

        if (healthValue < 33)
        {
            healthIndicator.sprite = health3;
        }

        if (healthValue <= 0)
        {
            healthIndicator.sprite = health4;
        }
    }

    public void UpdateKeys(string keyColor)
    {
        if(keyColor == "red")
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

    public void ClearKeys()
    {
        redKey.SetActive(false);
        greenKey.SetActive(false);
        blueKey.SetActive(false);
    }
}
