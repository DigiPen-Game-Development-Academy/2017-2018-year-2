/*
Author: Myles
Contributors: N/A
Last Edit: 1/29/2019
*/

// Class used for memez
class E
{
	// A very kewl variable
	float coolVariable = 9001.0f;
	
	// Tests is variable is over 9000
	void Derp()
	{
		// If over 9000
		if (coolVariable > 9000.0f)
		{
			// E
			Debug.Log("ITZ OVR 90000000!!!!1!!!1!!!");
			return;
		}
		
		// Otherwise big oof
		if (coolVariable <= 9000.0f)
			Debug.Log("variabl is lame. big oof.");
	}
}