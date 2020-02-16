using System;
using System.Linq;
using Xunit;
using TelefoniaRefactorizada.logicaNegocio;


namespace TelefoniaRefactorizada.logicaPruebas
{
    public class EnviarSMSTest
    {
        [Fact]
        public void EnviarSMSTestCorrecto(){
            //Arrange
            String esperado= "El mensaje ha sido enviado con éxito al número: 71932799";
            ChipPrepago remitente = new ChipPrepago(71932777);
            ChipPrepago destinatario = new ChipPrepago(71932799);
            remitente.recargar(500);
            String mensaje = "Esto es un mensaje de prueba con menos de 128 caracteres";
            
            //Act
            String actual = remitente.enviarSms(destinatario, mensaje);

            //Assert
            Assert.Equal(esperado, actual);
        }

        [Fact]
        public void EnviarSMSTestCaracteres()
        {
            //Arrange
            String esperado = "Eror: El mensaje debe ser menor a 128 caracteres";
            ChipPrepago remitente = new ChipPrepago(71932777);
            ChipPrepago destinatario = new ChipPrepago(71932799);
            remitente.recargar(500);
            String mensaje = "Esto es un mensaje de prueba con más de 128 caracteres Esto es un mensaje de prueba con menos de 128 caracteresEsto es un mensaje de prueba con menos de 128 caracteresEsto es un mensaje de prueba con menos de 128 caracteresEsto es un mensaje de prueba con menos de 128 caracteresEsto es un mensaje de prueba con menos de 128 caracteres ";

            //Act
            String actual = remitente.enviarSms(destinatario, mensaje);

            //Assert
            Assert.Equal(esperado, actual);
        }

        [Fact]
        public void EnviarSMSTestSaldo()
        {
            //Arrange
            String esperado = "No hay suficiente saldo para enviar el mensaje";
            ChipPrepago remitente = new ChipPrepago(71932777);
            ChipPrepago destinatario = new ChipPrepago(71932799);
            String mensaje = "Esto es un mensaje de prueba con menos de 128 caracteres";

            //Act
            String actual = remitente.enviarSms(destinatario, mensaje);

            //Assert
            Assert.Equal(esperado, actual);
        }
    }
}
