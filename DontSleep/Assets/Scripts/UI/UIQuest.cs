using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIQuest : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
    public Slider progressBar;
    public Image checkIcon;
    public QuestObject quest;

    private void Start()
    {
        quest.OnProgressAdded += UpdateProgress;
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void SetDescription(string description)
    {
        descriptionText.text = description;
    }

    public void SetProgress(int progress)
    {
        progressBar.value = progress;
    }

    public void AddProgress(int progress)
    {
        progressBar.value += progress;
    }

    void UpdateProgress()
    {
        SetProgress((int)quest.Progress);
        if (progressBar.value >= progressBar.maxValue)
            checkIcon.gameObject.SetActive(true);
    }
}
