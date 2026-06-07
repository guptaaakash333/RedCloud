using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedCloud.Application.Contract.Infrastructure;
using RedCloud.Application.Models.Mail;
using RedCloud.Infrastructure.Mail;
using SendGrid.Extensions.DependencyInjection;

namespace RedCloud.Infrastructure
{
    //public static class InfrastructureServiceRegistration
    //{
    //    public static IServiceCollection AddInfrastructureServices(this IServiceCollection  services, IConfiguration configuration)
    //    {
    //        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
    //        //services.AddTransient<ICsvExporter, CsvExporter>();
    //        services.AddScoped<IEmailService, EmailService>();
    //        //services.configure<cacheconfiguration>(configuration.getsection("cacheconfiguration"));
    //        //services.addmemorycache();
    //        //services.addtransient<icacheservice, memorycacheservice>();
    //        //services.AddSendGrid(options => { options.ApiKey = configuration.GetValue<string>("EmailSettings:ApiKey"); });
    //        services.AddSendGrid(options => { options.ApiKey = configuration.GetValue<string>("EmailSettings:ApiKey"); });
    //        return services;
    //    }

    //}
}