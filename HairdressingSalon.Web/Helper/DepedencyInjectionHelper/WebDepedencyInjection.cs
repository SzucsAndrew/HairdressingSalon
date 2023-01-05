﻿using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;
using HairdressingSalon.Data.SeedData;
using HairdressingSalon.Web.Services;
using HairdressingSalon.Web.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Security.Claims;

namespace HairdressingSalon.Web.Helper.DepedencyInjectionHelper
{
    public static class WebDepedencyInjection
    {
        public static void AddWebLayer(this IServiceCollection service, IConfigurationRoot configuration)
        {
            service.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            service.AddTransient<IEmailSender, EmailSender>();
            service.AddAutoMapper(typeof(Program).Assembly);
            service.AddAuth(configuration);
        }

        private static void AddAuth(this IServiceCollection service, IConfigurationRoot configuration)
        {
            AddLocalAuth(service);
            AddExternalAuth(service, configuration);
            AddPolicies(service);
            AddPermissionOnPages(service);
            AddCookie(service);
        }

        private static void AddLocalAuth(IServiceCollection service)
        {
            service.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<HairdressingSalonDbContext>()
                .AddDefaultTokenProviders();

            service.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                //  options.Password.RequireLowercase = true;
                //  options.Password.RequireNonAlphanumeric = true;
                //     options.Password.RequireUppercase = true;
                //     options.Password.RequiredLength = 6;
                //     options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                //  options.Lockout.AllowedForNewUsers = true;

                //   options.User.AllowedUserNameCharacters =
                //      "abcdefgijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedAccount = true;

            });
        }

        private static void AddExternalAuth(IServiceCollection service, IConfigurationRoot configuration)
        {
            service.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
        }

        private static void AddPolicies(IServiceCollection service)
        {
            service.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyHelper.Admin, policy => policy.RequireClaim(ClaimTypes.Role, RoleHelper.Administrators));
                options.AddPolicy(PolicyHelper.RequiredAdministratorRole, policy => policy.RequireRole(RoleHelper.Administrators));
                options.AddPolicy(PolicyHelper.Hairdresser, policy => policy.RequireClaim(ClaimTypes.Role, RoleHelper.Hairdressers));
                options.AddPolicy(PolicyHelper.RequiredHairdresserRole, policy => policy.RequireRole(RoleHelper.Hairdressers, RoleHelper.Administrators));
                options.AddPolicy(PolicyHelper.Customer, policy => policy.RequireClaim(ClaimTypes.Role, RoleHelper.Customers));
                options.AddPolicy(PolicyHelper.RequiredCustomerRole, policy => policy.RequireRole(RoleHelper.Customers, RoleHelper.Administrators));
            });
        }

        private static void AddPermissionOnPages(IServiceCollection service)
        {
            service.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin", PolicyHelper.RequiredAdministratorRole);
                options.Conventions.AuthorizeFolder("/Hairdresser", PolicyHelper.RequiredHairdresserRole);
            });
        }

        private static void AddCookie(IServiceCollection service)
        {
            service.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                //options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }
    }
}
