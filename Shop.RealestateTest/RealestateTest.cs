using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.RealestateTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.RealestateTest
{
    public class RealestateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnresult()
        {




            RealEstateDto dto = new RealEstateDto();

            dto.Address = "Ehitajate tee";
            dto.SizeSqrM = 1.5f;
            dto.RoomCount = 123;
            dto.Floor = 123;
            dto.BuildingType = "abra";
            dto.BuiltinYear = DateTime.Now;
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;


            var result = await Svc<IRealEstateServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnNotEqual()
        {
            Guid guid = Guid.Parse("2b9860da-0dfa-48c0-863c-5a577915a17e");
            //kuidas automaatselt teeb guidi?
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<IRealEstateServices>().GetAsync(guid);
            Assert.NotEqual(guid, wrongGuid);


        }

        [Fact]
        public async Task Should_GetByIdSpacehip_WhenReturnEqual()
        {

            Guid databaseGuid = Guid.Parse("2b9860da-0dfa-48c0-863c-5a577915a17e");
            Guid getGuid = Guid.Parse("bf7d3fa6-cdf5-4c4e-a90a-774b25dea450");

            //Guid dbGuid = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<IRealEstateServices>().GetAsync(getGuid);
            Assert.NotEqual(databaseGuid, getGuid);

        }


        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //arrange
            RealEstateDto realestate = MockRealEstateData();






            //act

            var addRealEstate = await Svc<IRealEstateServices>().Create(realestate);
            var result = await Svc<IRealEstateServices>().Delete((Guid)addRealEstate.Id);



            //assert
            //mis Asserti peaks kasutama
            Assert.Equal(result, addRealEstate);

        }

        [Fact]

        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            RealEstateDto realestate = MockRealEstateData();
            var addRealEstate = await Svc<IRealEstateServices>().Create(realestate);
            var addRealEstate2 = await Svc<IRealEstateServices>().Create(realestate);

            var result = await Svc<IRealEstateServices>().Delete((Guid)addRealEstate2.Id);


            Assert.NotEqual(result.Id, addRealEstate.Id);
        }

        [Fact]

        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            var guid = new Guid("b02c3b13-79a8-4160-9b6a-0bb40da56e19");
            //var realestate = MockRealEstatepData();

            //arrange
            //old data from db
            RealEstate realestate = new RealEstate();



            //new data
            RealEstateDto dto = MockRealEstateData();
            realestate.Id = Guid.Parse("b02c3b13-79a8-4160-9b6a-0bb40da56e19");
            realestate.Address = "fgfdg";
            realestate.SizeSqrM = 3.5f;
            realestate.RoomCount = 1233;
            realestate.Floor = 9;
            realestate.BuildingType = "abdsara";
            realestate.BuiltinYear = DateTime.Now.AddYears(1);
            realestate.CreatedAt = DateTime.Now.AddYears(1);
            realestate.UpdatedAt = DateTime.Now.AddYears(1);



            //act
            await Svc<IRealEstateServices>().Update(dto);


            //assert
            Assert.Equal(realestate.Id, guid);
            Assert.NotEqual(realestate.SizeSqrM, dto.SizeSqrM);
            Assert.Equal(realestate.RoomCount, dto.RoomCount);
            Assert.DoesNotMatch(realestate.Floor.ToString(), dto.Floor.ToString());

        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()
        {
            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto update = MockUpdateRealEstateData();
            var updateRealEstate = await Svc<IRealEstateServices>().Update(update);

            Assert.DoesNotMatch(updateRealEstate.Address, createRealEstate.Address);
            Assert.NotEqual(updateRealEstate.SizeSqrM, createRealEstate.SizeSqrM);
            Assert.Equal(updateRealEstate.RoomCount, createRealEstate.RoomCount);
            Assert.DoesNotMatch(updateRealEstate.Floor.ToString(), createRealEstate.Floor.ToString());

        }

        [Fact]

        public async Task ShouldNot_UpdateRealEstate_WhenNotUpdateData()
        {
            RealEstateDto dto = MockRealEstateData();
            await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto nullUpdate = MockNullRealEstate();
            await Svc<IRealEstateServices>().Create(nullUpdate);

            var nullId = nullUpdate.Id;
            Assert.True(dto.Id == nullId);
        }
        private RealEstateDto MockNullRealEstate()
        {
            RealEstateDto nullDto = new()
            {
                Id = null,
                Address = "tee",
                SizeSqrM = 8.5f,
                RoomCount = 1233,
                Floor = 123213,
                BuildingType = "abkcdara",
                BuiltinYear = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddYears(1)


            };
            return nullDto;
        }

        private RealEstateDto MockUpdateRealEstateData()
        {
            RealEstateDto update = new()
            {
                Address = "tee",
                SizeSqrM = 1.5f,
                RoomCount = 1233,
                Floor = 123,
                BuildingType = "tee",
                BuiltinYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now


            };
            return update;
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realestate = new()
            {
                Address = "teea",
                SizeSqrM = 2.5f,
                RoomCount = 1233,
                Floor = 10,
                BuildingType = "afsdffsdfsdbra",
                BuiltinYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };


            return realestate;

        }

    }
}