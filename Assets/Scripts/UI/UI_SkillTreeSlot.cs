using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SkillTreeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private UI ui;
    [SerializeField] private string skillName;
    [TextArea]
    [SerializeField] private string skillDescription;
    [SerializeField] private Color lockedSkillColor;
    public bool unlocked;
    [SerializeField] private UI_SkillTreeSlot[] shouldBeUnlocked;
    [SerializeField] private UI_SkillTreeSlot[] shouldBeLocked;

    [SerializeField] private int skillPrice;
    private Image skillImage;

    private void OnValidate()
    {
        gameObject.name = "SkillTreeSlot_UI - " + skillName;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => UnlockSkillSlot());
        
    }

    private void Start()
    {
        skillImage = GetComponent<Image>();
        ui = GetComponentInParent<UI>();
        skillImage.color = lockedSkillColor;
    }
    public void UnlockSkillSlot()
    {
        if (PlayerManager.instance.HaveEnoughMoney(skillPrice) == false)
            return;
        for (int i = 0; i < shouldBeUnlocked.Length; i++)
        {
            if (shouldBeUnlocked[i].unlocked == false)
            {
                return;
            }
        }
        for (int i = 0; i < shouldBeLocked.Length; i++)
        {
            if (shouldBeLocked[i].unlocked == true)
            {
                return;
            }
        }
        unlocked = true;
        skillImage.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.skillToolTip.ShowTooltip(skillDescription, skillName);
        Vector2 mousePosition = Input.mousePosition;
        float xOffset = 0;
        float yOffset = 0;
        if (mousePosition.x > 600)
            xOffset = -150;
        else
            xOffset = 150;
        if (mousePosition.y > 320)
            yOffset = -150;
        else
            yOffset = 150;
        ui.skillToolTip.transform.position = new Vector2(mousePosition.x + xOffset, yOffset);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ui.skillToolTip.HideTooltip();
    }
}
