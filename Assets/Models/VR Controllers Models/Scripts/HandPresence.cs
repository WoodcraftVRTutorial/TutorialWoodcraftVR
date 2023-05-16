//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR;


//public class HandPresence : MonoBehaviour
//{
//    public bool showController = false;
//    public bool showHands = false;
//    public InputDeviceCharacteristics controllerCharacteristics;
//    public InputDeviceRole deviceRole;
//    public List<GameObject> controllerPrefabs;
//    public GameObject handModelPrefab;
//    private InputDevice targetDevice;
//    private GameObject spawnedController;
//    private GameObject spawnedHandModel;
//    private Animator handAnimator;
//    private string tempName; 
//    private string headsetBrandName;

//    void Start()
//    {
//        AppManager.Instance.IdentifyDevice();
//        TryInitialize();
//    }

//    void Awake()
//    {

//        TryInitialize();

//    }
//    void TryInitialize()
//    {
//        List<InputDevice> devices = new List<InputDevice>();
//        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

//        foreach (var item in devices)
//        {
//            Debug.Log("Controller: " + item.name + " " + item.characteristics);
//            Debug.Log("test: " + item.characteristics.ToString());
//            //        }

//            //       if (devices.Count > 0)
//            //        {
//            targetDevice = devices[0];
//            Debug.Log("Tracked: " + targetDevice.name);
//            if(item.name.Contains("Oculus"))
//            {
//                headsetBrandName = "Oculus";
//            }
//            else if (item.name.Contains("Pico"))
//            {
//                headsetBrandName = "Pico";
//            }

//            tempName = targetDevice.name;

//            if (AppManager.Instance.headsetName.ToString().Equals("Oculus Quest") || AppManager.Instance.headsetName.ToString().Equals("Oculus Link Quest"))
//            {
//                if (targetDevice.name == "Oculus Touch Controller - Left" || item.characteristics.ToString().Contains("Left") )
//                {
//                    tempName = "Oculus Quest Controller - Left";
//                }
//                else if (targetDevice.name.ToString().Equals("Oculus Touch Controller - Right") || item.characteristics.ToString().Contains("Right"))
//                {
//                    tempName = "Oculus Quest Controller - Right";
//                }
//            }

//            GameObject prefab = controllerPrefabs.Find(controller => controller.name == tempName);

//            if (prefab)
//            {
//                spawnedController = Instantiate(prefab, transform);
//                Debug.Log("Spawned: " + prefab.name);
//            }
//            else
//            {
//                Debug.LogError("Did not find controller model");
//                spawnedController = Instantiate(controllerPrefabs[0], transform);
//            }
//                spawnedHandModel = Instantiate(handModelPrefab, transform);
//                handAnimator = spawnedHandModel.GetComponent<Animator>();
//        }
//    }
//    void Update()
//    {
//        if (!targetDevice.isValid)
//        {
//            TryInitialize();
//        }
//        else
//        {
//            if (showController)
//            {
//                spawnedController.SetActive(true);
//            }
//            else
//            {
//                spawnedController.SetActive(false);
//            }

//           if (showHands)
//            {
//                spawnedHandModel.SetActive(true);
//                Debug.Log("hands on: " + showHands);
//                UpdateHandAnimation();
//            }
//            else
//            {
//                spawnedHandModel.SetActive(false);
//            }

//        }
//    }

//    void UpdateHandAnimation()
//    {
//        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
//        {
//            handAnimator.SetFloat("Trigger", triggerValue);
//        }
//        else
//        {
//            handAnimator.SetFloat("Trigger", 0);
//        }

//        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
//        {
//            handAnimator.SetFloat("Grip", gripValue);
//        }
//        else
//        {
//            handAnimator.SetFloat("Grip", 0);
//        }
//    }

//}
