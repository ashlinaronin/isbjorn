using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BearAnimationScript : MonoBehaviour
{

    public Rigidbody rigidBody;
    Animator bearAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bearAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidBody == null) return;

        float speed = rigidBody.velocity.magnitude;
        bearAnimator.SetFloat("speed", speed / 5);
    }
}
