using Abp.Localization;
using ITactDemo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITactDemo.Migrations.SeedData
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguage { get; set; }

        private readonly ITactDemoDbContext _context;

        static DefaultLanguagesCreator()
        {
            InitialLanguage = new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null,"en","English"),
                new ApplicationLanguage(null,"hi","Hindi")
            };
        }
        public DefaultLanguagesCreator(ITactDemoDbContext context)
        {
            _context = context;
        }
        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguage)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }
            _context.Languages.Add(language);
            _context.SaveChanges();
        }
    }
}
