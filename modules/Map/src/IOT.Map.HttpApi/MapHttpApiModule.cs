﻿using Localization.Resources.AbpUi;
using IOT.Map.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace IOT.Map
{
    [DependsOn(
        typeof(MapApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class MapHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MapHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MapResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
