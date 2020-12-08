using System;
using Xunit;
using Apiautomotora.Models;
using Apiautomotora.Azure;

namespace XUnitTestAdministrador
{
    public class UnitTest1
    {
        [Fact]
        public void TestObtenerAdministradores()
        {
            //Arrange
            bool estaVacio = false;

            //Act
            var Resultado = AdministradorAzure.ObtenerAdministradores();
            estaVacio = !Resultado.Any();

            //Assert
            Assert.False(estaVacio);
        }

        [Fact]
        public void TestObtenerAdministradoresPorId()
        {
            //Arrange
            int idProbar = 1;
            Administrador administradorRetornado;

            //Act
            administradorRetornado = AdministradorAzure.ObtenerAdministradorPorId(idProbar);

            //Assert
            Assert.NotNull(administradorRetornado);
        }

        [Fact]
        public void TestAgregarAdministrador()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            Administrador administrador = new Administrador();
            administrador.idadmi = 4;
            administrador.nombreadmi = "Aurelio";
            administrador.rutadmi = "206769833"

            //Act
            resultadoObtenido = AdministradorAzure.AgregarAdministrador(administrador);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }

        [Fact]
        public void TestEliminarCargoPorNombre()
        {
            //Arrange
            Administrador administrador = new Administrador();
            administrador.idadmi = 4;
            administrador.nombreadmi = "Aurelia";
            administrador.rutadmi = "206769832"

            string nombreAdmiaEliminar = "Aurelia";

            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            AdministradorAzure.AgregarAdministrador(administrador);

            //Act
            resultadoObtenido = AdministradorAzure.EliminarAdministradorPorNombre(nombreAdmiaEliminar);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
    }




}
}
