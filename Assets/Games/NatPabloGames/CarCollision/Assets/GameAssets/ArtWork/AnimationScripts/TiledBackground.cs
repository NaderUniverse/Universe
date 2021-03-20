using UnityEngine;
using System.Collections;

// change texturesize and nativeResolution in unity editor
public class TiledBackground : MonoBehaviour {

	public int textureSize = 1;
	public bool scaleHorizontally = true;
	public bool scaleVertically = true;

	public Vector2 nativeResolution = new Vector2 (800, 450);
	public static float pixelScale = 1f;
	
	// Use this for initialization
	void Start () {
		pixelScale = Screen.height / nativeResolution.y;
		
		var newWidth = !scaleHorizontally ? 1 : Mathf.Ceil (Screen.width / (textureSize * pixelScale));
		var newHeight = !scaleVertically ? 1 : Mathf.Ceil (Screen.height / (textureSize * pixelScale));

		transform.localScale = new Vector3 (newWidth * textureSize, newHeight * textureSize, 1);

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1);
	}

}
