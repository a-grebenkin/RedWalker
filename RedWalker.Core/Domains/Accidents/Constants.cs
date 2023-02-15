using System.Collections.Generic;

namespace RedWalker.Core.Domains.Accidents
{
 public static class ConstantsGibdd
    {
        public enum TypeAccident
        {
            HittingPedestrian, //Наезд на пешехода
            HittingСyclist, //Наезд на велосипедиста
            HittingWorker, //Наезд на лицо не являющееся участником дорожного движения, осуществляющего несение службы
            HittingMeansIndividualMobility, //Наезд на средство индивидуальной мобильности (за исключением велосипеда)
            Other //Не связан ни с пешеходом ни с велосипедистом
        }

        public static readonly Dictionary<string, TypeAccident> DictTypeAccident = new(){
            {"Наезд на пешехода", TypeAccident.HittingPedestrian},
            {"Наезд на велосипедиста", TypeAccident.HittingСyclist},
            {"Наезд на лицо, не являющееся участником дорожного движения, осуществляющее несение службы", TypeAccident.HittingWorker},
            {"Наезд на лицо, не являющееся участником дорожного движения, осуществляющее производство работ", TypeAccident.HittingWorker},
            {"Наезд на лицо, не являющееся участником дорожного движения, осуществляющее какую-либо другую деятельность", TypeAccident.HittingWorker},
            {"Наезд на лицо передвигающееся на СИМ", TypeAccident.HittingWorker}
        };

        public enum LightingCondition
        {
            Daylight, // Светлое время суток
            Twilight, // Сумерки
            DarkTimeNoLight, // В темное время суток, освещение отсутствует
            DarkTimeLightOn, // В темное время суток, освещение включено
            DarkTimeLightOff, // В темное время суток, освещение не включено
            Other
        }

        public static readonly Dictionary<string, LightingCondition> DictLightingCondition = new(){
            {"Светлое время суток", LightingCondition.Daylight},
            {"Сумерки", LightingCondition.Twilight},
            {"В темное время суток, освещение отсутствует", LightingCondition.DarkTimeNoLight},
            {"В темное время суток, освещение включено", LightingCondition.DarkTimeLightOn},
            {"В темное время суток, освещение не включено", LightingCondition.DarkTimeLightOff}
        };

        public enum WeatherCondition
        {
            Clear,  //Ясно
            Сloudy, //Пасмурно 
            Rain,   //Дождь
            Fog,    //Туман
            Snowfall,   //Снегопад
            Snowstorm, //Метель
            Other
        }

        public static readonly Dictionary<string, WeatherCondition> DictWeatherCondition = new(){
            {"Ясно", WeatherCondition.Clear},
            {"Пасмурно", WeatherCondition.Сloudy},
            {"Дождь", WeatherCondition.Rain},
            {"Туман", WeatherCondition.Fog},
            {"Снегопад", WeatherCondition.Snowfall},
            {"Метель", WeatherCondition.Snowstorm}
        };

        public enum RoadWayCondition
        {
            Dry, //Сухое
            Wet, //Мокрое
            Dusty, //Пыльное
            SnowСovered, //Заснеженное
            Contaminated,//Загрязненное
            SnowTrack, //Со снежным накатом
            Icy, //Гололедица
            AntiIcing, //Обработанное противогололедными материалами
            SurfaceTreatment,//Свежеуложенная поверхностная обработка
            CoveredWater,//Залитое (покрытое) водой
            Other
        }

        public static readonly Dictionary<string, RoadWayCondition> DictRoadWayCondition = new(){
            {"Сухое", RoadWayCondition.Dry},
            {"Мокрое", RoadWayCondition.Wet},
            {"Пыльное", RoadWayCondition.Dusty},
            {"Заснеженное", RoadWayCondition.SnowСovered},
            {"Загрязненное", RoadWayCondition.Contaminated},
            {"Со снежным накатом", RoadWayCondition.SnowTrack},
            {"Гололедица", RoadWayCondition.Icy},
            {"Обработанное противогололедными материалами", RoadWayCondition.AntiIcing},
            {"Свежеуложенная поверхностная обработка", RoadWayCondition.SurfaceTreatment},
            {"Залитое (покрытое) водой", RoadWayCondition.CoveredWater}
        };

        public enum SceneAccident
        {
            RegulatedCrosswalk, //регулируемый пешеходный переход
            UnregulatedCrosswalk, //нерегулируемый пешеходный переход
            BusStop, //остановка общественного транспорта
            TramStop, //остановка трамвая
            RegulatedCrossroad, //регулиремый перекресток
            UnregulatedCrossroad, //нерегулиремый перекресток
            Road, //дорога
            NotRoad //не относящееся к дороге
        }

        public static readonly Dictionary<string, SceneAccident> DictSceneAccident = new(){
            {"Перегон (нет объектов на месте ДТП)", SceneAccident.Road},
            {"Регулируемый пешеходный переход", SceneAccident.RegulatedCrosswalk},
            {"Нерегулируемый пешеходный переход", SceneAccident.UnregulatedCrosswalk},
            {"Нерегулируемый пешеходный переход, расположенный на участке улицы или дороги, проходящей вдоль территории школы или иного детского учреждения", SceneAccident.UnregulatedCrosswalk},
            {"Остановка общественного транспорта", SceneAccident.BusStop},
            {"Внутридворовая территория", SceneAccident.NotRoad},
            {"Иное место", SceneAccident.NotRoad},
            {"Регулируемый перекресток", SceneAccident.RegulatedCrossroad},
            {"Выезд с прилегающей территории", SceneAccident.NotRoad},
            {"Автостоянка (отделенная от проезжей части)", SceneAccident.NotRoad},
            {"Автостоянка (не отделённая от проезжей части)", SceneAccident.NotRoad},
            {"АЗС", SceneAccident.NotRoad},
            {"Нерегулируемый перекрёсток неравнозначных улиц (дорог)", SceneAccident.UnregulatedCrossroad},
            {"Регулируемый пешеходный переход, расположенный на участке улицы или дороги, проходящей вдоль территории школы или иного детского учреждения", SceneAccident.RegulatedCrosswalk},
            {"Гаражные постройки (гаражный кооператив, товарищество либо иное место концентрированного размещения гаражей)", SceneAccident.NotRoad},
            {"Тротуар, пешеходная дорожка", SceneAccident.NotRoad},
            {"Мост, эстакада, путепровод", SceneAccident.Road},
            {"Остановка трамвая", SceneAccident.TramStop},
            {"Нерегулируемый перекрёсток равнозначных улиц (дорог)", SceneAccident.UnregulatedCrossroad},
            {"Подход к мосту, эстакаде, путепроводу", SceneAccident.Road},
            {"Пешеходная зона", SceneAccident.NotRoad},
            {"Нерегулируемое пересечение с круговым движением", SceneAccident.UnregulatedCrossroad},
            {"Нерегулируемый пешеходный переход, расположенный на участке улицы или дороги, проходящей вдоль территории школы или иной детской организации", SceneAccident.UnregulatedCrosswalk},
            {"Регулируемый ж/д переезд с дежурным", SceneAccident.Road},
            {"Регулируемый пешеходный переход, расположенный на участке улицы или дороги, проходящей вдоль территории школы или иной детской организации", SceneAccident.RegulatedCrossroad}
        };
    }
}