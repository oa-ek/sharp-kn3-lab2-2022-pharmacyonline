﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core;
using Pharmacy.Repos;
using System.Data;
//using Pharmacy.UI.Models.ViewModels;

namespace Pharmacy.UI.Controllers
{
    [Authorize(Roles = "User")]
    public class CartController: Controller
    {
        private readonly CartView _cartRepository;
        private readonly MedicamentsRepository _medicamentsRepository;

        public CartController(MedicamentsRepository medicamentsRepository)
        {
            _medicamentsRepository = medicamentsRepository;
        }

        public IActionResult Index()
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart") ?? new List<ShopCartItem>();
            
            CartView Cart = new()
            {
                shopCartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return View("Index", Cart);
        }

        public IActionResult CreateOrder()
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart") ?? new List<ShopCartItem>();

            CartView Cart = new()
            {
                shopCartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return View(Cart);
        }
        public async Task<IActionResult> Add(int id)
        {

            Medicaments med = await _medicamentsRepository.GetMedicament(id);

            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart") ?? new List<ShopCartItem>();

            ShopCartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if(cartItem == null)
            {
                cart.Add(new ShopCartItem(med));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);
            TempData["Success"] = "Товар доданий до корзини!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {

            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");

            ShopCartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity>1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p=>p.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
           
            TempData["Success"] = "Товар видалений з корзини!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Remove(int id)
        {

            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");

            cart.RemoveAll(p=>p.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Товар видалений з корзини!";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
    }
}
