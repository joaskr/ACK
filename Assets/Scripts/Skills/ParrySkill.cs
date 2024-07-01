using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParrySkill : Skill
{
    [Header("Parry")]
    [SerializeField] private UI_SkillTreeSlot parryUnlockButton;
    public bool parryUnlocked {  get; private set; }
    [Header("Parry restore")]
    [SerializeField] private UI_SkillTreeSlot restoreUnlockButton;
    public bool restoreUnlocked { get; private set; }
    [Header("Parry mirage")]
    [SerializeField] private UI_SkillTreeSlot parryMirageUnlockButton;
    [Range(0f, 1f)]
    [SerializeField] private float restoredHealthAmount;
    public bool parryMirageUnlocked { get; private set; }
    public override void UseSkill()
    {
        base.UseSkill();
        if (restoreUnlocked)
        {
            int restoredAmount = Mathf.RoundToInt(player.stats.GetMaxHealthValue() * restoredHealthAmount);
            player.stats.IncreaseHealthBy(restoredAmount);

        }
    }
    protected override void Start()
    {
        base.Start();
        parryUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParry);
        restoreUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParryRestore);
        parryMirageUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParryMirage);
    }

    protected override void CheckUnlock()
    {
        UnlockParry();
        UnlockParryRestore();
        UnlockParryMirage();
    }
    private void UnlockParry()
    {
        if (parryUnlockButton.unlocked)
            parryUnlocked = true;
    }
    private void UnlockParryRestore()
    {
        if (restoreUnlockButton.unlocked)
            restoreUnlocked = true;
    }
    private void UnlockParryMirage()
    {
        if (parryMirageUnlockButton.unlocked)
            parryMirageUnlocked = true;
    }

    public void MakeMirageOnParry(Transform _respawnTransform)
    {
        if (parryMirageUnlocked)
            SkillManager.instance.clone.CreateCloneWithDelay(_respawnTransform);
    }
}

