using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SkillToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skillText;
    [SerializeField] private TextMeshProUGUI skillName;
    public void ShowTooltip(string _skillDescription, string _skillName)
    {
        skillName.text = _skillName;
        skillText.text = _skillDescription;
        gameObject.SetActive(true);
    }
    public void HideTooltip() => gameObject.SetActive(false);

}
