using Shop.ApplicationServices.Services;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;


namespace Shop.KindergartenTest
{
    public class KindergartenTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyKindergarten_WhenReturnresult()
        {




            KindergartenDto dto = new KindergartenDto();

            dto.GroupName = "Child";
            dto.ChildrenCount = 2;
            dto.KindergartenName = "ChildGarten";
            dto.Teacher = "Teacher1";
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;


            var result = await Svc<IKindergartenServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdKindergarten_WhenReturnNotEqual()
        {
            Guid guid = Guid.Parse("2b9860da-0dfa-48c0-863c-5a577915a17e");
            //kuidas automaatselt teeb guidi?
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<IKindergartenServices>().GetAsync(guid);
            Assert.NotEqual(guid, wrongGuid);


        }

        [Fact]
        public async Task Should_GetByIdKindergarten_WhenReturnEqual()
        {

            Guid databaseGuid = Guid.Parse("2b9860da-0dfa-48c0-863c-5a577915a17e");
            Guid getGuid = Guid.Parse("bf7d3fa6-cdf5-4c4e-a90a-774b25dea450");

            await Svc<IKindergartenServices>().GetAsync(getGuid);
            Assert.NotEqual(databaseGuid, getGuid);

        }


        [Fact]
        public async Task Should_DeleteByIdKindergarten_WhenDeleteKindergarten()
        {
            //arrange
            KindergartenDto kindergarten = MockKindergartenData();






            //act

            var addKindergarten = await Svc<IKindergartenServices>().Create(kindergarten);
            var result = await Svc<IKindergartenServices>().Delete((Guid)addKindergarten.Id);



            //assert
            //mis Asserti peaks kasutama
            Assert.Equal(result, addKindergarten);

        }

        [Fact]

        public async Task ShouldNot_DeleteByIdKindergarten_WhenDidNotDeleteKindergarten()
        {
            KindergartenDto kindergarten = MockKindergartenData();
            var addKindergarten = await Svc<IKindergartenServices>().Create(kindergarten);
            var addKindergarten2 = await Svc<IKindergartenServices>().Create(kindergarten);

            var result = await Svc<IKindergartenServices>().Delete((Guid)addKindergarten2.Id);


            Assert.NotEqual(result.Id, addKindergarten.Id);
        }

        [Fact]

        public async Task Should_UpdateKindergarten_WhenUpdateData()
        {
            var guid = new Guid("b02d6b13-79a8-4160-9b6a-0bb40da56e19");


            //arrange
            //old data from db
            Kindergarten kindergarten = new Kindergarten();



            //new data
            KindergartenDto dto = MockKindergartenData();
            kindergarten.Id = Guid.Parse("b02d6b13-79a8-4160-9b6a-0bb40da56e19");
            kindergarten.GroupName = "Child1";
            kindergarten.ChildrenCount = 2244;
            kindergarten.KindergartenName = "ChildGarten1";
            kindergarten.Teacher = "Teacher1";
            kindergarten.CreatedAt = DateTime.Now.AddYears(1);
            kindergarten.UpdatedAt = DateTime.Now.AddYears(1);





            //act
            await Svc<IKindergartenServices>().Update(dto);


            //assert
            Assert.Equal(kindergarten.Id, guid);
            Assert.NotEqual(kindergarten.KindergartenName, dto.KindergartenName);
            Assert.Equal(kindergarten.Teacher, dto.Teacher);
            Assert.DoesNotMatch(kindergarten.ChildrenCount.ToString(), dto.ChildrenCount.ToString());

        }

        [Fact]
        public async Task Should_UpdateKindergarte_WhenUpdateDataVersion2()
        {
            KindergartenDto dto = MockKindergartenData();
            var createKindergarten = await Svc<IKindergartenServices>().Create(dto);

            KindergartenDto update = MockUpdateKindergartenData();
            var updateKindergarten = await Svc<IKindergartenServices>().Update(update);

            Assert.DoesNotMatch(updateKindergarten.GroupName, createKindergarten.GroupName);
            Assert.NotEqual(updateKindergarten.KindergartenName, createKindergarten.KindergartenName);
            Assert.Equal(updateKindergarten.Teacher, createKindergarten.Teacher);
            Assert.DoesNotMatch(updateKindergarten.ChildrenCount.ToString(), createKindergarten.ChildrenCount.ToString());

        }

        [Fact]

        public async Task ShouldNot_UpdateKindergarten_WhenNotUpdateData()
        {
            KindergartenDto dto = MockKindergartenData();
            await Svc<IKindergartenServices>().Create(dto);

            KindergartenDto nullUpdate = MockNullKindergarten();
            await Svc<IKindergartenServices>().Create(nullUpdate);

            var nullId = nullUpdate.Id;
            Assert.True(dto.Id == nullId);
        }
        private KindergartenDto MockNullKindergarten()
        {
            KindergartenDto nullDto = new()
            {
                Id = null,
                GroupName = "Name123",
                ChildrenCount = 123,
                KindergartenName = "acdwf",
                Teacher = "czxcdsf",
                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddYears(1),

            };
            return nullDto;
        }

        private KindergartenDto MockUpdateKindergartenData()
        {
            KindergartenDto update = new()
            {
                GroupName = "Name13",
                ChildrenCount = 23,
                KindergartenName = "asdasd",
                Teacher = "Teacher1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now


            };
            return update;
        }

        private KindergartenDto MockKindergartenData()
        {
            KindergartenDto kindergarten = new()
            {
                GroupName = "Name123",
                ChildrenCount = 2,
                KindergartenName = "sd",
                Teacher = "Teacher1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };


            return kindergarten;

        }

    }
}
