using System;
using Shop.Core.ChuckNorrisDtos;

namespace Shop.Core.ServiceInterface
{
	public interface IChuckNorrisServices
	{
		Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto);
	}
}

