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
                ChuckNorrisResponseRootDto chucknorrisResult = new JavaScriptSerializer().Deserialize<ChuckNorrisResponseRootDto>(json);

                dto.Categories = chucknorrisResult.Categories;
                dto.CreatedAt = chucknorrisResult.CreatedAt;
                dto.IconUrl = chucknorrisResult.IconUrl;
                dto.Id = chucknorrisResult.Id;
                dto.UpdatedAt = chucknorrisResult.UpdatedAt;
                dto.Url = chucknorrisResult.Url;
                dto.Value = chucknorrisResult.Value;
            }


            return dto;
        }
    }
}

