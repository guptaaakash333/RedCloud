using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.AssignmentType;
//using RedCloud.Application.Features.Campaign;
using RedCloud.Application.Features.Numbers.Queries;
using RedCloud.Interfaces;
using RedCloud.Models.Email;
using RedCloud.Services;
using RedCloud.ViewModel;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
IConfiguration Configuration = builder.Configuration;

// Add distributed memory cache for session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped(typeof(IApiClient<>), typeof(ApiClient<>));
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRedCloudAdminService, RedCloudAdminService>();  // Added by Atharva
builder.Services.AddScoped<IAdminResellerUser, AdminResellerUserService>();
//builder.Services.AddScoped<IAdminResellerUser, AdminResellerUserService>();
builder.Services.AddScoped(typeof(IDropDownService<CountryVM>), typeof(DropDownService<CountryVM>));
builder.Services.AddScoped(typeof(IStateService<StateVM>), typeof(StateService<StateVM>));
builder.Services.AddScoped(typeof(ICityService<CityVM>), typeof(CityService<CityVM>));
builder.Services.AddScoped<IOrganizationAdminService, OrganizationAdminService>();
builder.Services.AddScoped(typeof(INumberService<NumberVM>), typeof(NumberService<NumberVM>));
builder.Services.AddScoped(typeof(ICarrier<CarrierVM>), typeof(CarrierService<CarrierVM>));
builder.Services.AddScoped(typeof(IType<TypesVM>), typeof(TypeService<TypesVM>));
builder.Services.AddScoped(typeof(IAssignmentType<AssignmentTypeVM>), typeof(AssignmentType<AssignmentTypeVM>));
builder.Services.AddScoped(typeof(ICampaign<CampaignVM>), typeof(Campaign<CampaignVM>));
builder.Services.AddScoped(typeof(INumberService<RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM>), typeof(NumberService<RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM>));
builder.Services.AddScoped(typeof(INumberService<NumberlistVM>), typeof(NumberService<NumberlistVM>));
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<IMessagingUserService, MessagingUserService>();
builder.Services.AddScoped<IAssignNumberService, AssignNumberService>();




builder.Services.AddScoped<IRate, RateServices>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IResellerUserService, ResellerUserService>();
builder.Services.AddScoped<IOrganizationUserService, OrganizationUserService>();

builder.Services.AddScoped<ICampaignService, CampaignService>();



builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings")); // Add by Aditya
builder.Services.AddTransient<IMailService, MailService>(); // Add by Aditya
builder.Services.AddScoped<IEncryptionService, EncryptionService>(); // Add by Aditya

builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IResellerAssignCreditService, ResellerAssignCreditService>();
builder.Services.AddScoped<IReport, ReportService>();
builder.Services.AddScoped<IAdminReport, AdminReportService>();

//logger setup
Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc
.ReadFrom.Configuration(ctx.Configuration)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSerilogRequestLogging();
app.UseSession();
builder.Services.AddDistributedMemoryCache();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
        //pattern: "{controller=Home}/{action=Index}/{Id?}");
         pattern: "{controller=Account}/{action=Login}/{Id?}");
        //aakash
        //pattern: "{controller=OrganizationAdmin}/{action=ViewOrganizationAdmin}/{id?}");
        //pattern: "{controller=Campaign}/{action=Index}/{id?}");



app.Run();
