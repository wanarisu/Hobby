using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
	/// <summary>
	/// カメラの距離の名前用 enum型
	/// </summary>
	public enum CAMERA_POSITION_NAME
	{
		eFIRST_PERSON,			// 一人称視点
		eSHORT_DISTANCE,		// 三人称視点(近距離)
		eMEDIUM_DISTANCE,       // 三人称視点(中距離)
		eLONG_DISTANCE,         // 三人称視点(遠距離)
	}

	[SerializeField, Tooltip("カメラを置きたい位置")] private Transform[] Camera_SpecifiedPositions;

	/// <summary>
	/// カメラのポジション指示
	/// </summary>
	/// <param name="cpn"> 移動したい位置 </param>
	public void CameraPositionIndication(CAMERA_POSITION_NAME cpn)
	{
		transform.parent = Camera_SpecifiedPositions[(int)cpn];
		transform.localPosition = Vector3.zero;
		transform.localPosition = Vector3.zero;
	}
}
