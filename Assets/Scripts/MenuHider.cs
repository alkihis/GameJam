using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MenuHider : MonoBehaviour
{
    public GameObject canvas;
    private Animator animator;

    private float progress = 0.0f;
    private readonly float FADEIN_TIME = 1.0f;
    private bool finishedFadeIn = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        var data = animator.GetCurrentAnimatorStateInfo(0);
        if (data.normalizedTime >= 1 && !finishedFadeIn)
        {
            canvas.SetActive(true);
            canvas.transform.position += Vector3.up * 100;
            finishedFadeIn = true;
        }
    }
}
