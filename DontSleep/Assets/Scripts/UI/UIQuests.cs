using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuests : MonoBehaviour
{
    public UIQuest uiQuestPrefab;
    public List<QuestLevel> levels = new List<QuestLevel>();
    private List<Quest> quests = new List<Quest>();

    private void Start()
    {
        ReadQuests(1);
        GenerateQuests();
    }

    public void GenerateQuests()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            var newQuest = Instantiate(uiQuestPrefab, transform);
            (newQuest.transform as RectTransform).localPosition = new Vector2((newQuest.transform as RectTransform).localPosition.x, -(newQuest.transform as RectTransform).rect.height * i);
            newQuest.nameText.text = quests[i].title;
            newQuest.descriptionText.text = quests[i].description;
            newQuest.progressBar.maxValue = quests[i].target;
            newQuest.progressBar.value = quests[i].progress;
        }
    }

    public void ReadQuests(int level)
    {
        quests = levels[level - 1].quests;
    }
}
