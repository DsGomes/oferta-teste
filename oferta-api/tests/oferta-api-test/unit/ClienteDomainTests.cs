using oferta_domain;
using Xunit;

namespace oferta_api_test.unit
{
    public class ClienteDomainTests
    {
        [Fact]
        public void InsertClienteService_ShouldNotInsertClienteWhenStatusIsNot01()
        {
            //Given
            var cliente = new Cliente();
            
            //When
            var response = false;

            //Then
            Assert.True(response);
        }
    }
}