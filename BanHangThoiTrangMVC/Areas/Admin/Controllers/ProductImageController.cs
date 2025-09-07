using BanHangThoiTrangMVC.Models;
using BanHangThoiTrangMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangThoiTrangMVC.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImage
        public ActionResult Index(int Id)
        {
            ViewBag.ProductId = Id;
            var items = db.ProductImages.Where(x => x.ProductId == Id).ToList();
            return View(items);
        }

        public ActionResult AddImage(int productId, string url)
        {
            db.ProductImages.Add(new ProductImage
            {
                ProductId = productId,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            var urls = new List<string>();
            try
            {
                if (files != null)
                {
                    var uploadRoot = Server.MapPath("~/Images/Products");
                    if (!System.IO.Directory.Exists(uploadRoot))
                        System.IO.Directory.CreateDirectory(uploadRoot);

                    var allowedExt = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                    const int maxSizeBytes = 5 * 1024 * 1024; // 5MB

                    foreach (var file in files)
                    {
                        if (file == null || file.ContentLength <= 0) continue;

                        var ext = System.IO.Path.GetExtension(file.FileName);
                        if (!allowedExt.Contains(ext))
                            return Json(new { success = false, message = "Chỉ cho phép JPG, PNG, GIF, WEBP." });

                        if (file.ContentLength > maxSizeBytes)
                            return Json(new { success = false, message = "Dung lượng tối đa 5MB/ảnh." });

                        var fileName = $"{Guid.NewGuid():N}{ext}";
                        var savePath = System.IO.Path.Combine(uploadRoot, fileName);
                        file.SaveAs(savePath);

                        var url = Url.Content("~/Images/Products/" + fileName);
                        urls.Add(url);
                    }
                }
                return Json(new { success = true, urls = urls });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductImages.Find(id);
            if (item == null) return Json(new { success = false });
            try
            {
                if (!string.IsNullOrEmpty(item.Image) && item.Image.StartsWith("~/Images/Products", StringComparison.OrdinalIgnoreCase))
                {
                    var path = Server.MapPath(item.Image);
                    if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                }
            }
            catch { }

            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }

    }
}