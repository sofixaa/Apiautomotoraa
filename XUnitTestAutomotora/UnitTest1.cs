using System;
using Xunit;
using Apiautomotora.Models;
using Apiautomotora.Azure;

namespace XUnitTestAutomotora
{
    public class UnitTest1
    {
        [Fact]
        public void ObtenerAutomotora()
        {
            //Arrange
            bool estaVacio = false;

            //Act
            var Resultado = AutomotoraAzure.ObtenerAutomotora();
            estaVacio = !Resultado.Any();

            //Assert
            Assert.False(estaVacio);
        }

        [Fact]
        public void TestObtenerAutomotoraPorId()
        {
            //Arrange
            int idProbar = 1;
            Sede sedeRetornado;

            //Act
            sedeRetornado = AutomotoraAzure.ObtenerAutomotoraPorId(idProbar);

            //Assert
            Assert.NotNull(automotoraRetornado);
        }

        [Fact]
        public void TestAgregarAutomotora()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            Automotora automotora = new Automotora();
            automotora.idAutomotora = 4;
            automotora.nomautomotora = "nomautomotora";
            automotora.direccionauto = "direccion";

            //Act
            resultadoObtenido = AutomotoraAzure.AgregarAutomotora(automotora);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }

        [Fact]
        public void TestEliminarAutomotoraPorNombre()
        {
            //Arrange
            Automotora automotora = new Automotora();
            automotora.idAutomotora = 5;
            automotora.nomautomotora = "macriso";
            automotora.direccionauto = "direcciones";

            string nombreAutomotoraaEliminar = "macriso";

            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            AutomotoraAzure.AgregarAutomotora(automotora);

            //Act
            resultadoObtenido = AutomotoraAzure.EliminarAutomotoraPorNombre(nombreAutomotoraaEliminar);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
    }
}
     
       

        
    

