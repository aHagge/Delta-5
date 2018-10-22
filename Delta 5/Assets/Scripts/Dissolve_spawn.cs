using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve_spawn : MonoBehaviour {

    public MaterialPropertyBlock DissolveMat;
    public Renderer rd;
    public float amount;

    private void Start()
    {
        amount = 1;
        StartCoroutine(Spawn());
        DissolveMat = new MaterialPropertyBlock();
        rd = GetComponent<Renderer>();   
    }

    private void Update()
    {
        rd.GetPropertyBlock(DissolveMat);
        DissolveMat.SetFloat("Vector1_4A8D28BA", amount);
        rd.SetPropertyBlock(DissolveMat);
    }
    IEnumerator Spawn()
    {
        if(amount > -1.1)
        {
            yield return new WaitForSeconds(0.02f);
            amount -= 0.02f;
            StartCoroutine(Spawn());
        }
        
    }
}
