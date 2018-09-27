using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image currentHealthBar;
    public Text ratioText;

    private float healthPoint = 100;
    private float maxHealthPoints = 100;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = healthPoint / maxHealthPoints;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }
    private void TakeDamage(float damage)
    {
        healthPoint -= damage;
        
        if (healthPoint < 0)
        {
            healthPoint = 0;
            Application.LoadLevel(2);
        }
        UpdateHealthBar();
    }

    private void HealDamage(float heal)
    {
        healthPoint += heal;
        if (healthPoint > maxHealthPoints)
        {
           healthPoint = maxHealthPoints;
        }
        UpdateHealthBar();
    }
}
