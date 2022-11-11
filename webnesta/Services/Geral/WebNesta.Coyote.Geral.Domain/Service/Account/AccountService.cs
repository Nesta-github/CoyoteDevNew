using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Core.Domain;
using WebNesta.Coyote.Core.Utils;
using WebNesta.Coyote.Geral.Domain.ViewModel;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class AccountService : IDomainService, IDomainAccountService
    {
        public readonly IAccountRepository<UTUTISEN, TUSUSUARI> _repository;
        public AccountService(IAccountRepository<UTUTISEN, TUSUSUARI> repository)
        {
            _repository = repository;
        }

        public string GetAccount(string username, string password)
        {
            var result = string.Empty;

            try
            {
                result = _repository.ValidateAccountAccess(username, password);

                return result;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }

        public 
            /*async */
            string
            /*Task<ValidateViewModel> */
            RecoveryPassword(string emailRecoveryPassword)
        {
            var message = string.Empty;
            //ValidateViewModel validateModel = null;

            if (string.IsNullOrEmpty(emailRecoveryPassword))
            {
                message = "E-mail deve ser preenchido.";
                return message;
               // validateModel = new ValidateViewModel(false, "E-mail deve ser preenchido.");
               // return validateModel;
            }

            var userAccount = _repository.GetAccountByEmail(emailRecoveryPassword);

            if(userAccount == null || (userAccount != null && string.IsNullOrEmpty(userAccount.USIDUSUA)))
            {
                message = "Email não cadastrado.";
                    return message;
               //validateModel = new ValidateViewModel(false, "Email não cadastrado.");
               //return validateModel;
            }

            if (userAccount != null && !string.IsNullOrEmpty(userAccount.USIDUSUA))
            {
                var userCredential = _repository.GetCredential(userAccount.USIDUSUA);

                if (userCredential != null && !string.IsNullOrEmpty(userCredential.USIDUSUA))
                {
                    var code = StringUtil.RandomString(8);

                    var result = _repository.ResetCredential(userAccount.USEMAILU, code);

                    //RESGATA A SENHA
                    var userAccountNewPassword = _repository.GetAccountByEmail(emailRecoveryPassword);

                    //Gerenciador de notificações
                    IDomainNotifyService notifyEmail = NotifyFactory.Create<NotifyEmailService>();
                    IDomainNotifyService notifyWhatsApp = NotifyFactory.Create<NotifyWhatsAppService>();

                    //ENVIAR O EMAIL
                    var taskSendEmail = System.Threading.Tasks.Task.Run(async () =>
                    {
                        await notifyEmail.SendMessage(new Notify()
                        {
                            To = new List<string>() { userAccount.USEMAILU },
                            Subject = "Recuperação de Senha",
                            Body = string.Concat("<b>Olá, usuário Coyote!</b><br />Você solicitou a recuperação de senha do seu login Coyote Contracts.</p>",
                                            "<br /><br /><p> Esta é sua senha provisória para acesso ao sistema: ", userAccountNewPassword.USNMPRUS),
                            RandomCode = code,
                            Reset = true
                        });
                    });
                    
                    //  WHATS APP
                    var taskSendWhatsApp = System.Threading.Tasks.Task.Run(async () =>
                    {
                        await notifyWhatsApp.SendMessage(new Notify()
                        {
                            PhoneTo = userAccount.USNUMCEL,
                            From= "Coyote Contracts",
                            Message =  string.Format("Senha de acesso ao sistema foi recuperada. \n*{0}*", code)
                        });
                    });

                    taskSendEmail.Wait();
                    // taskSendWhatsApp.Wait();
                    // validateModel = new ValidateViewModel(true, "Enviado e-mail com senha temporária.");
                    message = "Enviado e-mail com senha temporária.";
                }
            }

            return message;
        }

        private string SetCredConnConnection(string connection)
        {
            var newConnection = string.Empty;
            string[] splittedString = connection.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> dictionary =
                                  splittedString.ToDictionary(s => s.Split('=')[0], s => s.Split('=')[1]);
#if DEBUG
            dictionary["Data Source"] = "177.153.236.228";
#endif
            //Provider=MSOLEDBSQL.1;Data Source=10.33.30.12;User ID=RE_DEMO;Password=%r3_DEMO#;Initial Catalog=RE_DEMO;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=CPRO99999;Initial File Name=;Use Encryption for Data=True;Tag with column collation when possible=False;MARS Connection=False;DataTypeCompatibility=0;Trust Server Certificate=True;Application Intent=READWRITE;MultisubnetFailover=False;Use FMTONLY=False;Authentication=;Access Token=;Connect Timeout=600
            newConnection = $"Data Source={dictionary["Data Source"]};Initial Catalog={dictionary["Initial Catalog"]};User id={dictionary["User ID"]};Password={dictionary["Password"]};";

            return newConnection;

        }
    }
}
