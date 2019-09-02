using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAgent : MonoBehaviour
{
    public readonly int hashIdleSpeed = Animator.StringToHash("IdleSpeed");
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat(hashIdleSpeed, Random.Range(0.9f, 1.2f));
    }
}
