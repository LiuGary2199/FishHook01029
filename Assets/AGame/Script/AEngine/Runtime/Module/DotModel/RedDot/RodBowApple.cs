using System;

public class RodBowApple : CoalBowApple
{
    public RodBowApple(int id) : base(id)
    {
    }

    public override void StarlingRook()
    {
        AtomRook = new RodBowRook(RodBowSo.Atom_Rook);
        PutRook(AtomRook, null);
        
        //主界面table红点
        // var mainNode = new RodBowRook(RodBowSo.MainTable_Node);
        // RegisterNode(mainNode, RootNode);
      
    }

    public override void StarlingRookAsian()
    {
        //添加叶子节点红点检查方法
        // var paopaoNode = GetNode(RodBowSo.Paopao_Node);
        // paopaoNode.RegisterNodeCheck(PaopaoMgr.Instance.RedDotCheckFunc);
        
    }
    
}