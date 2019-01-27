using UnityEngine;

public class Bed : MonoBehaviour
{
    private Attractor attractor;
    [SerializeField]
    private float growingSpeed;

    private void Awake()
    {
        attractor = GetComponent<Attractor>();
        if(!attractor)
            Debug.LogWarning("Attractor is NULL! Check the component!", this);
    }

    private void Update()
    {
        if(attractor)
            attractor.rb.mass += Time.fixedUnscaledDeltaTime * growingSpeed;
    }
}