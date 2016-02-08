using UnityEngine;
using System.Collections;

public enum Layers {
	None, 
	Border, 
	Player, 
	UI
}

public class IgnoreLayers : MonoBehaviour {

	public Layers layers;
	private string _layerString = "";
	private int _layerInt;

	void Update()
	{
		LayerSwitch();
		Ignore();
	}

	private void Ignore()
	{
		Physics2D.IgnoreLayerCollision(this.gameObject.layer, _layerInt);
	}

	public void LayerSwitch()
	{
		switch(layers)
		{
		case Layers.None:
			_layerString = "";
			break;

		case Layers.Border:		
			_layerString = Tags.BORDERTAG;
			_layerInt = 8;
			//_layerInt = 1 << LayerMask.NameToLayer(_layerString);
			break;

		case Layers.Player:
			_layerString = Tags.PLAYERTAG;
			_layerInt = 10;
			//_layerInt = 1 << LayerMask.NameToLayer(_layerString);
			break;

		case Layers.UI:
			_layerString = Tags.UITAG;
			_layerInt = 5;
			//_layerInt = 1 << LayerMask.NameToLayer(_layerString);
			break;
		}
	}

}
