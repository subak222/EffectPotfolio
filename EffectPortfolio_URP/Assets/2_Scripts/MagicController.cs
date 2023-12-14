using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MagicController : MonoBehaviour
{
    [SerializeField]
    private Animator animatorSword;
    [SerializeField]
    private VisualEffect ground;

    void Start()
    {
        animatorSword = GetComponent<Animator>();
        animatorSword.SetBool("Sword", false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Cube());
    }

    IEnumerator Cube()
    {
        if (Input.GetKeyUp("e"))
        {
            animatorSword.SetBool("Sword", true);
            yield return new WaitForSeconds(0.1f);
            animatorSword.SetBool("Sword", false);
            yield return new WaitForSeconds(3.4f);
            Vector3 spawnPosition = transform.position + new Vector3(-5f, 0.1f, 0);
            VisualEffect grounds = Instantiate(ground, spawnPosition, Quaternion.identity);
            grounds.Play();
        }
        
    }
}
