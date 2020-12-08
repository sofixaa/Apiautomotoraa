using System;
using Xunit;
using Apiautomotora.Models;
using Apiautomotora.Azure;

namespace XUnitTestCliente
{
    public class UnitCliente
    {
        [Fact]
        public void Test1()

        {
            [Fact]
            public void ObtenerClientes()
            {
                //Arrange
                bool estaVacio = false;

                //Act
                var Resultado = ClienteAzure.ObtenerClientes();
                estaVacio = !Resultado.Any();

                //Assert
                Assert.False(estaVacio);
            }

            [Fact]
            public void TestObtenerClientePorRut()
            {
                //Arrange
                string rutProbar = "20235678-7";
                Cliente clienteRetornado;

                //Act
                clienteRetornado = ClienteAzure.ObtenerClientePorRut(rutProbar);

                //Assert
                Assert.NotNull(clienteRetornado);
            }
            [Fact]
            public void TestAgregarCliente()
            {
                //Arrange
                int resultadoEsperado = 1;
                int resultadoObtenido = 0;
                Cliente cliente = new Cliente();
                cliente.rutcliente = "208804298";
                cliente.nombrecli = "simon";
                cliente.direccioncli = "por ahi ";
                cliente.fechanaci = "20-10-1990";
                cliente.numcel = "994565423";

            //Act
            resultadoObtenido = ClienteAzure.AgregarCliente(cliente);

                //Assert
                Assert.Equal(resultadoEsperado, resultadoObtenido);
            }

            [Fact]
            public void TestEliminarClientePorRut()
            {
                //Arrange
                Cliente cliente = new Cliente();
                cliente.rutcliente = "208804223";
                cliente.nombrecli = "simona";
                cliente.direccioncli = "por ahi xd ";
                cliente.fechanaci = "20-10-1991";
                cliente.numcel = "994565425";

                string rutclienteaEliminar = "208804223";

                int resultadoEsperado = 1;
                int resultadoObtenido = 0;

                ClienteAzure.AgregarCliente(cliente);

                //Act
                resultadoObtenido = ClienteAzure.EliminarClientePorRut(rutclienteaEliminar);

                //Assert
                Assert.Equal(resultadoEsperado, resultadoObtenido);
            }
        }
    }
    }
}
