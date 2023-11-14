using System;
using Shop.Core.ChuckNorrisDtos;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using System.Net;
using Nancy.Json;
namespace Shop.ApplicationServices.Services
{
    public class ChuckNorrisServices : IChuckNorrisServices
    {
        public async Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto)
        {
            string url = $"https://api.chucknorris.io/jokes/random";
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                ChuckNorrisResponseRootDto chuckNorrisResult = new JavaScriptSerializer().Deserialize<ChuckNorrisResponseRootDto>(json);

                dto.Categories = chuckNorrisResult.Categories;
                dto.CreatedAt = chuckNorrisResult.CreatedAt;
                dto.IconUrl = chuckNorrisResult.IconUrl;
                dto.Id = chuckNorrisResult.Id;
                dto.UpdatedAt = chuckNorrisResult.UpdatedAt;
                dto.Url = chuckNorrisResult.Url;
                dto.Value = chuckNorrisResult.Value;
            }


            return dto;
        }
    }
}

