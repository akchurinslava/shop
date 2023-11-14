using System;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
	public interface IWeatherForecastServices
	{
        Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto);

    }
}

