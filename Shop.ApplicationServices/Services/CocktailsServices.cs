
using System.Net;
using Nancy.Json;
using Shop.Core.Dto;
using Shop.Core.Dto.CocktailsDtos;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class CocktailsServices : ICocktailsServices
    {
        public async Task<CocktailsResultDto> CocktailsResult(CocktailsResultDto dto)
        {
            
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={dto.strDrink}";

            using (WebClient client = new())
            {
                string json = client.DownloadString(url);
                CocktailsResponseRootDto cocktailsResult = new JavaScriptSerializer().Deserialize<CocktailsResponseRootDto>(json);

                dto.idDrink = cocktailsResult.Drinks[0].idDrink;
                dto.strDrink = cocktailsResult.Drinks[0].strDrink;
                dto.strDrinkAlternate = cocktailsResult.Drinks[0].strDrinkAlternate;
                dto.strTags = cocktailsResult.Drinks[0].strTags;
                dto.strVideo = cocktailsResult.Drinks[0].strVideo;
                dto.strCategory = cocktailsResult.Drinks[0].strCategory;
                dto.strIBA = cocktailsResult.Drinks[0].strIBA;
                dto.strAlcoholic = cocktailsResult.Drinks[0].strAlcoholic;
                dto.strGlass = cocktailsResult.Drinks[0].strGlass;
                dto.strInstructions = cocktailsResult.Drinks[0].strInstructions;
                dto.strInstructionsES = cocktailsResult.Drinks[0].strInstructionsES;
                dto.strInstructionsDE = cocktailsResult.Drinks[0].strInstructionsDE;
                dto.strInstructionsFR = cocktailsResult.Drinks[0].strInstructionsFR;
                dto.strInstructionsIT = cocktailsResult.Drinks[0].strInstructionsIT;
                dto.strInstructionsZHHANS = cocktailsResult.Drinks[0].strInstructionsZHHANS;
                dto.strInstructionsZHHANT = cocktailsResult.Drinks[0].strInstructionsZHHANT;
                dto.strDrinkThumb = cocktailsResult.Drinks[0].strDrinkThumb;
                dto.strIngredient1 = cocktailsResult.Drinks[0].strIngredient1;
                dto.strIngredient2 = cocktailsResult.Drinks[0].strIngredient2;
                dto.strIngredient3 = cocktailsResult.Drinks[0].strIngredient3;
                dto.strIngredient4 = cocktailsResult.Drinks[0].strIngredient4;
                dto.strIngredient5 = cocktailsResult.Drinks[0].strIngredient5;
                dto.strIngredient6 = cocktailsResult.Drinks[0].strIngredient6;
                dto.strIngredient7 = cocktailsResult.Drinks[0].strIngredient7;
                dto.strIngredient8 = cocktailsResult.Drinks[0].strIngredient8;
                dto.strIngredient9 = cocktailsResult.Drinks[0].strIngredient9;
                dto.strIngredient10 = cocktailsResult.Drinks[0].strIngredient10;
                dto.strIngredient11 = cocktailsResult.Drinks[0].strIngredient11;
                dto.strIngredient12 = cocktailsResult.Drinks[0].strIngredient12;
                dto.strIngredient13 = cocktailsResult.Drinks[0].strIngredient13;
                dto.strIngredient14 = cocktailsResult.Drinks[0].strIngredient14;
                dto.strIngredient15 = cocktailsResult.Drinks[0].strIngredient15;
                dto.strMeasure1 = cocktailsResult.Drinks[0].strMeasure1;
                dto.strMeasure2 = cocktailsResult.Drinks[0].strMeasure2;
                dto.strMeasure3 = cocktailsResult.Drinks[0].strMeasure3;
                dto.strMeasure4 = cocktailsResult.Drinks[0].strMeasure4;
                dto.strMeasure5 = cocktailsResult.Drinks[0].strMeasure5;
                dto.strMeasure6 = cocktailsResult.Drinks[0].strMeasure6;
                dto.strMeasure7 = cocktailsResult.Drinks[0].strMeasure7;
                dto.strMeasure8 = cocktailsResult.Drinks[0].strMeasure8;
                dto.strMeasure9 = cocktailsResult.Drinks[0].strMeasure9;
                dto.strMeasure10 = cocktailsResult.Drinks[0].strMeasure10;
                dto.strMeasure11 = cocktailsResult.Drinks[0].strMeasure11;
                dto.strMeasure12 = cocktailsResult.Drinks[0].strMeasure12;
                dto.strMeasure13 = cocktailsResult.Drinks[0].strMeasure13;
                dto.strMeasure14 = cocktailsResult.Drinks[0].strMeasure14;
                dto.strMeasure15 = cocktailsResult.Drinks[0].strMeasure15;
                dto.strImageSource = cocktailsResult.Drinks[0].strImageSource;
                dto.strImageAttribution = cocktailsResult.Drinks[0].strImageAttribution;
                dto.strCreativeCommonsConfirmed = cocktailsResult.Drinks[0].strCreativeCommonsConfirmed;
                dto.dateModified = cocktailsResult.Drinks[0].dateModified;
            }
            return dto;

        }

    }
}

