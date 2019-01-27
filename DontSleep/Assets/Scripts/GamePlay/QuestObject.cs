using UnityEngine;

public class QuestObject : AInteractableObject, IQuest
{
#region Fields
    [SerializeField]
    private float minDistanceFromPlayer = 1f;
    [SerializeField]
    private float distance = 0;
    private GameObject player;
    [SerializeField]
    private string name;
    [SerializeField]
    private float maxProgress;
    [SerializeField]
    private float currentProgress = 0;
    private bool isCompleted;
    public Color disabledColor;
    public Color defaultColor;
#endregion

#region Properties
    public float Progress
    {
        get => currentProgress; 
        set
        {
            currentProgress = value;
            if(currentProgress >= maxProgress)
                Finish();
        }
    }

    public bool IsCompleted
    {
        get => isCompleted;
        private set => isCompleted = value;
    }

    public string Name { get => name; private set => name = value; }
#endregion

    protected override void Awake()
    {
        base.Awake();
        Begin();
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
            if(distance <= minDistanceFromPlayer)
                Progress++;
        }
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
    }

    public float CalculateDistanceToPlayer()
    {
        //var distance = Vector3.Distance(player.transform.position, transform.position);
        ///it should be faster =)
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