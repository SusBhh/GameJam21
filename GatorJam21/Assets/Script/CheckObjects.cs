using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjects : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.parent = transform;
        transform.root.GetComponent<GameManagerSc>().GetState = State.Shorten;
    }
}
