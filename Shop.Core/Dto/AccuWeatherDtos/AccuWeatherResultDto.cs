﻿using System;
using Newtonsoft.Json;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class AccuWeatherResultDto
    {
        public string AccuCitysKey { get; set; }

        public string City { get; set;  }

        public DateTime HeadlinesEffectiveDate { get; set; }

        public int HeadlinesEffectiveEpochDate { get; set; }

        public int HeadlinesSeverity { get; set; }

        public string HeadlinesText { get; set; }

        public string HeadlinesCategory { get; set; }

        public DateTime HeadlinesEndDate { get; set; }

        public int HeadlinesEndEpochDate { get; set; }

        public string HeadlinesMobileLink { get; set; }

        public string HeadlinesLink { get; set; }

        public DateTime DailyForecastDate { get; set; }

        public int DailyForecastEpochDate { get; set; }

        public int DailyForecastTemperaturesMinimumsValue { get; set; }
        public string DailyForecastTemperaturesMinimumsUnit { get; set; }
        public int DailyForecastTemperaturesMinimumsUnitType { get; set; }

        public int DailyForecastTemperaturesMaximumsValue { get; set; }
        public string DailyForecastTemperaturesMaximumsUnit { get; set; }
        public int DailyForecastTemperaturesMaximumsUnitType { get; set; }


        public int DailyForecastDaysIcon { get; set; }


        public string DailyForecastDaysIconPhrase { get; set; }


        public bool DailyForecastDaysHasPrecipitation { get; set; }


        public string DailyForecastDaysPrecipitationType { get; set; }


        public string DailyForecastDaysPrecipitationIntensity { get; set; }

        public int DailyForecastNightsIcon { get; set; }

        public string DailyForecastNightsIconPhrase { get; set; }

        public bool DailyForecastNightsHasPrecipitation { get; set; }

        public string DailyForecastSources { get; set; }

        public string DailyForecastMobileLink { get; set; }

        public string DailyForecastLink { get; set; }
    }
    
}

