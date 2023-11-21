using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private float pipeSpeed = 1.5f;

    void Update()
    {
        this.transform.Translate(pipeSpeed * Time.deltaTime * Vector3.left);
    }
}
