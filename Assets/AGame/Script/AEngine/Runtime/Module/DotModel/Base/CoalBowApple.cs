using System.Collections.Generic;
using UnityEngine;

public abstract class CoalBowApple
{
    public readonly int ID;
    protected CoalRook AtomRook;
    
    protected Dictionary<int, CoalRook> _VineOak;

    private bool _RadiumBow;

    public bool LetterBow    {
        get => _RadiumBow;
        set
        {
            _RadiumBow = value;
            Debug.Log($"EnableDot: {ID} {_RadiumBow}");
        }
    }

    public CoalBowApple(int id)
    {
        ID = id;
        _VineOak = new Dictionary<int, CoalRook>();
        AtomRook = null;
        _RadiumBow = false;
    }
    
    public void Acronym()
    {
        OnRelease();
        foreach (var node in _VineOak.Values)
        {
            node.Acronym();
        }
        _VineOak.Clear();
        AtomRook = null;
    }

    protected virtual void OnRelease()
    {
        
    }

    public abstract void StarlingRook();

    public abstract void StarlingRookAsian();

    public virtual void Remodel()
    {
        foreach (var node in _VineOak.Values)
        {
            if (node.SoNext)
            {
                node.Remodel();
            }
        }
    }

    public virtual void RemodelRook(int id)
    {
        if (_VineOak != null && _VineOak.TryGetValue(id, out var node))
        {
            node.Remodel();
        }
    }

    public CoalRook JobRook(int id)
    {
        if (_VineOak.TryGetValue(id, out var node))
        {
            return node;
        }
        Debug.LogError($"Node with ID {id} not found");
        return null;
    }

    protected void PutRook(CoalRook node, CoalRook parentNode)
    {
        if (!_VineOak.TryAdd(node.ID, node))
        {
            Debug.Log($"重复注册节点：{node.ID}");
            return;
        }

        node.CartonRook = parentNode;
        parentNode?.PutMound(node);
    }
    
    protected void DealerRook(int id)
    {
        if (_VineOak.TryGetValue(id, out var node))
        {
            node.CartonRook.DealerMound(node);
            node.CartonRook = null;
            _VineOak.Remove(id);
            foreach (var nodeChild in node.Amniotic)
            {
                DealerRook(nodeChild.ID);
            }
        }
    }
    
}