using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private VisualEffect aura;
    [SerializeField]
    private VisualEffect charging;

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
            VisualEffect visualEffectInstance = Instantiate(aura, spawnPosition, Quaternion.identity);
            visualEffectInstance.Play();
            Destroy(visualEffectInstance.gameObject, 15f);
            Invoke("Shoot", 80f);
            StartCoroutine(Charging());
        }
    }

    public void Shoot()
    {
        animator.SetBool("isReady", false);
        
    }

    IEnumerator Charging()
    {
        yield return null;
        Vector3 spawnPosition = transform.position + new Vector3(0, 1.4f, 1.5f);
        VisualEffect visualEffectInstance = Instantiate(charging, spawnPosition, Quaternion.identity);
        visualEffectInstance.Play();
        Destroy(visualEffectInstance.gameObject, 15f);
    }
}
