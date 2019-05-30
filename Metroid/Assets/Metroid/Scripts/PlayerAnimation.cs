using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    Animator anim = null;
    float lookX = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //movement = this.gameObject.GetComponent<PlayerMovement>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.0f;

        // Walk Left/Right
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            speed = 1.0f;
            lookX = 1.0f;
        }

        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            speed = 1.0f;
            lookX = -1.0f;
        }

        anim.SetFloat("Speed", speed);
        anim.SetFloat("Look X", lookX);
    }
}
