using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider hpSlider;
    public Slider enemySlider;
        
    public void SetHUD (Unit unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetEnemyHUD (Unit unit)
    {
        enemySlider.maxValue = unit.maxHP;
        enemySlider.value = unit.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
    
    public void SetEnenmyHP(int hp)
    {
        enemySlider.value = hp;
    }
}
