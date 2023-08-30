using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;


    [Header("Buttons")]
    public GameObject combatPanelExitButton;
    public GameObject gameOverButton;


    [Header("CombatPanel")]
    public GameObject combatMonsterSprite;
    public GameObject combatPanel;
    public TextMeshProUGUI combatText;

    private int maxLines = 5;
    private int lineCount = 0;
    public GameObject scrollbarVertical;


    private void Start()
    {
        _gameManager = GameObject.Find(nameof(GameManager)).GetComponent<GameManager>();
    }

    public void B_Map()
    {
        
    }

    public void CombatActive(Sprite monsterSprite)
    {
        combatMonsterSprite.GetComponent<Image>().sprite = monsterSprite;
        combatPanel.SetActive(true);
        
    }

    public void OutputCombatText(string name1, string name2, int name1power, int name2currentHP)
    {
        if (name2currentHP < 0)
        {
            name2currentHP = 0;
        }

        lineCount++;

        string currentText = combatText.text;
        string newCombatInfo = name1 + "(��)��" + name1power + " �� �������� �������ϴ�. " + name2 + "�� ���� HP = " + name2currentHP;
        string updatedText = currentText + "\n" + newCombatInfo;

        combatText.text = updatedText;


        if (lineCount > maxLines)
        {
            ScrollCombatText();
        }

    }

    public void TestCombat()
    {

        OutputCombatText("player", "monster", 5, 5);
    }

    public void CombatPlayerWinText(string monsterName)
    {
        lineCount++;

        string currentText = combatText.text;
        string newCombatInfo = "��簡 " + monsterName + "(��)�� ���񷶽��ϴ�!";
        string updatedText = currentText + "\n" + newCombatInfo;

        combatText.text = updatedText;

        if (lineCount > maxLines)
        {
            ScrollCombatText();
        }

    }

    public void CombatMonsterWinText()
    {
        lineCount++;

        string currentText = combatText.text;
        string newCombatInfo = "����� ������ ���������ϴ�..";
        string updatedText = currentText + "\n" + newCombatInfo;

        combatText.text = updatedText;

        if (lineCount > maxLines)
        {
            ScrollCombatText();
        }
    }

    private void ScrollCombatText()
    {
        RectTransform contentRectTransform = combatText.transform.parent.GetComponent<RectTransform>();
        contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, contentRectTransform.sizeDelta.y + 50f);

        scrollbarVertical.GetComponent<Scrollbar>().value = 0f;
    }

    public void ClearCombatText()
    {
        combatText.text = "";
        lineCount = 0;
    }

}