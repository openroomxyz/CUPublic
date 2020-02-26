using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Compute : MonoBehaviour
{
    public ComputeShader  compute_shader;
    private RenderTexture result_render_texture;
    private RenderTexture input_render_texture;

    public Color color;

    int cycle = 0;
    int shoot_counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        MLib.RenderTextureTools.RenderTextureFromPNGImageAt(Application.dataPath + "Assets/1400.png", 1024 * 4,out input_render_texture); 
    }

    
    bool bip = false;
    Vector2 shootCordinates = Vector2.zero;
    public void ShootEvent(Vector2 pos)
    {
        shootCordinates = pos;
        bip = true;
        shoot_counter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(bip)
        {
            bip = false;
            RUN();
        }

        //RUN();
        if (Input.GetKeyDown(KeyCode.R))
        {
            RUN();
        }
    }

    private void OnDestroy()
    {
        if(result_render_texture != null)
        {
            result_render_texture.Release();
        }
    }
    void RUN()
    {

        
        int resolution = 1024 * 4;
        int kernel = compute_shader.FindKernel("CSMain");

        if (result_render_texture == null)
        {
            result_render_texture = new RenderTexture(resolution, resolution, 24);
            result_render_texture.enableRandomWrite = true;
            result_render_texture.Create();
        }

        Color colorR = Random.ColorHSV();
        Vector4 pp = new Vector4(shootCordinates.x * resolution, shootCordinates.y * resolution, 3.0f, 4.0f);

        
        if(shoot_counter % 2 == 0)
        {
            compute_shader.SetTexture(kernel, "Result", result_render_texture);
            compute_shader.SetTexture(kernel, "InputTexA", input_render_texture);

        }
        else
        {
            compute_shader.SetTexture(kernel, "Result", input_render_texture);
            compute_shader.SetTexture(kernel, "InputTexA", result_render_texture);
        }

        compute_shader.SetVector("color", colorR);
        compute_shader.SetVector("position", pp);
        compute_shader.Dispatch(kernel, resolution / 8, resolution / 8, 1);

        
        //displaying the result
        Renderer rend = GetComponent<Renderer>();
        MLib.BuildInMaterialsTools.HDR.Lit.SetBaseColorMap(ref rend, in result_render_texture);
        
        cycle += 1;
    }

    
}
