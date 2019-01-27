using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class AInteractableObject : MonoBehaviour, IInteractable 
{
    protected Collider col;

    protected virtual void Awake() 
    {
        if(col == null)
            col = GetComponent<Collider>();   
    }
    protected virtual void OnMouseDown() 
    {
        OnClick();
    }

    public abstract void OnClick();
}