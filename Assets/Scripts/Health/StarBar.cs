using UnityEngine;
using UnityEngine.UI;

public class StarBar : MonoBehaviour
{
    [SerializeField] private PlayerThrow playerThrow;
    [SerializeField] private Image totalCooldown;
    [SerializeField] private Image currentCooldown;
    [SerializeField] private Image avalibleIndicator;

    private void Start()
    {
        totalCooldown.fillAmount = playerThrow.cooldownTimer / playerThrow.attackCooldown;
    }
    private void Update()
    {
        currentCooldown.fillAmount = playerThrow.cooldownTimer / playerThrow.attackCooldown;

        if(playerThrow.throwScript.isThrown == false && playerThrow.throwScript.hitGround == false)
        {
            avalibleIndicator.color = Color.red;
        }
        else if(playerThrow.throwScript.isThrown == true && playerThrow.throwScript.hitGround == false)
        {
            avalibleIndicator.color = Color.yellow;
        }
        else if(playerThrow.throwScript.isThrown == true)
        {
            avalibleIndicator.color = Color.green;
        }
    }
}