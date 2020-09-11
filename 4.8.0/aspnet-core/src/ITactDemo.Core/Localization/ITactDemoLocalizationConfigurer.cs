using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources.Resource;
using Abp.Reflection.Extensions;
using ITactDemo.Localization.ResourceFiles;
using System.Reflection;
using System.Resources;

namespace ITactDemo.Localization
{
    public static class ITactDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ITactDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ITactDemoLocalizationConfigurer).GetAssembly(),
                        "ITactDemo.Localization.SourceFiles"
                    )
                )
            );
            localizationConfiguration.Sources.Add(
                new ResourceFileLocalizationSource("ITactDemo.Localization.ResourceFiles",ResourceFile.ResourceManager));

            //ResourceManager resource = new ResourceManager("ITactDemo.Localization.ResourceFiles",Assembly.GetExecutingAssembly());
            
        }
    }
}
