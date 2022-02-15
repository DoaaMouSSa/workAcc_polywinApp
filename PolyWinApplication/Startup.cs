using CorePush.Apple;
using CorePush.Google;
using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PolyWinApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddIdentityCore<ApplicationUser>();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
             .AddEntityFrameworkStores<ApplicationContext>()
             .AddDefaultTokenProviders();

            #region Repository   

            services.AddScoped<IUserControlService, UserControlService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDescountRepository, DescountRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceDetailsRepository, InvoiceDetailsRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IClientTypeRepository, ClientTypeRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IContractClientRepository, ContractClientRepository>();
            services.AddScoped<IPayedContractClientRepository, PayedContractClientRepository>();
            services.AddScoped<IGallaryUserRepository, GallaryUserRepository>();
            services.AddScoped<ICategoryGalleryRepository, CategoryGalleryRepository>();
            services.AddScoped<ICategoryTypeRepository, CategoryTypeRepository>();
            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddScoped<IDataSheetsRepository, DataSheetsRepository>();
            services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();
            services.AddScoped<IParentCategoryRepository, ParentCategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRespository>();
            services.AddScoped<IProductIngredientsRepository, ProductIngredientsRepository>();
            services.AddScoped<IproductIngredientAccessoryRepository, productIngredientAccessoryRepository>();
            services.AddScoped<IColorsRepository, ColorsRepository>();
            services.AddScoped<ICategoryChildGalleryRepository, CategoryChildGalleryRepository>();
            services.AddScoped<IProductNameRepository, ProductNameRepository>();
            services.AddScoped<IParentProductCategoryRepository, ParentProductCategoryRepository>();
            services.AddScoped<ICostCalculationRepository, CostCalculationRepository>();
            services.AddScoped<ICostCalculationItemsRepository, CostCalculationItemsRepository>();
            services.AddScoped<IContractCostCalcRepository, ContractCostCalcRepository>();
            services.AddScoped<IWarrantyContractsRepository, WarrantyContractsRepository>();
            services.AddScoped<IInstallmentRepository, InstallmentRepository>();
            services.AddScoped<IguaranteeRepository, guaranteeRepository>();
            services.AddScoped<IClientOpinionRepository, ClientOpinionRepository>();
            services.AddScoped<IPriceListRepository, PriceListRepository>();
            services.AddScoped<IFactorRepository, FactorRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IStoreDataRepository, StoreDataRepository>();
            services.AddScoped<IItemTypeRepository, ItemTypeRepository>();
            services.AddScoped<IBanqueRepository, BanqueRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepostiory>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPaymentMethod, PaymentMethodRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IPurchaseInvoiceRepository, PurchaseInvoiceRepository>();
            services.AddScoped<IPurchaseInvoiceDetailsRepository, PurchaseInvoiceDetailsRepository>();

            #endregion Repository
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            services.AddTransient<INotificationService, NotificationService>();
            services.AddHttpClient<FcmSender>();
            services.AddHttpClient<ApnSender>();

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("FcmNotification");
            services.Configure<FcmNotificationSetting>(appSettingsSection);
            services.AddSwaggerGen(async c =>
            {
                // include all project's xml comments
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (!assembly.IsDynamic)
                    {
                        var xmlFile = $"{assembly.GetName().Name}.xml";
                        var xmlPath = Path.Combine(baseDirectory, xmlFile);
                        if (File.Exists(xmlPath))
                        {
                            c.IncludeXmlComments(xmlPath);
                        }
                    }
                }

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Polywinegypt.CleanArchitecture",
                    License = new OpenApiLicense
                    {
                        Name = "Polywinegypt",
                        Url = new Uri("http://polywinegypt.com")
                    }
                });

                //  var localizer = await GetRegisteredServerLocalizerAsync<ServerCommonResources>(services);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    // Description = localizer["Input your Bearer token in this format - Bearer {your token here} to access this API"],
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     //Validate the recipient of the token is authorized to receive  (ValidateAudience = true)
                     ValidateAudience = true,
                     //Check if the token is not expired and the signing key of the issuer is valid (ValidateLifetime = true)
                     ValidateLifetime = true,
                     //Validate signature of the token(ValidateIssuerSigningKey = true)
                     ValidateIssuerSigningKey = true,
                     ValidAudience = Configuration["Jwt:Audience"],
                     ValidIssuer = Configuration["Jwt:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]))
                     // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                 };

                 //options.Events = new JwtBearerEvents
                 //{
                 //    OnMessageReceived = context =>
                 //    {
                 //        var accessToken = context.Request.Query["Token"];
                 //        if (string.IsNullOrEmpty(accessToken) == false)
                 //        {
                 //            context.Token = accessToken;
                 //        }
                 //        return Task.CompletedTask;
                 //    }
                 //};
             });


            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Default Password settings.
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 2;
            //    options.Password.RequiredUniqueChars = 0;

            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.AllowedForNewUsers = true;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(Program).Assembly.GetName().Name);
                options.RoutePrefix = "swagger";
                options.DisplayRequestDuration();
            });



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
