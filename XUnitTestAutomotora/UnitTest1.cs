using System;
using Xunit;
using Apiautomotora.Models;
using Apiautomotora.Azure;
using System.Linq;

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
            //Automotora automotoraRetornado;

            //Act
            int automotoraRetornado = AutomotoraAzure.ObtenerAutomotoraPorId(idProbar);

            //Assert
            Assert.Equal(idProbar,automotoraRetornado);
        }

        [Fact]
        public void TestAgregarAutomotora()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            Automotora automotora = new Automotora();
            automotora.idAutomotora = 5;
            automotora.nomautomotora = "macriso";
            automotora.direccionauto = "direcciones";

            //Act
            resultadoObtenido = AutomotoraAzure.AgregarAutomotora(automotora);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
        [Fact]
        public void TestmodificarAutomotora()
        {
            Automotora automotora = new Automotora();
            automotora.idAutomotora = 5;
            automotora.nomautomotora = "mar";

            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            resultadoObtenido = AutomotoraAzure.modificarAutomotora(automotora);

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
     
       

        
    

