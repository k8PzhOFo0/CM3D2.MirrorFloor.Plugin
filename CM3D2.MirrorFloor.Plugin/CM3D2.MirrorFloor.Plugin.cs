using System;
using UnityEngine;
using UnityInjector;
using UnityInjector.Attributes;

namespace CM3D2.MirrorFloor.Plugin
{
    [PluginFilter("CM3D2x64"),
    PluginFilter("CM3D2x86"),
    PluginFilter("CM3D2VRx64"),
    PluginName("Mirror Floor"),
    PluginVersion("1.0.0.0")]
    public class MirrorFloor : PluginBase
    {
        private GameObject mirror;
        private float speed = 0.01f;

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this);
        }

        private void OnLevelWasLoaded(int level)
        {
            if (level == 5)
            {
                Material mirrorMaterial = new Material(Shader.Find("Mirror"));

                mirror = GameObject.CreatePrimitive(PrimitiveType.Plane);
                mirror.transform.localScale = new Vector3(0.3f, 1f, 0.3f);

                mirror.renderer.material = mirrorMaterial;
                //mirror.layer = 4;
                mirror.AddComponent<MirrorReflection2>();
                MirrorReflection2 mirrorRefleftion2 = mirror.GetComponent<MirrorReflection2>();
                mirrorRefleftion2.m_TextureSize = 2048;
                mirrorRefleftion2.m_ClipPlaneOffset = 0f;
                mirror.renderer.enabled = false;
                //mirror.renderer.enabled = true;
            }
        }

        private void Update()
        {
            if (Application.loadedLevel != 5)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                mirror.renderer.enabled = !mirror.renderer.enabled;
            }

            //if (Input.GetKey(KeyCode.Keypad4))
            //{
            //    mirror.transform.localScale -= Vector3.right * Time.deltaTime * speed;
            //}
            //if (Input.GetKey(KeyCode.Keypad6))
            //{
            //    mirror.transform.localScale += Vector3.right * Time.deltaTime * speed;
            //}
            //if (Input.GetKey(KeyCode.Keypad2))
            //{
            //    mirror.transform.localScale -= Vector3.forward * Time.deltaTime * speed;
            //}
            //if (Input.GetKey(KeyCode.Keypad8))
            //{
            //    mirror.transform.localScale += Vector3.forward * Time.deltaTime * speed;
            //}
            //if (Input.GetKey(KeyCode.Keypad3))
            //{
            //    mirror.transform.position -= Vector3.up * Time.deltaTime * speed;
            //    Console.WriteLine(mirror.transform.position.ToString("F4"));
            //}
            //if (Input.GetKey(KeyCode.Keypad9))
            //{
            //    mirror.transform.position += Vector3.up * Time.deltaTime * speed;
            //    Console.WriteLine(mirror.transform.position.ToString("F4"));
            //}
        }
    }
}