using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour
{
    public void AnimationCallback()
        => Destroy(gameObject);
}
