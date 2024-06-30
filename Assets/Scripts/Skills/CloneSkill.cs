using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : Skill
{
    [Header("Clone info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [Space]
    [SerializeField] private bool canAttack;
    [SerializeField] private bool canCreateCloneOnCounter;
    public void CreateClone(Transform _clonePosition, Vector3 _offset)
    {
        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<CloneSkillController>().SetupClone(_clonePosition, cloneDuration, canAttack, _offset);
    }



    public void CreateCloneOnCounter(Transform _enemyTransform)
    {
        if (canCreateCloneOnCounter)
        {
            StartCoroutine(CreateCloneWithDelay(_enemyTransform, new Vector3(2 * player.facingDir, 0)));
        }
    }
    private IEnumerator CreateCloneWithDelay(Transform _transform, Vector3 _offset)
    {
        yield return new WaitForSeconds(.4f);
            CreateClone(_transform, _offset);
    }
}
