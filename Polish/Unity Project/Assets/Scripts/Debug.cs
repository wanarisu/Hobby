using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Debug : MonoBehaviour
{
	public struct Private_Debug
	{
		public object _class;
		public Type type;

		public Private_Debug(object valume)
		{
			this._class = valume;
			this.type = _class.GetType();
		}
	}

	private Private_Debug Debug_Camera;
	private Private_Debug Debug_playerControl;

	private Text text;

	private string endl { get { return "\n"; } }

	private void Start()
	{
		Debug_Camera = new Private_Debug(Camera.main.GetComponent<Camera_Control>());
		Debug_playerControl = new Private_Debug(GameObject.Find("Player").GetComponent<PlayerControl>());

		text = GetComponent<Text>();
	}
	void Update()
    {
		#region カメラ移動
		if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			Get_PrivateMethod(Debug_Camera, "CameraPositionIndication", new object[1] { Camera_Control.CAMERA_POSITION_NAME.eFIRST_PERSON});
		}
		if(Input.GetKeyDown(KeyCode.Keypad1))
		{
			Get_PrivateMethod(Debug_Camera, "CameraPositionIndication", new object[1] { Camera_Control.CAMERA_POSITION_NAME.eSHORT_DISTANCE });
		}
		if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			Get_PrivateMethod(Debug_Camera, "CameraPositionIndication", new object[1] { Camera_Control.CAMERA_POSITION_NAME.eMEDIUM_DISTANCE });
		}
		if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			Get_PrivateMethod(Debug_Camera, "CameraPositionIndication", new object[1] { Camera_Control.CAMERA_POSITION_NAME.eLONG_DISTANCE });
		}
		#endregion

		#region テキスト表示
		float move_Z = Input.GetAxis("Left Stick Vertical");
		float move_X = Input.GetAxis("Left Stick Horizontal");
		Vector3 volumeOfMove = Vector3.zero;
		Camera_Control cameraController = (Camera_Control)Get_PrivateValume(Debug_playerControl,"cameraController");
		volumeOfMove += cameraController.transform.forward * move_Z;
		volumeOfMove += cameraController.transform.right * move_X;

		Transform playerTransform = (Transform)Get_PrivateValume(Debug_playerControl, "playerTransform");
		text.text  = "L_Stick_Z  : " + move_Z.ToString("f3") + endl;
		text.text += "L_Stick_X  : " + move_X.ToString("f3") +endl;
		text.text += "Player_Dir : " + TextToVector3(playerTransform.forward,"f3") + endl;
		text.text += "Move_Dir   : " + TextToVector3(volumeOfMove, "f3") + endl + endl;

		text.text += "Camera_Speed : " + (float)Get_PrivateValume(Debug_playerControl,"cameraRotateSpeed");
		#endregion
	}

	/// <summary>
	/// Vector3のテキスト化
	/// </summary>
	/// <param name="temp"> 変換したい Vector3 </param>
	/// <param name="wordCount"> 埋め文字指定、文字数指定 </param>
	/// <returns> ストリング化変更 </returns>
	private String TextToVector3(Vector3 temp, String wordCount)
	{
		return '(' + temp.x.ToString(wordCount) + ',' + temp.y.ToString(wordCount) + ',' + temp.z.ToString(wordCount) + ')';
	}

	private object Get_PrivateValume(Private_Debug pd,string fieldName)
	{
		return pd.type.GetField(fieldName, BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(pd._class);
	}
	private object Get_PrivateMethod(Private_Debug pd, string methodName,object[] argument)
	{
		return pd.type.GetMethod(methodName, BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(pd._class, argument);
	}
}
