using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	static public uint GameSpeed { get; private set; }
	private void Start()
	{
		GameSpeed = 2;
	}
}
