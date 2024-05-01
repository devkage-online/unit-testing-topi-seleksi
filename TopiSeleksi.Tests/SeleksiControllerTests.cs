using Microsoft.AspNetCore.Mvc;
using TopiSeleksi.Controllers;

namespace TopiSeleksi.Tests
{
    public class SeleksiControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithHouseInformation()
        {
            var controller = new SeleksiController();
            var result = controller.Index("Silvano Suprapto") as ViewResult;
            string[] houses = ["Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin"];
            var house = result!.ViewData["house"] as string;

            Assert.IsType<ViewResult>(result);
            Assert.Contains(house, houses);
        }

        [Fact]
        public void IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            var controller = new SeleksiController();
            var result = controller.Index(String.Empty);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
