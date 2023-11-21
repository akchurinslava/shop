using System;
using System.Text.Json.Serialization;

namespace Shop.Core.Dto.CocktailsDtos
{
	public class CocktailsResponseRootDto
	{
        [JsonPropertyName("drinks")]
        public List<Drink> Drinks { get; set; }
    }
}

