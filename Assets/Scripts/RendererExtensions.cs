using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gives simple extension access to checking if an Renderer is rendered by a specific Camera.
public static class RendererExtensions
{
	public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
}