using System.Collections.Generic;
using Godot;

public partial class EnemyMovement : Node
{
    [Export]
    public CharacterMovement CharacterMovement;

    [Export]
    public Node Path;

    private int targetNodeIndex = -1;

    private List<Node2D> pathNodes = new List<Node2D>();

    public override void _Ready()
    {
        var path = Path.GetChildren();
        foreach (var pathNode in path)
        {
            if (pathNode is Node2D)
            {
                pathNodes.Add((Node2D)pathNode);
            }
        }
    }

    public override void _Process(double delta)
    {
        if (pathNodes.Count == 0)
        {
            return;
        }

        if (targetNodeIndex == -1)
        {
            targetNodeIndex = 0;
        }

        var target = pathNodes[targetNodeIndex];

        CharacterMovement.MoveDirection = (target.Position - CharacterMovement.Position).Normalized();

        if (CharacterMovement.Position.DistanceTo(target.Position) <= 5f)
        {
            targetNodeIndex++;
            if (targetNodeIndex >= pathNodes.Count)
            {
                targetNodeIndex = 0;
            }
        }
    }
}
