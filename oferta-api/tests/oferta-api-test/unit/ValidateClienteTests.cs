using oferta_domain.Entities;
using oferta_api.Helpers;
using Xunit;

namespace oferta_api_test.unit
{
    public class ValidateClienteTests
    {
        [Theory(DisplayName="Should Not Validate Cliente With Invalid Parameters")]
        [InlineData("3212354673", "Ricardo", "", 0)]
        [InlineData("", "Ricardo", "44556655", 0)]
        [InlineData("3216549879", "", "44556655", 0)]
        [InlineData("", "", "", 0)]
        public void ValidateCliente_ShouldNotValidateCliente(string cpf, string nome, string telefone, double credito)
        {
            var cliente = new Cliente(cpf, nome, telefone, credito);
            var response = Utils.ValidateCliente(cliente);

            Assert.False(response);
        }

        [Fact]
        public void ValidateCliente_ShouldValidateCliente_WhenValidParameters()
        {
            var cliente = new Cliente("3212354673", "Ricardo", "44664466", 50);
            var response = Utils.ValidateCliente(cliente);

            Assert.True(response);
        }


    }
}