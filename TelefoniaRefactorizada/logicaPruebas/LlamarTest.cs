using System;
using System.Linq;
using Xunit;
using TelefoniaRefactorizada.logicaNegocio;

namespace TelefoniaRefactorizada.logicaPruebas
{
    public class LlamarTest{
        [Fact]
        public void LlamarTestSaldo(){
            //Arrange
            String esperado = "No se puede realizar la llamada porque no cuenta con suficiente saldo.";
            ChipPrepago remitente = new ChipPrepago(71932777);
            ChipPrepago destinatario = new ChipPrepago(71932799);
            remitente.recargar(30);

            //Act
            String actual = remitente.llamar(destinatario, 2);

            //Assert
            Assert.Equal(esperado, actual);
            
        }
        [Fact]
        public void LlamarTestCorrecto(){
            //Arrange
            String esperado = "Llamada realizada con éxito. " + "Saldo actual: 0";
            ChipPrepago remitente = new ChipPrepago(71932777);
            ChipPrepago destinatario = new ChipPrepago(71932799);
            remitente.recargar(60);

            //Act
            String actual = remitente.llamar(destinatario, 2);

            //Assert
            Assert.Equal(esperado, actual);

        }
    }
}
