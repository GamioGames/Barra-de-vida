using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    [Range(0,5)]
    [SerializeField] private float barSpeed = 1f;
    [SerializeField] private Image healtBar;
    [SerializeField] private Image healtBarShadow;

    private float nextHealth;
    private bool activeShadowHealth = false;

    private void Awake()
    {
        healtBar.fillAmount = 1f;
        healtBarShadow.fillAmount = healtBar.fillAmount;
        nextHealth = healtBar.fillAmount;
    }

    private void Update()
    {
        if (healtBar.fillAmount != nextHealth)
        {
            healtBar.fillAmount = Mathf.MoveTowards(healtBar.fillAmount, nextHealth, Time.deltaTime * barSpeed);
        }
    
        if (activeShadowHealth)
        {
            healtBarShadow.fillAmount = Mathf.MoveTowards(healtBarShadow.fillAmount, nextHealth, Time.deltaTime * barSpeed * 1.7f);
        }
        if(healtBarShadow.fillAmount == nextHealth) activeShadowHealth = false;
    }

    IEnumerator ActiveShadowHealth()
    {
        yield return new WaitForSeconds(0.2f);
        activeShadowHealth = true;
    }

    public void SetHealth(float healthPercentage)
    {
        nextHealth = healthPercentage;
        StartCoroutine(ActiveShadowHealth());
    }
}
