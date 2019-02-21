using UnityEngine;

public class QuestObject : AInteractableObject, IQuest
{
    public delegate void OnQuestCompleteDelegate();
    public event OnQuestCompleteDelegate OnQuestComplete;

    public delegate void OnProgressAddedDelegate();
    public event OnProgressAddedDelegate OnProgressAdded;

    #region Fields
    [SerializeField]
    private float minDistanceFromPlayer = 1f;
    [SerializeField]
    private float distance = 0;
    private GameObject player;
    [SerializeField]
    private Quest quest = new Quest();
    private bool isCompleted;
    public Color disabledColor;
    public Color defaultColor;
#endregion

#region Properties
    public float Progress
    {
        get => quest.progress; 
        set
        {
            quest.progress = value;
            if(quest.progress >= quest.maxProgress)
                Finish();
        }
    }

    public bool IsCompleted
    {
        get => isCompleted;
        private set => isCompleted = value;
    }

    public string Name { get => quest.title; private set => quest.title = value; }
#endregion

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update() 
    {
        if(!IsCompleted)
            CalculateDistanceToPlayer();
    }

    public override void OnClick()
    {
        if(!IsCompleted)
        {
            if (distance <= minDistanceFromPlayer)
            {
                Progress++;
                OnProgressAdded?.Invoke();
            }
        }
    }

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
        Begin();
    }

#region Methods
    public void Begin()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        IsCompleted = false;
        Progress = 0;
        SetColor(defaultColor);
    }

    public void Finish()
    {
        IsCompleted = true;
        SetColor(disabledColor);
        OnQuestComplete?.Invoke();
        //TODO: Subscribe on it in Gameplay Manager and check AllQuestsComplete?=>EndLevel?.Invoke();
    }

    public float CalculateDistanceToPlayer()
    {
        //var distance = Vector3.Distance(player.transform.position, transform.position);
        ///it should be faster =)
        if(player)
            distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2));
        return distance;
    }

    ///maybe should switch material?
    public void SetColor(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
#endregion
}