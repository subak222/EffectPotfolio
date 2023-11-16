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
    [SerializeField]
    private VisualEffect auraDeath;

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
            VisualEffect auras = Instantiate(aura, spawnPosition, Quaternion.identity);
            auras.Play();
            Destroy(auras.gameObject, 15f);
            Invoke("Shoot", 8f);
            StartCoroutine(Charging());
        }
    }

    public void Shoot()
    {
        animator.SetBool("isReady", false);
        
    }

    IEnumerator Charging()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 1.4f, 1.5f);
        VisualEffect chargings = Instantiate(charging, spawnPosition, Quaternion.identity);
        chargings.Play();
        Destroy(chargings.gameObject, 8f);

        yield return new WaitForSeconds(8f);
        VisualEffect auraDeaths = Instantiate(auraDeath, spawnPosition, Quaternion.identity);
        auraDeaths.Play();
    }
}
