using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestaPOSTJson();
            TestaPOSTXml();
        }
        static void TestaGet()
        {
            string urlRequest = @"http://localhost:54373/api/carrinho/1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlRequest);
            request.Method = "GET";
            request.Accept = "application/json";
            WebResponse response = request.GetResponse();
            string conteudo = "";
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.WriteLine(conteudo);
            Console.ReadLine();
        }

        static void TestaPOSTJson()
        {
            string urlRequest = @"http://localhost:54373/api/carrinho/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlRequest);
            request.Method = "POST";
            request.Accept = "application/json";
            string json = "{'Produtos':[{'Id':6237,'Preco':4500.0,'Nome':'Telescópio Celestron','Quantidade':1}],'Endereco':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':2}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);
            request.ContentType = "application/json";

            //Obter resposta do comando http, seja GET, seja POST
            WebResponse response = request.GetResponse();
            string conteudo = "";
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.WriteLine(conteudo);
            Console.ReadLine();
        }

        static void TestaPOSTXml()
        {
            string urlRequest = @"http://localhost:54373/api/carrinho/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlRequest);
            request.Method = "POST";
            request.Accept = "application/xml";
            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Endereco>Rua Vergueiro 3185, 8 andar, Sao Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>6237</Id><Nome>play 4</Nome><Preco>4000</Preco><Quantidade>1</Quantidade></Produto><Produto><Id>3467</Id><Nome>xbox one x</Nome><Preco>60</Preco><Quantidade>2</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);
            request.ContentType = "application/xml";

            //Obter resposta do comando http, seja GET, seja POST
            WebResponse response = request.GetResponse();
            string conteudo = "";
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.WriteLine(conteudo);
            Console.ReadLine();
        }
    }
}
