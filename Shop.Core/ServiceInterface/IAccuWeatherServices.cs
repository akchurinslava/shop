using System;
using Shop.Core.Dto;
using Shop.Core.Dto.AccuWeatherDtos;

namespace Shop.Core.ServiceInterface
{
	public interface IAccuWeatherServices
	{
        Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto);
    }
}

