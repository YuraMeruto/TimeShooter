using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posteffect : MonoBehaviour {

    public Material monotone;
    void OnRenderImage(RenderTexture src,RenderTexture dest)
    {
        Graphics.Blit(src,dest,monotone);
    }

 public   void Setenabled( bool Is)
    {
        GetComponent<Posteffect>().enabled = Is;
    }
}
