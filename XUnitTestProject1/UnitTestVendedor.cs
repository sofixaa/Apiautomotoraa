using System;
using Xunit;
using Apiautomotora.Models;
using Apiautomotora.Azure;
using System.Linq;

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
            vendedor.idvendedor = 6;
            vendedor.nomvendedorven = "Henry Adasme";
            vendedor.rutvendedor = "202461100";
            vendedor.direccionven = "Tu Corazón";
            vendedor.numvendedor = 968288940;
            vendedor.direccionauto = "los";

            //Act
            resultadoObtenido = VendedorAzure.AgregarVendedor(vendedor);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
    }
}
