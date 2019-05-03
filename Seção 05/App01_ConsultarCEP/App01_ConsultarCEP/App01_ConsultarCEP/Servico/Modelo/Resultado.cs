using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultarCEP.Servico.Modelo
{
    public class Resultado
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public object Retorno { get; set; }
    }
}
