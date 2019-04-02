using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ButtonType
{
	SwitchLevel,
	Quit
}

public class Button : MonoBehaviour
{
	public ButtonType buttonType = ButtonType.SwitchLevel;
	public string level;

	bool isOver = false;

	void Start()
	{

	}
	
	void Update()
	{
		if (isOver && Input.GetMouseButtonDown(0))
		{
			switch (buttonType)
			{
				case ButtonType.SwitchLevel:
					SceneManager.LoadScene(level);
					break;
				case ButtonType.Quit:
					Debug.Log("QUIT");
					Application.Quit();
					break;
				default:
					break;
			}
		}

		isOver = false;
	}

	void OnMouseOver()
	{
		isOver = true;
	}
}
