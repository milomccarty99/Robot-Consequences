using Godot;
using System;

public partial class LanguagePicker : MenuButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//HideOnCheckableItemSelection = false;
		ShowPopup();
		GetPopup().AddCheckItem("English", 0);
		GetPopup().AddCheckItem("Japanese", 1);
		GetPopup().SetItemChecked(0, true);
		if (GetPopup().IsItemChecked(0))
		{
			GD.Print("english selected");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GetPopup().IsItemChecked(0))
		{
			Language = "en";
		}
		else if (GetPopup().IsItemChecked(1))
		{
			Language = "ja";
		}
		
	}
}
