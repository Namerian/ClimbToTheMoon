using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollisionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Rock"))
        {
            //Debug.Log("Collision with Rock!");
            EventManager.Instance.SendOnRockCollisionEvent();
        }
    }
}
