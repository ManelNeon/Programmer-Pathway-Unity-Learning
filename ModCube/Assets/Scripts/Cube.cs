using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    Vector3 originalScale;

    float speed = 80;
    
    void Start()
    {
        originalScale = transform.localScale;

        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        StartCoroutine(PositionChange());

        StartCoroutine(ScaleChange());
    }
    
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 0.0f, 0.0f);
    }

    IEnumerator PositionChange()
    {
        while (true)
        {
            if (transform.position.z != -7)
            {
                speed += 10;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                speed = 10;
                transform.position = new Vector3(transform.position.x, transform.position.y, 7);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }

    IEnumerator ScaleChange()
    {
        while (true)
        {
            if (transform.localScale == originalScale)
            {
                transform.localScale = Vector3.one * 2.3f;
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                transform.localScale = originalScale;
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}
