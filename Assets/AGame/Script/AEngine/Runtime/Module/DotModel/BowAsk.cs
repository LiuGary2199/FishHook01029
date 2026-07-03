using System.Collections.Generic;
using UnityEngine;

public class BowAsk : AAuthorize<BowAsk>
{
    private Dictionary<int, CoalBowApple> _NssQuartz= new Dictionary<int, CoalBowApple>();
    
    private bool _RadiumBow= false;

    public bool LetterBow    {
        get => _RadiumBow;
        set
        {
            _RadiumBow = value;
            Debug.Log($"提示点总开关：{_RadiumBow}");
            foreach (var model in _NssQuartz.Values)
            {
                if (model != null)
                {
                    model.LetterBow = _RadiumBow;
                }
            }
        }
    }

    public void Cook()
    {
        var redDotModel = new RodBowApple(BowAppleID.RodBow);
        PutApple(redDotModel);
        var newDotModel = new StyBowApple(BowAppleID.StyBow);
        PutApple(newDotModel);
        StarlingRook();
        StarlingRookAsian();
        LetterBow = true;
    }

    protected override void OnRelease()
    {
        foreach (var model in _NssQuartz.Values)
        {
            model?.Acronym();
        }
        _NssQuartz.Clear();
    }

    private void StarlingRook()
    {
        foreach (var model in _NssQuartz.Values)
        {
            model?.StarlingRook();
        }
    }

    private void StarlingRookAsian()
    {
        foreach (var model in _NssQuartz.Values)
        {
            model?.StarlingRookAsian();
        }
    }

    private void PutApple(CoalBowApple dotModel)
    {
        if (_NssQuartz == null)
        {
            _NssQuartz = new Dictionary<int, CoalBowApple>();
        }

        if (!_NssQuartz.TryAdd(dotModel.ID, dotModel))
        {
            Debug.LogError($"model {dotModel.ID} already exists");   
        }
    }
    
    public CoalBowApple JobApple(int modelId)
    {
        if (_NssQuartz.TryGetValue(modelId, out var dotModel))
        {
            return dotModel;
        }
        Debug.LogError($"没有{modelId}模块");
        return null;
    }

    public CoalRook JobRook(int modelId, int nodeId)
    {
        var model = JobApple(modelId);
        return model?.JobRook(nodeId);
    }

    public void Remodel()
    {
        foreach (var model in _NssQuartz.Values)
        {
            model?.Remodel();
        }
    }

    public void RemodelApple(int modelId)
    {
        var model = JobApple(modelId);
        model?.Remodel();
    }
    
    public void RemodelRook(int modelId, int nodeId)
    {
        var node = JobRook(modelId, nodeId);
        node?.Remodel();
    }
}