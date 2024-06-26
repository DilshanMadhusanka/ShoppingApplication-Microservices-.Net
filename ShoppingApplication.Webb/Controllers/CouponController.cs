﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingApplication.Webb.Models;
using ShoppingApplication.Webb.Service.IService;

namespace ShoppingApplication.Webb.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }


        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? response = await _couponService.GetAllCouponsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }


            Console.WriteLine(list);
            return View(list);

        }
       
    }
}
