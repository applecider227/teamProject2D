using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
  void OnCollisionEnter2D(Collision2D collision)
  {
      if(collision.collider.tag == "New tag")
      {
         thePlayer.transform.position = teleportTarget.transform.position; 
      }
  }
}
