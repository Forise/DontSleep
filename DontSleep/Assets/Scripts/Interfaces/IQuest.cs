using UnityEngine;
public interface IQuest
{
    float Progress
    { get; set; }

    bool IsCompleted
    {
        get;
    }

    void Begin();

    void Finish();
}