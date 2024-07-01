using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashSkill : Skill
{
    [Header("Dash")]
    [SerializeField] private UI_SkillTreeSlot dashunlockButton;
    public bool dashUnlocked { get; private set; }
    [Header("clone on Dash")]
    [SerializeField] private UI_SkillTreeSlot cloneOnDashUnlockButton;
    public bool cloneOnDashUnlocked { get; private set; }
    [Header("clone on Arival")]
    [SerializeField] private UI_SkillTreeSlot cloneOnArrivalUnlockButton;
    public bool cloneOnArrivalUnlocked { get; private set; }
    protected override void Start()
    {
        dashunlockButton.GetComponent<Button>().onClick.AddListener(UnlockDahs);
        cloneOnDashUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockCloneOnDash);
        cloneOnArrivalUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockCloneOnArrival);
    }
    public override void UseSkill()
    {
        base.UseSkill();

    }

    private void UnlockDahs()
    {
        if(dashunlockButton.unlocked)
            dashUnlocked = true;
    }
    private void UnlockCloneOnDash()
    {
        if(cloneOnDashUnlockButton.unlocked)    
            cloneOnDashUnlocked = true;
    }
    private void UnlockCloneOnArrival()
    {
        if(cloneOnArrivalUnlockButton.unlocked)
            cloneOnArrivalUnlocked = true;
    }

    public void CreateCloneOnDashStart()
    {
        if (cloneOnDashUnlocked)
        {
            SkillManager.instance.clone.CreateClone(player.transform, Vector3.zero);
        }
    }

    public void CreateCloneOnDashOver()
    {
        if (cloneOnArrivalUnlocked)
        {
            SkillManager.instance.clone.CreateClone(player.transform, Vector3.zero);
        }
    }
}
