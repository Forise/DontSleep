using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuests : MonoBehaviour
{
    public UIQuest uiQuestPrefab;
    private List<Quest> quests = new List<Quest>();

    private void Start()
    {
        GameplayManager.Instance.StartLevelEvent += InitLevel;
    }

    private void InitLevel(int i)
    {
        ClearQuests();
        SetQuests(GameplayManager.Instance.Levels[i]);
        GenerateQuests();
    }

    public void GenerateQuests()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            var newQuest = Instantiate(uiQuestPrefab, transform);
            (newQuest.transform as RectTransform).localPosition = new Vector2((newQuest.transform as RectTransform).localPosition.x, -(newQuest.transform as RectTransform).rect.height * i);
            newQuest.SetName(quests[i].title);
            newQuest.SetDescription(quests[i].description);
            newQuest.progressBar.maxValue = quests[i].target;
            newQuest.progressBar.value = quests[i].progress;
            newQuest.quest = GameplayManager.Instance.QuestObjects.Find(x => x.Name == quests[i].title);
        }
    }

    private void ClearQuests()
    {
        foreach(var q in GetComponentsInChildren<UIQuest>())
        {
            Destroy(q.gameObject);
        }
    }

    public void SetQuests(QuestLevel questLevel)
    {
        quests = questLevel.quests;
    }
}
