using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //karakterin hareket etmesi icin kullanilan kod
    private Animator anim;
    private bool isMoving = false;
    private int posIndex = 0; //bu degisken karakterin sag veya sola gitmesini sinirlandirir
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && !isMoving && posIndex > -1)
        {
            posIndex--;
            StartCoroutine(MoveLock());
            StartCoroutine(MoveLerp(transform.position, transform.position + Vector3.left * 2.5f, 0.2f));
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving && posIndex < 1)
        {
            posIndex++;
            StartCoroutine(MoveLock());
            StartCoroutine(MoveLerp(transform.position, transform.position + Vector3.right * 2.5f, 0.2f));
        }
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            StartCoroutine(AnimIntReset());
            anim.SetInteger("moveIndex", 1);
        }
        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            StartCoroutine(AnimIntReset());
            anim.SetInteger("moveIndex", 2);
        }
    }
    //karakterin yumusak hareket etmesi icin lerp kullanilan kisim
    IEnumerator MoveLerp(Vector3 startPos, Vector3 endPos, float endTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + endTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (Time.time - startTime) / endTime);
            yield return null;
        }
        transform.position = endPos;
    }
    //karakterin hareket etmesi sirasinda tekrar hareket etmemesi icin kullanilan kisim
    IEnumerator MoveLock()
    {
        isMoving = true;
        yield return new WaitForSeconds(0.2f);
        isMoving = false;
    }
    IEnumerator AnimIntReset()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetInteger("moveIndex", 0);
    }
}
