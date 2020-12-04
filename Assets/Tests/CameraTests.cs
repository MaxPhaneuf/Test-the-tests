using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityTemplateProjects;

namespace Tests1
{
    public class CameraTests
    {
        public SimpleCameraController camController;
        
        [OneTimeSetUp]
        public void Setup()
        {
            camController = CreateCamController();
        }

        private SimpleCameraController CreateCamController()
        {
            GameObject go = new GameObject("CamController");
            return go.AddComponent<SimpleCameraController>();
        }
        
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CameraSetTransformTest()
        {
            var t = new GameObject().transform;
            t.position = new Vector3(1, 1, 1);
            var rot = new Quaternion();
            rot.eulerAngles = new Vector3(45, 45, 45);
            t.rotation = rot;
            camController.m_TargetCameraState.SetFromTransform(t);
            camController.m_TargetCameraState.UpdateTransform(camController.transform);
            Assert.AreEqual(t.position, camController.transform.position);
            Assert.AreEqual(t.rotation.eulerAngles, camController.transform.rotation.eulerAngles);
            yield return null;
        }
    }
}