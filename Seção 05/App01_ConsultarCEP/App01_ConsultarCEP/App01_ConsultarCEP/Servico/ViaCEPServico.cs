using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;


namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();

            string retorno = wc.DownloadString(novoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(retorno);

            if (string.IsNullOrEmpty(endereco.cep))
                return null;

            return endereco;
        }
    }
}
