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

        public ValidateViewModel GetAccount(string username, string password, string lang)
        {
            var result = string.Empty;
            ValidateViewModel model = null;
            try
            {
                result = _repository.ValidateAccountAccess(username, password, lang);

                if(!string.IsNullOrEmpty(result))
                {
                    var resultSplitted = result.Split("|");

                    model = new ValidateViewModel(resultSplitted[0] == "1", resultSplitted[1].ToString());

                }

                return model;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }

        public ValidateViewModel RecoveryPassword(string emailRecoveryPassword)
        // public async Task<ValidateViewModel> RecoveryPassword(string emailRecoveryPassword)
        {
            ValidateViewModel validateModel = null;

            if (string.IsNullOrEmpty(emailRecoveryPassword))
            {
                validateModel = new ValidateViewModel(false, "E-mail deve ser preenchido.");
                return validateModel;
            }

            var userAccount = _repository.GetAccountByEmail(emailRecoveryPassword);

            if (userAccount == null || (userAccount != null && string.IsNullOrEmpty(userAccount.USIDUSUA)))
            {
                validateModel = new ValidateViewModel(false, "Email não cadastrado.");
                return validateModel;
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
                        notifyEmail.SendMessage(new Notify()
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
                    // var taskSendWhatsApp = System.Threading.Tasks.Task.Run(async () =>
                    // {
                    //     await notifyWhatsApp.SendMessage(new Notify()
                    //     {
                    //         PhoneTo = userAccount.USNUMCEL,
                    //         From= "Coyote Contracts",
                    //         Message =  string.Format("Senha de acesso ao sistema foi recuperada. \n*{0}*", code)
                    //     });
                    // });

                    taskSendEmail.Wait();
                    // taskSendWhatsApp.Wait();
                    validateModel = new ValidateViewModel(true, "Enviado e-mail com senha temporária.");
                    //message = "Enviado e-mail com senha temporária.";
                }
            }

            return validateModel;
        }
    }
}
