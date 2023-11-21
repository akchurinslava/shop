using System;
using Shop.Core.ChuckNorrisDtos;
using Shop.Core.Dto.CocktailsDtos;

namespace Shop.Core.ServiceInterface
{
	public interface ICocktailsServices
    {
		Task<CocktailsResultDto> CocktailsResult(CocktailsResultDto dto);
    }
}

