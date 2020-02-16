using System;
namespace TelefoniaRefactorizada.logicaNegocio
{
    public class ChipPrepago
    {
        private static int codigoPais = 506;
        private static int cantidadLineas = 0;
        private int numTel;
        private double saldo;
        private Boolean isActivado;
        private int cantSalvame;
        private double datosMB = 0;
        private String duenio;
        private Llamada[] listaLlamadasRealizadas = new Llamada[10];
        private Mensaje[] listaMensajesEnviados = new Mensaje[10];
        private Llamada[] listaLlamadasRecibidas = new Llamada[10];
        private Mensaje[] listaMensajesRecibidos = new Mensaje[10];

        public ChipPrepago(int pNumTel)
        {
            numTel = pNumTel;
            saldo = 0;
            codigoPais = 506;
            isActivado = false;
            cantSalvame = 0;
            datosMB = 0;
            cantidadLineas += 1;
        }

        public String activar(String pDuenio, int pDatosMoviles)
        {
            saldo = 1000;
            isActivado = true;
            cantSalvame = 3;
            datosMB = pDatosMoviles;
            duenio = pDuenio;
            return "La línea ha sido activada con exito";
        }

        public double consultarSaldo()
        {
            return this.saldo;
        }

        public String consultarActividad(ChipPrepago chipConsultar)
        {
            int i = 0;
            String msg = "";
            int numConsulta = chipConsultar.numTel;
            Llamada[] llamadasEncontradas = buscarLlamadas(numConsulta);
            Mensaje[] mensajesEncontrados = buscarMensajes(numConsulta);
            return "Llamadas y mensajes realizados:\n" + string.Join(", ", (object[])llamadasEncontradas) + "\n" + string.Join(", ", (object[])mensajesEncontrados);
        }

        private Llamada[] buscarLlamadas(int numConsultar)
        {
            int i = 0;
            int j = 0;
            Llamada[] llamadasEncontradas = new Llamada[10];
            while (i > 10)
            {
                if (this.listaLlamadasRealizadas[i].getNumDestino() == numConsultar)
                {
                    llamadasEncontradas[j] = this.listaLlamadasRealizadas[i];
                    j++;
                }
                i++;
            }
            return llamadasEncontradas;
        }

        private Mensaje[] buscarMensajes(int numConsultar)
        {
            int i = 0;
            int j = 0;
            Mensaje[] MensajesEncontrados = new Mensaje[10];
            while (i > 10)
            {
                if (this.listaMensajesRecibidos[i].getNumDestino() == numConsultar)
                {
                    MensajesEncontrados[j] = this.listaMensajesRecibidos[i];
                    j++;
                }
                i++;
            }
            return MensajesEncontrados;
        }

        public String recargar(double recarga)
        {
            if (recarga > 0)
            {
                this.saldo += recarga;
                return "Recarga correcta, saldo: " + this.saldo;
            }
            else
            {
                return "Monto a recargar invalido";
            }

        }

        public String salvar()
        {
            if (this.cantSalvame == 0)
            {
                return "El usuario no tiene mas oportunidades";
            }
            else
            {
                if (saldo == 0)
                {
                    saldo += 100;
                    this.cantSalvame--;
                    return "Listo, usted cuenta con 100 colones de saldo";
                }
                else
                {
                    return "No se puede utilizar Sálvame. " + "El saldo no es igual a 0";
                }
            }
        }

        public String llamar(ChipPrepago destino, int minutos)
        {
            int costoLlamada = minutos * 30;
            if (costoLlamada > this.saldo)
            {
                return "No se puede realizar la llamada porque no cuenta con suficiente saldo.";
            }
            else
            {
                Llamada llamadaNueva = new Llamada(destino, minutos);
                int i = 0;
                if (listaLlamadasRealizadas[9] != null)
                {
                    Llamada[] nuevoArreglo = new Llamada[10];
                    while (i < 9)
                    {
                        nuevoArreglo[i] = listaLlamadasRealizadas[i + 1];
                        i++;
                    }
                    listaLlamadasRealizadas = nuevoArreglo;
                }
                else
                {
                    while (listaLlamadasRealizadas[i] != null)
                    {
                        i++;
                    }
                    listaLlamadasRealizadas[i] = llamadaNueva;
                }

                i = 0;
                if (destino.listaLlamadasRecibidas[9] != null)
                {
                    Llamada[] nuevoArreglo = new Llamada[10];
                    while (i < 9)
                    {
                        nuevoArreglo[i] = destino.listaLlamadasRecibidas[i + 1];
                        i++;
                    }
                    destino.listaLlamadasRecibidas = nuevoArreglo;
                }
                else
                {
                    while (destino.listaLlamadasRecibidas[i] != null)
                    {
                        i++;
                    }
                    destino.listaLlamadasRecibidas[i] = llamadaNueva;
                }
                this.saldo = this.saldo - costoLlamada;
                return "Llamada realizada con éxito. " + "Saldo actual: " + this.saldo;
            }
        }

        public String enviarSms(ChipPrepago destino, String sms)
        {
            if (this.saldo > 20)
            {
                if (sms.Length <= 128)
                {
                    Mensaje MensajeNuevo = new Mensaje(destino, sms);
                    int i = 0;
                    if (listaMensajesEnviados[9] != null)
                    {
                        Mensaje[] nuevoArreglo = new Mensaje[10];
                        while (i < 9)
                        {
                            nuevoArreglo[i] = listaMensajesEnviados[i + 1];
                            i++;
                        }
                        listaMensajesEnviados = nuevoArreglo;
                    }
                    else
                    {
                        while (listaMensajesEnviados[i] != null)
                        {
                            i++;
                        }
                        listaMensajesEnviados[i] = MensajeNuevo;
                    }

                    i = 0;
                    if (destino.listaMensajesRecibidos[9] != null)
                    {
                        Mensaje[] nuevoArreglo = new Mensaje[10];
                        while (i < 9)
                        {
                            nuevoArreglo[i] = destino.listaMensajesRecibidos[i + 1];
                            i++;
                        }
                        destino.listaMensajesRecibidos = nuevoArreglo;
                    }
                    else
                    {
                        while (destino.listaMensajesRecibidos[i] != null)
                        {
                            i++;
                        }
                        destino.listaMensajesRecibidos[i] = MensajeNuevo;
                    }
                    return "El mensaje ha sido enviado con éxito al número: " + destino.numTel;
                }
                else
                {
                    return "Eror: El mensaje debe ser menor a 128 caracteres";
                }
            }
            else
            {
                return "No hay suficiente saldo para enviar el mensaje";
            }
        }

        public String consultarLlamadasRealizadas()
        {
            return string.Join(", ", (object[])listaLlamadasRealizadas);
        }

        public String consultarMensajesEnviados()
        {
            return string.Join(", ", (object[])listaMensajesEnviados);
        }

        public String transferir(ChipPrepago chipRecibe, double pSaldo)
        {
            if (this.saldo > pSaldo && pSaldo > 0)
            {
                this.saldo -= pSaldo;
                this.saldo -= 5;
                chipRecibe.saldo += pSaldo;
                return "Transferencia  completada";

            }
            else
            {
                return "No se puede completar la transferencia el saldo es insuficiente";
            }
        }

        public String verMensajesRecibidos()
        {
            String msg = "";
            for (int i = 0; i < 10; i++)
            {
                msg += this.listaMensajesRecibidos[i].ToString();
            }
            return msg;
        }

        public String navegar(String url)
        {
            Random random = new Random();
            double KBConsumidos = (random.Next() * 8) + 1;
            if ((this.datosMB * 1024) < KBConsumidos)
            {
                return "No hay suficientes datos para visitar la página";
            }
            else
            {
                this.datosMB -= KBConsumidos / 1024;
                return this.datosMB + " MegaBytes disponibles.";
            }
        }

        public int cantLineas()
        {
            return ChipPrepago.cantidadLineas;
        }

        public int getNum()
        {
            return this.numTel;
        }

        public String toString()
        {
            String msg = "";
            msg = "Dueño: " + this.duenio + "\n";
            msg += "Número de teléfono: " + this.numTel + "\n";
            msg += "Saldo: " + this.saldo + "\n";
            msg += "Datos en MB: " + this.datosMB + "\n";
            msg += "Codigo País: " + ChipPrepago.codigoPais + "\n";
            msg += "Salvame enviados: " + this.cantSalvame + "\n";
            return msg;
        }
    }
}
