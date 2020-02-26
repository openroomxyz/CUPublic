using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLib
{
    public class RenderTextureTools
    {
        //PUBLIC
        public static void RenderTextureFromPNGImageAt(string path, int resolution,out RenderTexture renderTexture)
        {
            Texture2D tex2D = MLib.RenderTextureTools.LoadPNG(path);
            MLib.RenderTextureTools.ConveretTexture2dIntoRenderTexture(out renderTexture, in tex2D, resolution);
        }

        public static void Save(string path, RenderTexture renderTexture)
        {
            byte[] bytes = toTexture2D(renderTexture).EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }

        //PRIVAT
        private static Texture2D LoadPNG(string filePath)
        {

            Texture2D tex = null;
            byte[] fileData;

            if (System.IO.File.Exists(filePath))
            {
                fileData = System.IO.File.ReadAllBytes(filePath);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            }
            return tex;
        }

        private  static void ConveretTexture2dIntoRenderTexture(out RenderTexture out_renderTexture, in Texture2D input_texture2d, int resolution)
        {
            //int resolution = 1024 * 4;
            // texRef is your Texture2D
            // You can also reduice your texture 2D that way
            out_renderTexture = new RenderTexture(resolution, resolution, 0);
            out_renderTexture.enableRandomWrite = true;
            RenderTexture.active = out_renderTexture;
            // Copy your texture ref to the render texture
            Graphics.Blit(input_texture2d, out_renderTexture);

            // Now you can read it back to a Texture2D if you care
            /*
            if (inputT == null)
                inputT = new Texture2D(inputTex.width, inputTex.height, TextureFormat.RGBA32, true);
            inputT.ReadPixels(new Rect(0, 0, inputTex.width, inputTex.height), 0, 0, false);
            */

        }


        private static Texture2D toTexture2D(RenderTexture rTex)
        {
            int widht = rTex.width;
            int height = rTex.height;

            Texture2D tex = new Texture2D(widht, height, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
        }

        
    }
}
