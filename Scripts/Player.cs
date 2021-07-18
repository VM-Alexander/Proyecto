using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad;
    public LayerMask ObjetoSolidoLayer;
    public LayerMask HierbaLayer;

    public event Action OnEncountered;

    public bool SeMueve;
    private Vector2 input;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        if (!SeMueve)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0)
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(EsCaminable(targetPos))
                    StartCoroutine(Mover(targetPos));
            }
        }

        animator.SetBool("SeMueve", SeMueve);
    }

    IEnumerator Mover(Vector3 targetPos)
    {
        SeMueve = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, velocidad * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        SeMueve = false;

        CheckForEncouters();
    }

    private bool EsCaminable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, ObjetoSolidoLayer) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncouters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.1f, HierbaLayer) != null)
        {
            if (UnityEngine.Random.Range(1, 101)<=10)
            {
                animator.SetBool("SeMueve", false);
                OnEncountered();
            }

        }
    }
}
