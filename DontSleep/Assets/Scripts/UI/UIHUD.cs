using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHUD : MonoBehaviour
{
    #region Fields
    public Text timeText;
    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        timeText.text = ((int)Timer.Instance.time / 1000).ToString();
    }
}
