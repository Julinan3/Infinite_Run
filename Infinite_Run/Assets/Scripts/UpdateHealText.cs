using UnityEngine;
using UnityEngine.UI;
//TakeDamage scriptindeki heal degiskenini texte yazdirmak icin kullanilan kod
public class UpdateHealText : MonoBehaviour
{
    public Text healText;
    private void Awake()
    {
        healText.text = "Heal: " + TakeDamage.heal;
    }
    public void Update()
    {
        if(TakeDamage.heal < 0)
        {
            TakeDamage.heal = 0;
        }
        healText.text = "Heal: " + (int)TakeDamage.heal;
    }
}
