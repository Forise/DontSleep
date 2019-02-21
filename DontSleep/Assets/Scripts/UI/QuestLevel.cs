using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quests", menuName = "/Quests"), System.Serializable]
public class QuestLevel : ScriptableObject
{
    [SerializeField]
    public List<Quest> quests = new List<Quest>();
}