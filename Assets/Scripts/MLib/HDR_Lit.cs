using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLib.BuildInMaterialsTools.HDR
{
        public class Lit
        {
            public static void SetBaseColorMap(ref Renderer renderer,in RenderTexture render_texture)
            {
                renderer.material.SetTexture("_BaseColorMap", render_texture);
            }
        }

        //rend.sharedMaterial.SetTexture("_BaseColorMap", result);
}