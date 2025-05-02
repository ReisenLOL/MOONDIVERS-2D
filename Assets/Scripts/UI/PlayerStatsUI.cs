using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    public TextMeshProUGUI weaponNameText;
    public TextMeshProUGUI magAmountText;
    public TextMeshProUGUI bulletAmountText;
    public void UpdateWeaponName(string weaponName)
    {
        weaponNameText.text = weaponName;
    }
    public void UpdateMagAmount(int loadedAmount, int capacity)
    {
        magAmountText.text = "Mags: " + loadedAmount + "/" + capacity;
    }
    public void UpdateBulletAmount(int loadedAmount, int capacity)
    {
        bulletAmountText.text = "Bullets: " + loadedAmount + "/" + capacity;
    }
}
