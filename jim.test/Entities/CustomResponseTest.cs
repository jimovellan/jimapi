using jim.models.Entity.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jim.test
{
    [TestClass]
    public class CustomResponseTest
    {
        [TestMethod]
        public void CustomResponse_ShouldReturnSuccessFalse_When_AddErrorMessage()
        {
            var sut = CustomResponse.Fail("Error");
            Assert.AreEqual(sut.Errors.Count, 1);
            Assert.IsFalse(sut.Success);
        }
        [TestMethod]
        public void CustomResponse_ShouldReturnSuccessTrue_When_ReturnOk()
        {
            var sut = CustomResponse.Ok();
            Assert.AreEqual(sut.Errors.Count, 0);
            Assert.IsTrue(sut.Success);
        }
    }
}
