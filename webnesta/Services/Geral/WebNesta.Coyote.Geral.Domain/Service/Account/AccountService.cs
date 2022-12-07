using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Core.Domain;
using WebNesta.Coyote.Core.Utils;
using WebNesta.Coyote.Geral.Domain.Resource;
using WebNesta.Coyote.Geral.Domain.ViewModel;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class AccountService : IDomainService, IDomainAccountService
    {
        public readonly IAccountRepository<UTUTISEN, TUSUSUARI> _repository;
        public IConfiguration _config;
        public AccountService(IAccountRepository<UTUTISEN, TUSUSUARI> repository, IConfiguration config)
        {
            _config = config;
            _repository = repository;
        }

        public ValidateViewModel GetAccount(string username, string password, string lang)
        {
            var result = string.Empty;
            ValidateViewModel model = null;
            try
            {
                result = _repository.ValidateAccountAccess(username, password, lang);

                if (!string.IsNullOrEmpty(result))
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

        public ValidateViewModel RecoveryPassword(string emailRecoveryPassword, string lang)
        // public async Task<ValidateViewModel> RecoveryPassword(string emailRecoveryPassword)
        {
            ValidateViewModel validateModel = null;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);

            var resourceLogin = new ResourceManager("WebNesta.Coyote.Geral.Domain.Resource.Login", Assembly.GetExecutingAssembly());
           // resourceLogin localisationAssembly = Assembly.Load("WebNesta.Coyote.Geral.Domain");
           // resourceLogin RM = new ResourceManager("WebNesta.Coyote.Geral.Domain.Resource.Login", localisationAssembly);
           // var aaaaa = RM.GetString("String1");
            
            if (string.IsNullOrEmpty(emailRecoveryPassword))
            {
                validateModel = new ValidateViewModel(false, resourceLogin.GetString("login_validacao_email_preenchido"));
                return validateModel;
            }

            var userAccount = _repository.GetAccountByEmail(emailRecoveryPassword);

            if (userAccount == null || (userAccount != null && string.IsNullOrEmpty(userAccount.USIDUSUA)))
            {
                validateModel = new ValidateViewModel(false, resourceLogin.GetString("login_validacao_email_nao_cadastrado"));
                return validateModel;
            }

            if (userAccount != null && !string.IsNullOrEmpty(userAccount.USIDUSUA))
            {
                var userCredential = _repository.GetCredential(userAccount.USIDUSUA);

                if (userCredential != null && !string.IsNullOrEmpty(userCredential.USIDUSUA))
                {
                    var code = StringUtil.RandomString(8);

                    var result = _repository.ResetCredential(userCredential.USIDUSUA, code);

                    //RESGATA A SENHA
                    var userAccountNewPassword = _repository.GetAccountByEmail(emailRecoveryPassword);

                    //Gerenciador de notificações
                    var notifyEmail = NotifyFactory.Create<NotifyEmailService>();
                    notifyEmail.SetConfigurations(_config);
                    notifyEmail.messageProperties.Init(null, null, null);

                    var notifyWhatsApp = NotifyFactory.Create<NotifyWhatsAppService>();
                    notifyWhatsApp.SetConfigurations(_config);
                    
                    //ENVIAR O EMAIL
                    var taskSendEmail = System.Threading.Tasks.Task.Run(async () =>
                    {
                        notifyEmail.SendMessage(new Notify()
                        {
                            To = new List<string>() { userAccount.USEMAILU },
                            Subject = resourceLogin.GetString("login_label_recuperacao_senha"),
                            Body = string.Concat(resourceLogin.GetString("login_email_subject_recuperacao_senha"),
                                             resourceLogin.GetString("login_email_text_recuperacao_senha"), userAccountNewPassword.USNMPRUS),
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
                    //         Message =  string.Format(resourceLogin.GetString("login_whatsapp_text_recuperacao_senha"), code)
                    //     });
                    // });

                    taskSendEmail.Wait();
                    // taskSendWhatsApp.Wait();
                    validateModel = new ValidateViewModel(true, resourceLogin.GetString("login_whatsapp_senha_enviada"));
                    //message = "Enviado e-mail com senha temporária.";
                }
            }

            return validateModel;
        }
    }
}
