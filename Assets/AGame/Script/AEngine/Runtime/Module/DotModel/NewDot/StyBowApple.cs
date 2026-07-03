using System;

public class StyBowApple : CoalBowApple
{
    public StyBowApple(int id) : base(id)
    {
    }

    public override void StarlingRook()
    {
        AtomRook = new StyBowRook(StyBowSo.Atom_Rook);
        PutRook(AtomRook, null);
        
        //主界面table红点
        // var mainNode = new StyBowRook(StyBowSo.MainTable_Node);
        // RegisterNode(mainNode, RootNode);
        
        
    }

    public override void StarlingRookAsian()
    {
        
    }
    
}