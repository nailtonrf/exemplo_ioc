using System;
using Core;
using Domain;
using Inversao_Controle;
using Microsoft.Extensions.DependencyInjection;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var injetor = new ServiceCollection();

            //Registro do serviço de domínio.
            injetor.AddTransient<IDomainService, DomainService>();

            //Dependendo do host poderão ter formas diferentes de realizar a IUserContext.
            //Podemos injetar no contexto scope um delegate (factory) para prover uma instância que realize IUserContext.
            injetor.AddScoped<IUserContext>(p => new UserContextFromHost(Guid.NewGuid(), "Usuáro provido pelo Host"));
            //Tem que deixar o domínio somente conhecendo as interfaces/implementações de Core.
            //Só dependendo do .Net Framework.
            //As implementações do Core são todas injetadas pelo HOST.

            //Em minhas aplicações eu tenho a seguinte estrutura:

            /*
                1. Infraestrutura de Core (depende somente do .Net ou alguma outra coisa que possa usar => PORÉM TENDO A CONSCIÊNCIA DA DEPENDÊNCA)
                2. Provedores: são implementadoes das abstrações fornecidas pelo Core. Exemplo: Provedores de mensageria, banco de dados...
                3. Domínio: DDD que somente depende da Infraestrutura de Core (1.)
                4. Host: Expõe as funcionalidades e LIGA INFRAESTRUTURA DE CORE aos PROVEDORES que o HOST precisa. Ou seja, o HOST que registra as dependências.            
             
             */

            using (var resolvedor = injetor.BuildServiceProvider())
            {
                using (resolvedor.CreateScope())
                {
                    Console.WriteLine(resolvedor.GetService<IDomainService>().GetUserFromHost());
                }
            }

            Console.ReadKey();
        }
    }
}