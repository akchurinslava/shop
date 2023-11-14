using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnresult()
        {




            SpaceshipDto dto = new SpaceshipDto();

            dto.Name = "Name";
            dto.Type = "Type";
            dto.Passangers = 123;
            dto.EnginPower = 123;
            dto.Crew = 123;
            dto.Company = "asd";
            dto.CargoWeight = 123;
            dto.Modifieted = DateTime.Now;


            var result = await Svc<ISpaceshipServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnNotEqual()
        {
            Guid guid = Guid.Parse("2b9860da-0dfa-48c0-863c-5a577915a17e");
            //kuidas automaatselt teeb guidi?
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<ISpaceshipServices>().GetAsync(guid);
            Assert.NotEqual(guid, wrongGuid);


        }

        [Fact]
        public async Task Should_GetByIdSpacehip_WhenReturnEqual()
        {

            Guid databaseGuid = Guid.Parse("2b9860da-0dfa-48c0-863c-5a577915a17e");
            Guid getGuid = Guid.Parse("bf7d3fa6-cdf5-4c4e-a90a-774b25dea450");

            //Guid dbGuid = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<ISpaceshipServices>().GetAsync(getGuid) ;
            Assert.NotEqual(databaseGuid, getGuid);

        }


        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            //arrange
            SpaceshipDto spaceship = MockSpaceshipData();
            


            


            //act

            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var result = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship.Id);



            //assert
            //mis Asserti peaks kasutama
            Assert.Equal(result, addSpaceship);
            
        }

        [Fact]

        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();
            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipServices>().Create(spaceship);

            var result = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship2.Id);


            Assert.NotEqual(result.Id, addSpaceship.Id);
        }

        [Fact]

        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("b02d6b13-79a8-4160-9b6a-0bb40da56e19");
            //var spaceship = MockSpaceshipData();

            //arrange
            //old data from db
            Spaceship spaceship = new Spaceship();



            //new data
            SpaceshipDto dto = MockSpaceshipData();
            spaceship.Id = Guid.Parse("b02d6b13-79a8-4160-9b6a-0bb40da56e19");
            spaceship.Name = "asd";
            spaceship.Type = "asdgreg";
            spaceship.Passangers = 163423;
            spaceship.EnginPower = 12863;
            spaceship.Crew = 123;
            spaceship.Company = "COMPANY ASD";
            spaceship.CargoWeight = 123;
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.Modifieted = DateTime.Now.AddYears(1);





            //act
            await Svc<ISpaceshipServices>().Update(dto);


            //assert
            Assert.Equal(spaceship.Id, guid);
            Assert.NotEqual(spaceship.EnginPower, dto.EnginPower);
            Assert.Equal(spaceship.Crew, dto.Crew);
            Assert.DoesNotMatch(spaceship.Passangers.ToString(), dto.Passangers.ToString());

        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateDataVersion2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceshipData();
            var updateSpaceship = await Svc<ISpaceshipServices>().Update(update);

            Assert.DoesNotMatch(updateSpaceship.Name, createSpaceship.Name);
            Assert.NotEqual(updateSpaceship.EnginPower, createSpaceship.EnginPower);
            Assert.Equal(updateSpaceship.Crew, createSpaceship.Crew);
            Assert.DoesNotMatch(updateSpaceship.Passangers.ToString(), createSpaceship.Passangers.ToString());

        }

        [Fact]

        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto nullUpdate = MockNullSpaceship();
            await Svc<ISpaceshipServices>().Create(nullUpdate);

            var nullId = nullUpdate.Id;
            Assert.True(dto.Id == nullId);
        }
        private SpaceshipDto MockNullSpaceship()
        {
                SpaceshipDto nullDto = new()
                {
                    Id = null,
                    Name = "Name123",
                    Type = "Type123",
                    Passangers = 123,
                    EnginPower = 123,
                    Crew = 123,
                    Company = "COMPANY123",
                    CargoWeight = 123,
                    CreatedAt = DateTime.Now.AddYears(1),
                    Modifieted = DateTime.Now.AddYears(1),

        };
                return nullDto;
                }

        private SpaceshipDto MockUpdateSpaceshipData()
        {
            SpaceshipDto update = new()
            {
                Name = "Name123",
                Type = "asd",
                Passangers = 1234,
                EnginPower = 1234,
                Crew = 123,
                Company = "asd",
                CargoWeight = 1234,
                CreatedAt = DateTime.Now,
                Modifieted = DateTime.Now


            };
            return update;
        }

        private SpaceshipDto MockSpaceshipData()
        {
                SpaceshipDto spaceship = new()
                {
                    Name = "asd12321",
                    Type = "asd",
                    Passangers = 123,
                    EnginPower = 123,
                    Crew = 123,
                    Company = "asd",
                    CargoWeight = 123,
                    CreatedAt = DateTime.Now,
                    Modifieted = DateTime.Now,
                };


                return spaceship;

        }

    }
}

