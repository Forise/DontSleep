using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quests", menuName = "UI/Quests"), System.Serializable]
public class QuestLevel : ScriptableObject
{
    [SerializeField]
    public List<Quest> quests = new List<Quest>();
}