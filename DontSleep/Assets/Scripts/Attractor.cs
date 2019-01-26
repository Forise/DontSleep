using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Attractor : MonoBehaviour
{
    const float G = 667.4f; //Gravity const
    [SerializeField]
    private float gravityStrenght; 

    public static List<Attractor> Attractors;

    public Rigidbody rb;

    private void Awake()
    {
        Init();
    }

    private void FixedUpdate()
    {
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    private void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
    }

    private void OnDisable()
    {
        Attractors.Remove(this);
    }

    private void Init()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    private void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = 0f;
        switch (GameplayManager.Instance.gameMod)
        {
            case GameMod.Hard:
                forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
                break;
            case GameMod.Easy:
                forceMagnitude = G * (rb.mass * rbToAttract.mass) * gravityStrenght / 100f;
                break;
        }
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force.x, rbToAttract.transform.position.y, force.z);
    }
}
