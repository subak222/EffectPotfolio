using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private VisualEffect visualEffectPrefab;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isReady", false);
    }

    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            animator.SetBool("isReady", true);
            Vector3 spawnPosition = transform.position + new Vector3(0, 0.1f, 0);
            VisualEffect visualEffectInstance = Instantiate(visualEffectPrefab, spawnPosition, Quaternion.identity);
            visualEffectInstance.Play();
            Destroy(visualEffectInstance.gameObject, 6.5f);
            Invoke("Shoot", 5f);
        }
    }

    public void Shoot()
    {
        animator.SetBool("isReady", false);
        
    }
}
