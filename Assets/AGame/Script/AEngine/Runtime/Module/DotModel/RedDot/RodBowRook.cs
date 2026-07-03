using System;

public class RodBowRook : CoalRook
{
    public RodBowRook(int id, Func<int> onDotCheck = null)
        : base(id, onDotCheck)
    {
    }
    
}