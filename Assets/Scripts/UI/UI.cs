using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour, ISaveManager
{
    [SerializeField] private UI_FadeScreen FadeScreen;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject restartButton;
    [Space]
    [SerializeField] private GameObject characterUI;
    [SerializeField] private GameObject skillTreeUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject inGameUI;
    public UI_StatTooltip statToolTip;
    public UI_SkillToolTip skillToolTip;

    [SerializeField] private UI_volumeSlider[] volumeSettings;

    private void Awake()
    {
        //SwitchTo(skillTreeUI);
        FadeScreen.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchTo(inGameUI);
        statToolTip.gameObject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SwitchWithKeyTo(characterUI);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchWithKeyTo(skillTreeUI);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchWithKeyTo(optionsUI);
        }
    }
    public void SwitchTo(GameObject _menu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {

            bool fadeScreen = transform.GetChild(i).GetComponent<UI_FadeScreen>() != null;
            if(fadeScreen == false)
                transform.GetChild(i).gameObject.SetActive(false);

            
        }
        if (_menu != null)
        {
            AudioManager.instance.PlaySfx(7, null);
            _menu.SetActive(true);
        }
        if(GameManager.instance != null)
        {
            if (_menu == inGameUI)
                GameManager.instance.PauseGame(false);
            else 
                GameManager.instance.PauseGame(true);
        }
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            CheckForInGameUI();
            return;
        }
        SwitchTo(_menu);
    }

    private void CheckForInGameUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf && transform.GetChild(i).GetComponent<UI_FadeScreen>() == null)
                return;
        }
        SwitchTo(inGameUI);
    }
    public void SwitchOnEndScreen()
    {
        FadeScreen.FadeOut();
        StartCoroutine(EndScreenCoroutine());

    }
    IEnumerator EndScreenCoroutine()
    {
        yield return new WaitForSeconds(1);
        endText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        restartButton.SetActive(true);
    }

    public void RestartGameButton() => GameManager.instance.RestartScene();

    public void LoadData(GameData _data)
    {
        foreach(KeyValuePair<string,float> pair in _data.volumeSettings)
        {
            foreach(UI_volumeSlider item in volumeSettings)
            {
                if (item.parameter == pair.Key)
                    item.LoadSlider(pair.Value);
            }
        }
    }

    public void SaveData(ref GameData _data)
    {
        _data.volumeSettings.Clear();
        foreach(UI_volumeSlider item in volumeSettings)
        {
            _data.volumeSettings.Add(item.parameter, item.slider.value);
        }
    }
}
