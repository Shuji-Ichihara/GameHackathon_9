using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charamove : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Run());
        }
    }

    IEnumerator Run()
    {
        anim.SetBool("isRun", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isRun", false);
    }
}
