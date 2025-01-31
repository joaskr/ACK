using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackholeSkill : Skill
{
    [SerializeField] private UI_SkillTreeSlot blackholeUnlockButton;
    public bool blackholeUnlocked { get; private set; }
    [SerializeField] private int amountOfAttacks;
    [SerializeField] private float cloneCooldown;
    [SerializeField] private float blackholeDuration;
    [Space]
    [SerializeField] private GameObject blackholePrefab;
    [SerializeField] private float maxSize;
    [SerializeField] private float growSpeed;
    [SerializeField] private float shrinkSpeed;

    BlackHoleSkillController currentBlackhole;


    protected override void CheckUnlock()
    {
        UnlockBlackHole();
    }
    private void UnlockBlackHole ()
    {
        if(blackholeUnlockButton.unlocked)
        {
            blackholeUnlocked = true;
        }
    }
    public override bool CanUseSkill()
    {
        return base.CanUseSkill();
    }

    public override void UseSkill()
    {
        base.UseSkill();
        GameObject newBlackhole = Instantiate(blackholePrefab, player.transform.position, Quaternion.identity);
        currentBlackhole = newBlackhole.GetComponent<BlackHoleSkillController>();
        currentBlackhole.SetupBlackhole(maxSize, growSpeed, shrinkSpeed, amountOfAttacks, cloneCooldown, blackholeDuration);
        AudioManager.instance.PlaySfx(6, player.transform);
    }

    protected override void Start()
    {
        base.Start();
        blackholeUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockBlackHole);
    }

    protected override void Update()
    {
        base.Update();
    }
    public bool SkillCompleted()
    {
        if (!currentBlackhole)
            return false;

        if (currentBlackhole.playerCanExitState) 
        {
            currentBlackhole = null;
            return true;
        }

        return false;
    }
}
