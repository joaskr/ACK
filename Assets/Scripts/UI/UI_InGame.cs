using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Image dashImage;
    [SerializeField] private Image parryImage;
    [SerializeField] private Image swordImage;
    [SerializeField] private Image blackholeImage;
    [SerializeField] private TextMeshProUGUI currentSouls;

    private SkillManager skills;
    // Start is called before the first frame update
    void Start()
    {
        skills = SkillManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        currentSouls.text = PlayerManager.instance.getCurrentCurrency().ToString("#,#");
        if(Input.GetKeyDown(KeyCode.LeftShift) && skills.dash.dashUnlocked) 
        {
            SetCooldownOf(dashImage);
        }
        if (Input.GetKeyDown(KeyCode.Q) && skills.parry.parryUnlocked)
        {
            SetCooldownOf(parryImage);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && skills.sword.swordUnlocked)
        {
            SetCooldownOf(swordImage);
        }
        if (Input.GetKeyDown(KeyCode.R) && skills.blackhole.blackholeUnlocked)
        {
            SetCooldownOf(blackholeImage);
        }
        CheckCooldownOf(dashImage, skills.dash.cooldown);
        CheckCooldownOf(parryImage, skills.parry.cooldown);
        CheckCooldownOf(swordImage, skills.sword.cooldown);
        CheckCooldownOf(blackholeImage, skills.blackhole.cooldown);
    }
    private void SetCooldownOf(Image _image)
    {
        if(_image.fillAmount <= 0)
            _image.fillAmount = 1;
    }

    private void CheckCooldownOf(Image _image, float _cooldown)
    {
        if(_image.fillAmount > 0)
        {
            _image.fillAmount -= 1 / _cooldown * Time.deltaTime;
        }
    }
}
