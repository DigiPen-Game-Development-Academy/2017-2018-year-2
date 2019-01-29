/*
Author: Myles Busig
Contributors: N/A
Date Last Edited: 1/29/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
	public class KeyBinds
	{
		public KeyCode up = KeyCode.W;
		public KeyCode down = KeyCode.S;
		public KeyCode left = KeyCode.A;
		public KeyCode right = KeyCode.D;
		
		public KeyCode dash = KeyCode.LeftShift;

		public KeyCode attack = KeyCode.Space;

		public KeyCode previousItem = KeyCode.Q;
		public KeyCode nextItem = KeyCode.E;
	}
}
