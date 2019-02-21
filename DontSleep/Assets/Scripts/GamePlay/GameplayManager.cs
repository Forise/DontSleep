using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoSingleton<GameplayManager>
{
    public delegate void StartLevelDelegate(int level);
    public event StartLevelDelegate StartLevelEvent;

    public delegate void EndLevelDelegate(int level);
    public event EndLevelDelegate EndLevel;

    public GameMod gameMod;
    [SerializeField]
    private List<QuestLevel> levels = new List<QuestLevel>();
    [SerializeField]
    private List<QuestObject> questObjects = new List<QuestObject>();
    private int currentLevel = 0;

    public List<QuestLevel> Levels
    {
        get => levels;
    }

    public List<QuestObject> QuestObjects
    {
        get => questObjects;
    }

    void Start()
    {
        StartLevel(currentLevel);
    }

    private void StartLevel(int index)
    {
        foreach(var q in questObjects)
        {
            q.SetQuest(levels[currentLevel].quests.Find(x => x.title == q.gameObject.name));
        }
        StartLevelEvent(currentLevel);
    }
    //TODO: Add EndLevel
}

public enum GameMod
{
    Easy,
    Hard
}