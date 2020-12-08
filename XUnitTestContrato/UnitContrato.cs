using System;
using Xunit;
using Apiautomotora.Models;
using Apiautomotora.Azure;
using System.Linq;


namespace XUnitTestContrato
{
    public class UnitContrato
    {
        [Fact]
        public void TestContrato()

        {
            //Arrange
            bool estaVacio = false;

            //Act
            var Resultado = ContratoAzure.ObtenerContratos();
            estaVacio = !Resultado.Any();

            //Assert
            Assert.False(estaVacio);
        }

        [Fact]
        public void TestObtenerContratosPorId()
        {
            //Arrange
            int idcontratoProbar = 1;
            Contrato contratoRetornado;

            //Act
            contratoRetornado = ContratoAzure.ObtenerContratosPorId(idcontratoProbar);

            //Assert
            Assert.NotNull(contratoRetornado);
        }

        [Fact]
        public void TestAgregarContrato()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            Contrato contrato = new Contrato();
            contrato.idcontrato = 3;
            contrato.rutcliente = "206769831";
            contrato.datoauto = "2";
            contrato.tipocontrato = "2";
            contrato.fecontrato = "20 - 11 - 2020";
           

            //Act
            resultadoObtenido = ContratoAzure.AgregarContrato(contrato);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }

        [Fact]
        public void TestEliminarContratoPorNumero()
        {
            //Arrange
            Contrato contrato = new Contrato();
            contrato.idcontrato = 5;
            contrato.rutcliente = "2067698312";
            contrato.tipocontrato = "23";
            contrato.fecontrato = "20 - 11 - 2021";


            int idContratoaEliminar = 5;

            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            ContratoAzure.AgregarContrato(contrato);

            //Act
            resultadoObtenido = ContratoAzure.EliminarContratoPorId(idContratoaEliminar);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
    }
}

        
    

