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
		public static KeyCode up = KeyCode.W;
		public static KeyCode down = KeyCode.S;
		public static KeyCode left = KeyCode.A;
		public static KeyCode right = KeyCode.D;
        public static KeyCode openPocket = KeyCode.G;
		public static KeyCode dash = KeyCode.LeftShift;
		
		public static KeyCode attack = KeyCode.Space;
		
		public static KeyCode previousItem = KeyCode.Q;
		public static KeyCode nextItem = KeyCode.E;
	}
}
