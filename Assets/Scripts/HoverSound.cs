using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSound : MonoBehaviour
{
   public void PlayHoverSound()
   {
      GetComponent<AudioSource>().Play();
   }
}
