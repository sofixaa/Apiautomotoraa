using System;
using Xunit;
using Apiautomotora.Models;
using Apiautomotora.Azure;
using System.Linq;

namespace XUnitTestAdministrador
{
    public class UnitTest1
    {
        [Fact]
        public void TestObtenerAdministradores()
        {
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
         

            //Act
            resultadoObtenido = AdministradorAzure.ObtenerAdministradores();

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

        [Fact]
        public void TestObtenerAdministradoresPorId()
        {
            //Arrange
            int idProbar = 1;
            //Automotora automotoraRetornado;

            //Act
            int administradorRetornado = AdministradorAzure.ObtenerAdministradoresPorId(idProbar);

            //Assert
            Assert.Equal(idProbar, administradorRetornado);

        }

        [Fact]
        public void TestAgregarAdministrador()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            Administrador administrador = new Administrador();
            administrador.idadmi = 4;
            administrador.nombreadmi = "macriso";
            administrador.rutadmi = "2067698326";

            //Act
            resultadoObtenido = AdministradorAzure.AgregarAdministrador(administrador);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
        [Fact]
        public void Testmodificaradministrador()
        {
            Administrador administrador = new Administrador();
            administrador.idadmi = 5;
            administrador.nombreadmi = "mar";

            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            resultadoObtenido = AdministradorAzure.modificarAdministrador(administrador);

            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }

        [Fact]
        public void TestEliminarAdministradorPorNombre()
        {
            //Arrange
            Administrador administrador = new Administrador();
            administrador.idadmi = 4;
            administrador.nombreadmi = "macriso";
            administrador.rutadmi = "2067698326";

            string nombreAdmiaEliminar = "macriso";

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

