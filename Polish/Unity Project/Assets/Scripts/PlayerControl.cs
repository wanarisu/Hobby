using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : CharacterBase
{
	[SerializeField, Tooltip("カメラの情報")] private Camera_Control cameraController;
	[SerializeField, Tooltip("カメラの回転軸")] private Transform cameraPivod;
	[SerializeField, Tooltip("プレイヤー本体のトランスフォーム")] private Transform playerTransform;

	private Camera_Control.CAMERA_POSITION_NAME nowPosition;
	private float cameraRotateSpeed;

	private void Start()
	{
		nowPosition = Camera_Control.CAMERA_POSITION_NAME.eFIRST_PERSON;
		Set_CameraRotateSpeed(nowPosition);
	}

	private void Update()
	{
		float move_Z = Input.GetAxis("Left Stick Vertical");
		float move_X = Input.GetAxis("Left Stick Horizontal");

		// 移動
		Vector3 volumeOfMove = Vector3.zero;
		volumeOfMove += cameraController.transform.forward * move_Z;
		volumeOfMove += cameraController.transform.right * move_X;
		transform.position += volumeOfMove * Get_MoveSpeed;

		// 横移動入力あるとき
		if(volumeOfMove != Vector3.zero)
		{
			playerTransform.forward = Vector3.Lerp(playerTransform.forward, volumeOfMove, Get_RotateSpeed);
		}

		//// 回転
		Vector3 VolumeOfRotate = new Vector3(0.0f, Input.GetAxis("Right Stick Horizontal") * cameraRotateSpeed, 0.0f);
		cameraPivod.Rotate(VolumeOfRotate);

		if(Input.GetButtonDown("LB"))
		{
			if(nowPosition < Camera_Control.CAMERA_POSITION_NAME.eLONG_DISTANCE)
			{
				nowPosition++;
			}
			else
			{
				nowPosition = Camera_Control.CAMERA_POSITION_NAME.eFIRST_PERSON;
			}
			cameraController.CameraPositionIndication(nowPosition);
			Set_CameraRotateSpeed(nowPosition);
		}
	}

	/// <summary>
	/// カメラの回転速度設定(カメラの位置でスピード変える)
	/// </summary>
	/// <param name="posName"> カメラの位置の名前 </param>
	private void Set_CameraRotateSpeed(Camera_Control.CAMERA_POSITION_NAME posName)
	{
		cameraRotateSpeed = Get_RotateSpeed * 10.0f * ((float)posName + 1.0f) * GameMaster.GameSpeed;
	}
}
