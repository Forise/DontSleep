using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Collider col;
    public float stranght = 1f;

    private void Awake()
    {
        Init();
    }

    private void FixedUpdate()
    {
        DetectClick();
    }

    private void Init()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        if (col == null)
            col = GetComponent<Collider>();
    }

    private void DetectClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("RAY!");
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("RAYCAST: ");
                if (hit.collider != null)
                {
                    //Debug.Log("---> Hit: ");
                    Vector3 direction = hit.point - rb.position;
                    rb.AddForce(direction.normalized * stranght, ForceMode.Impulse);
                }
            }
        }
    }
}
