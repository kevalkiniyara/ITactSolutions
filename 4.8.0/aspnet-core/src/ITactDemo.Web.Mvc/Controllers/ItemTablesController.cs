using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Timing;
using Abp.UI;
using ITactDemo.Controllers;
using ITactDemo.ItemTables;
using ITactDemo.ItemTables.Dto;
using ITactDemo.Web.Models.ItemTables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITactDemo.Web.Mvc.Controllers
{
    public class ItemTablesController : ITactDemoControllerBase
    {
        private readonly ItemTableAppService _itemTableAppService;

        public ItemTablesController(ItemTableAppService itemTableAppService)
        {
            _itemTableAppService = itemTableAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CreateOrUpdateItems(int? id)
        {
            CreateOrUpdateItemTableDto createOrUpdateItemTable = await _itemTableAppService.GetItemsForEdit(new NullableIdDto { Id = id });
            CreateOrupdateItemTableViewModel createOrupdateItemTableViewModel = new CreateOrupdateItemTableViewModel(createOrUpdateItemTable);
            return View(createOrupdateItemTableViewModel);
        }

        [HttpPost]
        public async Task CreateOrEditItems(CreateOrUpdateItemTableDto input)
        {
            
            if(Request.Form.Files.Count()>0)
            {
                if(!Directory.Exists(Path.Combine(AppConsts.rootPath,AppConsts.UploadFolderPathitem)))
                {
                    Directory.CreateDirectory(Path.Combine(AppConsts.rootPath, AppConsts.UploadFolderPathitem));
                }
                string[] fileExtensionArray = new string[] { ".png", ".jpg", ".jpeg" };
                foreach(IFormFile file in Request.Form.Files)
                {
                    if (file != null)
                    {
                        string fileSavePath = Path.Combine(AppConsts.rootPath, AppConsts.UploadFolderPathitem);
                        string fileExtension = Path.GetExtension(file.FileName);
                        if (!fileExtensionArray.Contains(fileExtension))
                        {
                            throw new UserFriendlyException("Please select of .jpg,.png,.JPEG");
                        }
                        input.Image = Guid.NewGuid() + Clock.Now.ToString("yyMMddHHmm") + fileExtension;

                        using (FileStream stream = new FileStream(Path.Combine(fileSavePath, input.Image), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
            }
            await _itemTableAppService.CreateOrupdateItems(input);
        }

    }
}