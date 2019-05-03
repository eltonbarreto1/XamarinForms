using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Pesquisar.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();

            if (isValidCep(cep).Sucesso)
            {
                Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                if (endereco != null)
                {
                    Rua.Text = endereco.logradouro;
                    Bairro.Text = endereco.bairro;
                    Cidade.Text = endereco.localidade;
                    UF.Text = endereco.uf;
                }
                else
                    DisplayAlert("Erro", string.Format("CEP não encontrado! ({0})", cep), "OK");

            }
        }

        private Resultado isValidCep(string cep)
        {
            Resultado resultado = new Resultado() { Sucesso = true };
            int novoCep = 0;

            if (cep.Length != 8 || !int.TryParse(cep, out novoCep))
            {
                resultado.Sucesso = false;
                DisplayAlert("Erro", "CEP inválido!", "OK");
            }

            return resultado;
        }
    }
}
