using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertColors : MonoBehaviour
{
	public bool active = false;
	public Material mat;

	void Start()
	{
		
	}
	
	void Update()
	{
		
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!active)
		{
			Graphics.Blit(source, destination);
			return;
		}

		Graphics.Blit(source, destination, mat);
	}
}
