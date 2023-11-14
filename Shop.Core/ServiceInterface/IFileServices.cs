using Shop.Core.Domain;
using Shop.Core.Dto;


namespace Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
                          //array a few file at the same time
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);

        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);


        void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);
        Task<FilesToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);

        Task<FilesToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dto);

        //void FilesToApi(RealEstateDto dto, RealEstate realestate);

    }
  
        
    
}
