using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowScript : MonoBehaviour
{
    Camera attachedCamera;
    public Shader Post_Outline;
    public Shader glowShader;
    Camera tempCam;
    Material Post_Mat;
    void Start()
    {
        attachedCamera = GetComponent<Camera>();
        tempCam=new GameObject().AddComponent<Camera>();
        tempCam.enabled=false;
        Post_Mat = new Material(Post_Outline);
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //set up temporary camera
        tempCam.CopyFrom(attachedCamera);
        tempCam.clearFlags=CameraClearFlags.Color;
        tempCam.backgroundColor=Color.black;
        //cull any layer that isn't the outline
        tempCam.cullingMask=1<<LayerMask.NameToLayer("Outline");
        //make the temporary rendertexture
        RenderTexture TempRT = new RenderTexture(source.width,source.height,0,RenderTextureFormat.R8);
        //put it to video memory
        TempRT.Create();
        //set the camera's target texture when rendering
        tempCam.targetTexture=TempRT;
        //render all objects this camera can render, but with the GlowShader
        tempCam.RenderWithShader(glowShader,"");
        //copy the temporary RT to the final image
        Graphics.Blit(TempRT,destination);
        //release the temp RT
        TempRT.Release();
    }
}
