using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGeneric : MonoBehaviour
{
    private float range = 1.1f;
    private Vector3 offset = new Vector3(0, 1f, 0);
    private Animator animator;
    private bool isGrounded;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + offset, -Vector3.up);
        Debug.DrawLine(transform.position + offset, transform.position + offset - Vector3.up * range, Color.red);

        // Detecta si está en el suelo
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.gameObject.layer == 7)  // Asegúrate que la capa 7 es 'Walkable'
            {
                isGrounded = true;
                animator.SetBool("isOnGround", true);
            }
            else
            {
                isGrounded = false;
                animator.SetBool("isOnGround", false);
            }
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isOnGround", false);
        }

        // Si está en el suelo, puede correr
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            // Si no está en el suelo, no puede correr
            animator.SetBool("isRunning", false);
        }

        // Si se presiona la barra espaciadora y está en el suelo, puede saltar
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("isJumping", true);
            isGrounded = false;  // Al saltar, deja de estar en el suelo
            animator.SetBool("isOnGround", false);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
