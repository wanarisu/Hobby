using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{
	private Camera_Control DebugCamera;

	private void Start()
	{
		DebugCamera = Camera.main.GetComponent<Camera_Control>();
	}
	void Update()
    {
		if(Input.GetKeyDown(KeyCode.Keypad0))
		{
			DebugCamera.CameraPositionIndication((Camera_Control.CAMERA_POSITION_NAME)0);
		}
		if(Input.GetKeyDown(KeyCode.Keypad1))
		{
			DebugCamera.CameraPositionIndication((Camera_Control.CAMERA_POSITION_NAME)1);
		}
		if(Input.GetKeyDown(KeyCode.Keypad2))
		{
			DebugCamera.CameraPositionIndication((Camera_Control.CAMERA_POSITION_NAME)2);
		}
		if(Input.GetKeyDown(KeyCode.Keypad3))
		{
			DebugCamera.CameraPositionIndication((Camera_Control.CAMERA_POSITION_NAME)3);
		}
	}

	private int Get_Number()
	{
		switch(Input.inputString)
		{
			case "Key.pad0":
				return 0;
			case "Key.pad1":
				return 1;
			case "Key.pad2":
				return 2;
			case "Key.pad3":
				return 3;
			case "Key.pad4":
				return 4;
			case "Key.pad5":
				return 5;
			case "Key.pad6":
				return 6;
			case "Key.pad7":
				return 7;
			case "Key.pad8":
				return 8;
			case "Key.pad9":
				return 9;
			case "Alpha0":
				return 0;
			case "Alpha1":
				return 1;
			case "Alpha2":
				return 2;
			case "Alpha3":
				return 3;
			case "Alpha4":
				return 4;
			case "Alpha5":
				return 5;
			case "Alpha6":
				return 6;
			case "Alpha7":
				return 7;
			case "Alpha8":
				return 8;
			case "Alpha9":
				return 9;
			default:
				break;
		}

		return 99;
	}
}
