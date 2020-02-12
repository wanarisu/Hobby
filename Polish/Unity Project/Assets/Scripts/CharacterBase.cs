//*****************************************************
// キャラクター系基底クラス
//*****************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
	[SerializeField, Tooltip("移動速度")] private float moveSpeed;
	[SerializeField, Tooltip("回転速度")] private float rotateSpeed;
	[SerializeField, Tooltip("ヒットポイント")] protected uint hitPoint;
	[SerializeField, Tooltip("攻撃力")] protected uint attackPower;
	//外部参照系---------------------------------------------------------------
	public uint Get_HitPoint { get { return hitPoint; }  }		// ヒットポイントの取得
	public uint Set_HitPoint { set { hitPoint = value; } }		// ヒットポイントの設定
	public uint Get_AttackPower { get { return attackPower; } } // 攻撃力の取得
	//外部参照系---------------------------------------------------------------
	//参照クラス参照系----------------------------------------------------------
	protected float Get_MoveSpeed { get { return moveSpeed * (float)GameMaster.GameSpeed; }}			// 移動速度取得
	protected float Get_RotateSpeed { get { return rotateSpeed * (float)GameMaster.GameSpeed; }}		// 回転速度取得
	//参照クラス参照系----------------------------------------------------------


	/// <summary>
	/// HPから引く
	/// </summary>
	/// <param name="subtract"> 引く数 </param>
	/// <returns> 計算結果 </returns>
	public uint Sub_HitPoint(uint subtract)
	{
		hitPoint -= subtract;
		return hitPoint;
	}
	/// <summary>
	/// HPに加える
	/// </summary>
	/// <param name="addition"> 加える数 </param>
	/// <returns> 計算結果 </returns>
	public uint Add_HitPoint(uint addition)
	{
		hitPoint += addition;
		return hitPoint;
	}
}
