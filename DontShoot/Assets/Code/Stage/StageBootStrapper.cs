using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBootStrapper : MonoBehaviour
{
    //Список префабов карт так как все действие будет раскидано по тематическим сценам (одна сцена на трейн, деревянную арену и тд)
    
    //Спавн префабов уровней
    
    //Спавн героя и его инициализация
    
    //Спавн противников и их инициализация (вынести все данные в скриптабл обджекты? урон, хп, тип (стрелковый, ближнего боя)). Типы задавать в префабах
    //а характеристики прямо перед спавном


    [SerializeField] private StageData _stageData;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = new Spawner();
       _spawner.Initialize();
    }

    public StageData GetStageData()
    {
        return _stageData;
    }
}
