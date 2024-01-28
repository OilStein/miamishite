using System.Linq;
using Godot;

public partial class UIPortraitSwitcher : TextureRect
{
    [Export]
    public float[] Thresholds;
    [Export]
    public Texture2D[] Textures;

    public void ShiteChanged(float shite)
    {
        var texture = Thresholds
            .Select((t, i) => new { Threshold = t, Texture = Textures[i] })
            .Where(x => x.Threshold <= shite)
            .Last().Texture;
        
        Texture = texture;
    }
}
