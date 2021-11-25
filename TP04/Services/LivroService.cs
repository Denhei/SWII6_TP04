using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TP04.models;

namespace TP04.Services
{
    class LivroService
    {
        public bool CadastrarLivro(Livro livro)
        {

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //ServicePointManager.ServerCertificateValidationCallback = MyCertHandler;

            try
            {
                string url = "http://localhost:5000/livros";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(livro);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                return true;

            }catch(Exception e)
            {
                return false;
            }
        }


        public List<Livro> BuscarLivros(){

            string url = "http://localhost:5000/livros";
            string retorno = String.Empty;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                retorno = streamReader.ReadToEnd();
            }

            List<Livro> livros = JsonConvert.DeserializeObject<List<Livro>>(retorno);

            return livros;
        }

        public void RemoverLivros(string id)
        {

            string url = $"http://localhost:5000/livros/{id}";
            string retorno = String.Empty;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                retorno = streamReader.ReadToEnd();
            }

        }

    }
}
