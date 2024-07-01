using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneSkill : Skill
{
    [Header("Clone info")]
    [SerializeField] private float attackMultiplier;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [Space]
    [Header("Clone attack")]
    [SerializeField] private UI_SkillTreeSlot cloneAttackUnlockButton;
    [SerializeField] private float cloneAttackMultiplier;
    [SerializeField] private bool canAttack;
    [Header("Aggresive clone")]
    [SerializeField] private UI_SkillTreeSlot aggressiveCloneUnlockButton;
    [SerializeField] private float aggressiveCloneAttackMultiplier;

    [Header("Multiple clone")]
    [SerializeField] private bool canDuplicateClone;
    [SerializeField] private float chanceToDuplicate;
    [SerializeField] private float multiCloneAttackMultiplier;
    [SerializeField] private UI_SkillTreeSlot multipleCloneUnlockButton;
    public bool canApplyOnHitEffect { get; private set; }


    protected override void Start()
    {
        base.Start();


        cloneAttackUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockCloneAttack);
        aggressiveCloneUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockAggresiveClone);
        multipleCloneUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockMultiClone);
    }

    private void UnlockCloneAttack()
    {
        if (cloneAttackUnlockButton.unlocked)
        {
            canAttack = true;
            attackMultiplier = cloneAttackMultiplier;
        }
    }

    private void UnlockAggresiveClone()
    {
        if (aggressiveCloneUnlockButton.unlocked)
        {
            canApplyOnHitEffect = true;
            attackMultiplier = aggressiveCloneAttackMultiplier;
        }
    }

    private void UnlockMultiClone()
    {
        if (multipleCloneUnlockButton.unlocked)
        {
            canDuplicateClone = true;
            attackMultiplier = multiCloneAttackMultiplier;
        }
    }



    public void CreateClone(Transform _clonePosition, Vector3 _offset)
    {
        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<Clone_Skill_Controller>().
              SetupClone(_clonePosition, cloneDuration, canAttack, _offset, FindClosestEnemy(newClone.transform), canDuplicateClone, chanceToDuplicate, player, attackMultiplier);
    }



    public void CreateCloneWithDelay(Transform _enemyTransform)
    {

            StartCoroutine(CloneDelayCoroutine(_enemyTransform, new Vector3(2 * player.facingDir, 0)));
    }
    private IEnumerator CloneDelayCoroutine(Transform _transform, Vector3 _offset)
    {
        yield return new WaitForSeconds(.4f);
            CreateClone(_transform, _offset);
    }
}
