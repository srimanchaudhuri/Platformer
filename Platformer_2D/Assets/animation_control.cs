using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_control : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Update is called once per frame

    private float horizontalInput;
    private new Transform transform;

    private void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0) animator.SetFloat("inMotion", 1f);
        else animator.SetFloat("inMotion", -1f);

        if (horizontalInput < 0) transform.eulerAngles = new Vector3(0, -270, 0);
        if (horizontalInput > 0) transform.eulerAngles = new Vector3(0, -90, 0);
    }
    }