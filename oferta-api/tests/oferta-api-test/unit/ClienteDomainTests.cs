using oferta_domain;
using oferta_domain.Services;
using Xunit;

namespace oferta_api_test.unit
{
    public class ClienteDomainTests
    {
        [Fact]
        public void ValidateCliente_ShouldNotValidateCliente_WhenTelefoneNotInformed()
        {
            var cliente = new Cliente(3212354673, "Ricardo", 0, 0);
            
            var response = ClienteService.ValidateCliente(cliente);

            Assert.False(response);
        }

        [Fact]
        public void ValidateCliente_ShouldNotValidateCliente_WhenCpfNotInformed()
        {
            var cliente = new Cliente(0, "Ricardo", 44556655, 0);
            
            var response = ClienteService.ValidateCliente(cliente);

            Assert.False(response);
        }

        [Fact]
        public void ValidateCliente_ShouldNotValidateCliente_WhenNomeNotInformed()
        {
            var cliente = new Cliente(3216549879, "", 44556655, 0);
            
            var response = ClienteService.ValidateCliente(cliente);

            Assert.False(response);
        }

        [Fact]
        public void ValidateCliente_ShouldNotValidateCliente_WhenNoParameters()
        {
            var cliente = new Cliente(0, "", 0, 0);
            
            var response = ClienteService.ValidateCliente(cliente);

            Assert.False(response);
        }

        [Fact]
        public void ValidateCliente_ShouldValidateCliente_WhenValidParameters()
        {
            var cliente = new Cliente(3212354673, "Ricardo", 44664466, 50);
            
            var response = ClienteService.ValidateCliente(cliente);

            Assert.True(response);
        }
    }
}