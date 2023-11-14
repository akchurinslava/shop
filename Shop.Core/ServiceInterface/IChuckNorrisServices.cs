using System;
using Shop.Core.ChuckNorrisDtos;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
	public interface IChuckNorrisServices
	{
        Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto);

    }
}

