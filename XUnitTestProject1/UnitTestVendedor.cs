using System;
using Xunit;
using Apiautomotora.Models;
using Apiautomotora.Azure;

namespace XUnitTestVendedor
{
    public class UnitTestVendedor
    {
        [Fact]
        public void TestAgregarVendedor()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            Vendedor vendedor = new Vendedor();
            vendedor.idvendedor = 69;
            vendedor.nomvendedorven = "Henry Adasme";
            vendedor.rutvendedor = 202461107;
            vendedor.direccionven = "Tu Corazón BB";
            vendedor.numvendedor = 968288940;
            vendedor.direccionauto = "los NoFunaosSke";

            //Act
            resultadoObtenido = VendedorAzure.AgregarVendedor(vendedor);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
    }
}
