using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //生命值
    public Image healthPointImage;//主血条
    public Image healthPointEffect;//缓降血条
    public Image Enemyhealthpoint;//敌人血条
    private Fox Fox;
    //耐力条
    public Image endurancePointImage;//耐力条
    private void Awake()
    {
         Fox=GameObject.FindGameObjectWithTag("Fox").GetComponentInParent<Fox>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthPointImage.fillAmount = Fox.Red / Fox.MaxRed;
        if (healthPointEffect.fillAmount > healthPointImage.fillAmount)
        {
            healthPointEffect.fillAmount -= 0.003f;
        }
        else { healthPointEffect.fillAmount = healthPointImage.fillAmount; }
       endurancePointImage.fillAmount=Fox.balance/Fox.Maxbalance;
       Enemyhealthpoint.fillAmount=Fox.Red / Fox.MaxRed;
    }
    
}